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

        public int ErrorRate { get; private set; }

        public Scanner(string data)
        {
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
/*
        public void Translate()
        {
        }

        public int FromMyTicketGet(string key)
        {
            throw new NotImplementedException();
        }*/
    }
}