using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day13.Logic
{
    public class BusStop
    {
        private readonly string _notes;

        public int Arrival { get; private set; }
        public int EarliestBusArriving { get; private set; }
        public List<(int BusId, int Offset)> BusesArrivingByOffset { get; private set; }
        public int BusIdTimesWaitingTime { get; private set; }
        public long EarliestConsecutiveBusArrival { get; private set; }

        public BusStop(string notes)
        {
            _notes = notes;

            ParseNotes();
        }

        private void ParseNotes()
        {
            var splittedNotes = _notes.Split("\n");
            Arrival = int.Parse(splittedNotes[0]);
            BusesArrivingByOffset = splittedNotes[1]
                .Split(",")
                .Select((p, i) => (BusId: p != "x"? int.Parse(p) : 0, Offset: i))
                .Where(p => p.BusId != 0)
                .ToList();
        }

        public void CalculateEarliestArrival()
        {
            var maximumBusId = BusesArrivingByOffset.Max(p => p.BusId);

            for (var arrivalTime = Arrival; arrivalTime < arrivalTime + maximumBusId; arrivalTime++)
            {
                if (BusesArrivingByOffset.Any(p => arrivalTime % p.BusId == 0))
                {
                    EarliestBusArriving = BusesArrivingByOffset.Single(p => arrivalTime % p.BusId == 0).BusId;
                    BusIdTimesWaitingTime = EarliestBusArriving * (arrivalTime - Arrival);
                    return;
                }
            }
       }

        public void CalculateEarliestConsecutiveArrival()
        {
            var found = false;
            var maximum = BusesArrivingByOffset.Max(p => p.BusId);
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

        public void CalculateEarliestConsecutiveArrival2()
        {
            var buses = BusesArrivingByOffset;

            foreach (var bus in buses)
            {
                for (var offset = bus.BusId + bus.Offset; offset <= buses[^1].Offset; offset += bus.BusId)
                {
                    if (buses.Any(p => p.Offset == offset))
                    {
                        var index = buses
                            .Select((p, i) => new {
                                p.BusId,
                                p.Offset,
                                Index = i
                            })
                            .Where(p => p.Offset == offset || p.BusId == bus.BusId)
                            .OrderByDescending(p => p.BusId)
                            .Select(p => p.Index)
                            .First();

                        BusesArrivingByOffset = BusesArrivingByOffset
                            .Select((p, i) => i != index
                                ? p
                                : (BusId: p.BusId * bus.BusId, p.Offset))
                            .ToList();
                    }
                }

                for (var offset = bus.Offset - bus.BusId; offset >= 0; offset -= bus.BusId)
                {
                    if (buses.Any(p => p.Offset == offset))
                    {
                        var index = buses
                            .Select((p, i) => new {
                                p.BusId,
                                p.Offset,
                                Index = i
                            })
                            .Where(p => p.Offset == offset || p.BusId == bus.BusId)
                            .OrderByDescending(p => p.BusId)
                            .Select(p => p.Index)
                            .First();

                        BusesArrivingByOffset = BusesArrivingByOffset
                            .Select((p, i) => i != index
                                ? p
                                : (BusId: p.BusId * bus.BusId, p.Offset))
                            .ToList();
                    }
                }
            }

            CalculateEarliestConsecutiveArrival();
        }
    }
}