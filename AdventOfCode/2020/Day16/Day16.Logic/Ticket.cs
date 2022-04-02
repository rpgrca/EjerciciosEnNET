using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day16.Logic
{
    public class Ticket
    {
        private readonly string _ticket;
        private List<int> _values;

        public int FieldCount => _values.Count;

        public Ticket(string ticket)
        {
            _ticket = ticket;
            _values = new List<int>();

            ParseTicket();
        }

        private void ParseTicket() =>
            _values = _ticket
                .Split(",")
                .Select(v => int.Parse(v))
                .ToList();

        public bool HasValuesDefinedIn(Rules rules) =>
            _values.All(v => rules.Includes(v));

        public List<int> GetValuesNotDefinedIn(Rules rules) =>
            _values.Where(v => !rules.Includes(v))
                .ToList();

        public int GetValueAt(int position) =>
            _values[position];
    }
}