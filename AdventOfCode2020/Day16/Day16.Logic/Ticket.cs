using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day16.Logic
{
    public class Ticket
    {
        private readonly string _ticket;
        private readonly List<int> _values;

        public int FieldCount => _values.Count;

        public Ticket(string ticket)
        {
            _ticket = ticket;
            _values = new List<int>();

            ParseTicket();
        }

        private void ParseTicket()
        {
            foreach (var value in _ticket.Split(","))
            {
                _values.Add(int.Parse(value));
            }
        }

        public bool HasValuesDefinedIn(Rule rule)
        {
            return _values.All(v => rule.Includes(v));
        }

        public bool HasValuesDefinedIn(Rules rules)
        {
            return _values.All(v => rules.Includes(v));
        }

        public List<int> GetValuesNotDefinedIn(Rules rules)
        {
            return _values.Where(v => !rules.Includes(v)).ToList();
        }

        public int GetValueAt(int position)
        {
            return _values[position];
        }
    }
}