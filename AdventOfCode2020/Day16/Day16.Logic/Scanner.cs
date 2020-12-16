using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day16.Logic
{
    public class Scanner
    {
        private readonly string _data;
        private Rules _rules;
        private Ticket _myTicket;
        private List<Ticket> _otherTickets;
        private readonly Dictionary<string, int> _fields;

        public int ErrorRate { get; private set; }

        public Scanner(string data)
        {
            _fields = new Dictionary<string, int>();
            _data = data;

            ParseData();
        }

        private void ParseData()
        {
            var sections = _data.Split("\n\n");
            _rules = new Rules(sections[0]);

            _myTicket = new Ticket(sections[1].Split("\n")[1]);

            _otherTickets = sections[2]
                .Split("\n")[1..]
                .Select(t => new Ticket(t))
                .ToList();
        }

        public void Scan()
        {
            ErrorRate = _myTicket.GetValuesNotDefinedIn(_rules).Sum();
            foreach (var ticket in _otherTickets)
            {
                ErrorRate += ticket.GetValuesNotDefinedIn(_rules).Sum();
            }
        }

        public void DiscardInvalidTickets()
        {
            _otherTickets.RemoveAll(p => p.GetValuesNotDefinedIn(_rules).Count > 0);
        }

        public void Translate()
        {
            while (_fields.Count < _rules.Count)
            {
                for (var index = 0; index < _myTicket.FieldCount; index++)
                {
                    if (_fields.ContainsValue(index))
                    {
                        continue;
                    }

                    var fields = _rules.GuessFields(_otherTickets.ConvertAll(t => t.GetValueAt(index)));
                    if (fields.Count == 1)
                    {
                        _fields[fields[0]] = index;
                    }
                    else
                    {
                        fields.RemoveAll(f => _fields.Keys.Any(g => g == f));
                        if (fields.Count == 1)
                        {
                            _fields[fields[0]] = index;
                        }
                   }
                }
            }
        }

        public int FromMyTicketGet(string key)
        {
            return _myTicket.GetValueAt(_fields[key]);
        }

        public long MultiplyDepartureKeys()
        {
            return _fields.Keys
                .Where(p => p.StartsWith("departure"))
                .Select(f => (long)_myTicket.GetValueAt(_fields[f]))
                .Aggregate((r, i) => r *= i);
        }
    }
}