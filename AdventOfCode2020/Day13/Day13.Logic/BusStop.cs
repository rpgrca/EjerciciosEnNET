using System.Globalization;
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
                .ToList();

            BusesArrivingByOffset = splittedNotes[1]
                .Split(",")
                .Select((p, i) => (BusId: p != "x"? int.Parse(p) : 0, Offset: i))
                .Where(p => p.BusId != 0)
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

        public void CalculateEarliestConsecutiveArrival()
        {
            var found = false;
            var maximum = BusesStoppingHere.Max();
            var indexOfMaximumBusId = BusesArrivingByOffset
                .Single(p => p.BusId == maximum)
                .Offset;

            for (long testedValue = maximum; ! found; testedValue += maximum)
            {
                var count = 0;

                foreach (var (busId, offset) in BusesArrivingByOffset)
                {
                    if ((testedValue - indexOfMaximumBusId + offset) % busId == 0)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (count == BusesArrivingByOffset.Count)
                {
                    EarliestConsecutiveBusArrival = testedValue - indexOfMaximumBusId;
                    found = true;
                }
            }
        }

        public int Arrival { get; private set; }
        public List<int> BusesStoppingHere { get; private set; }
        public (int BusId, int ArrivalTime) EarliestBusArrival { get; internal set; }
        public List<(int BusId, int Offset)> BusesArrivingByOffset { get; private set; }
        public int Solution { get; private set; }
        public long EarliestConsecutiveBusArrival { get; private set; }
    }
}