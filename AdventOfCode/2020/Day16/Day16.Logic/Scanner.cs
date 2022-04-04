using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day16.Logic
{
    public class Scanner
    {
        private readonly string _data;
        private readonly Dictionary<string, int> _fields;
        private readonly Dictionary<int, List<string>> _unresolvedFields;
        private Rules _rules;
        private Ticket _myTicket;
        private List<Ticket> _otherTickets;
        public int ErrorRate { get; private set; }

        public Scanner(string data)
        {
            _data = data;
            _fields = new Dictionary<string, int>();
            _unresolvedFields = new Dictionary<int, List<string>>();

            var sections = _data.Split("\n\n");

            _rules = new Rules(sections[0]);
            _myTicket = new Ticket(sections[1].Split("\n")[1]);
            _otherTickets = sections[2]
                .Split("\n")[1..]
                .Select(t => new Ticket(t))
                .ToList();
        }

        public void Scan() =>
            ErrorRate =
                _myTicket.GetValuesNotDefinedIn(_rules).Sum() +
                _otherTickets.Sum(t => t.GetValuesNotDefinedIn(_rules).Sum());

        public void DiscardInvalidTickets() =>
            _otherTickets.RemoveAll(p => p.GetValuesNotDefinedIn(_rules).Count > 0);

        public void Translate()
        {
            PrecomputeFieldGuesses();

            while (_fields.Count < _rules.Count)
            {
                ProcessRules(Enumerable.Range(0, _myTicket.FieldCount).Where(p => !_fields.ContainsValue(p)));
                ProcessRules(_unresolvedFields.Keys);
            }
        }

        private void PrecomputeFieldGuesses()
        {
            for (var index = 0; index < _myTicket.FieldCount; index++)
            {
                var fields = _rules.GuessFieldsFor(_otherTickets.ConvertAll(t => t.GetValueAt(index)));
                if (fields.Count == 1)
                {
                    _fields[fields[0]] = index;
                }
                else
                {
                    _unresolvedFields.Add(index, fields);
                }
            }
        }

        private void ProcessRules(IEnumerable<int> listOfIndexes)
        {
            var deletions = new List<Action>();

            foreach (var index in listOfIndexes)
            {
                PurgeFieldsIfUnique(_unresolvedFields[index], index,
                    () => deletions.Add(() => _unresolvedFields.Remove(index)),
                    f => _unresolvedFields[index] = f);
            }

            deletions.ForEach(p => p());
        }

        private void PurgeFieldsIfUnique(List<string> list, int index, Action executeIfUnique, Action<List<string>> alwaysExecute)
        {
            var fields = list
                .Where(f => !_fields.ContainsKey(f))
                .ToList();

            ConfirmIfUnique(fields, index, executeIfUnique);
            alwaysExecute(fields);
        }

        private void ConfirmIfUnique(List<string> list, int index, Action executeIfUnique)
        {
            if (list.Count == 1)
            {
                _fields[list[0]] = index;
                executeIfUnique();
            }
        }

        public int FromMyTicketGet(string key) =>
            _myTicket.GetValueAt(_fields[key]);

        public long MultiplyDepartureKeys() =>
            _fields.Keys
                .Where(p => p.StartsWith("departure"))
                .Select(f => (long)_myTicket.GetValueAt(_fields[f]))
                .Aggregate((r, i) => r *= i);
    }
}