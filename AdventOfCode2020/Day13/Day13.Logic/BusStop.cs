using System.Linq;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day13.Logic
{
    public class BusStop
    {
        private readonly string _notes;

        public BusStop(string notes)
        {
            _notes = notes;

            ParseNotes();
        }

        private void ParseNotes()
        {
            var splittedNotes = _notes.Split("\n");
            Arrival = int.Parse(splittedNotes[0]);
            BusesStoppingHere = splittedNotes[1]
                .Split(",")
                .Where(x => x != "x")
                .Select(p => int.Parse(p))
                .OrderBy(p => p)
                .ToList();
        }

        public void CalculateEarliestArrival()
        {
            var minimumArrival = (BusId: 100000000, ArrivalTime: 100000000);

            foreach (var busId in BusesStoppingHere)
            {
                var arrivalTime = 0;
                while (arrivalTime < Arrival)
                {
                    arrivalTime += busId;
                }

                if (arrivalTime < minimumArrival.ArrivalTime)
                {
                    minimumArrival.ArrivalTime = arrivalTime;
                    minimumArrival.BusId = busId;
                }
            }

            EarliestBusArrival = minimumArrival;
            Solution = EarliestBusArrival.BusId * (EarliestBusArrival.ArrivalTime - Arrival);
        }

        public int Arrival { get; private set; }
        public List<int> BusesStoppingHere { get; private set; }
        public (int BusId, int ArrivalTime) EarliestBusArrival { get; internal set; }
        public int Solution { get; private set; }
    }
}