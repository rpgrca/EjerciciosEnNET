using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode2020.Day13.Logic
{
    public class BusStop
    {
        private readonly string _notes;
        private long _maximumBusId;

        public int Arrival { get; private set; }
        public long EarliestBusArriving { get; private set; }
        public List<(long BusId, long Offset)> BusesArrivingByOffset { get; private set; }
        public long BusIdTimesWaitingTime { get; private set; }
        public long EarliestConsecutiveBusArrival { get; private set; }

        public BusStop(string notes)
        {
            _notes = notes;
            BusesArrivingByOffset = new List<(long BusId, long Offset)>();

            ExtractArrivalInMinutesFromNotes();
            ExtractBusIdsFromNotes();
        }

        public void ExtractArrivalInMinutesFromNotes() =>
            Arrival = int.Parse(_notes.Split("\n")[0]);

        private void ExtractBusIdsFromNotes() =>
            BusesArrivingByOffset = _notes
                .Split("\n")[1]
                .Split(",")
                .Select((p, i) => (BusId: p != "x" ? long.Parse(p) : 0, Offset: (long)i))
                .Where(p => p.BusId != 0)
                .ToList();

        public void CalculateEarliestArrival()
        {
            ObtainMaximumBusId();

            for (var arrivalTime = Arrival; arrivalTime < arrivalTime + _maximumBusId; arrivalTime++)
            {
                if (BusesArrivingByOffset.Any(p => BusArrivesAt(arrivalTime, p.BusId)))
                {
                    CalculateEarliestBusArriving(arrivalTime);
                    CalculateBusIdTimesWaitingTime(arrivalTime);
                    return;
                }
            }
        }

        private void ObtainMaximumBusId() =>
            _maximumBusId = BusesArrivingByOffset
                .Max(p => p.BusId);

        private static bool BusArrivesAt(int arrivalTime, long busId) =>
            arrivalTime % busId == 0;

        private void CalculateEarliestBusArriving(int arrivalTime) =>
            EarliestBusArriving = BusesArrivingByOffset
                .Single(p => arrivalTime % p.BusId == 0)
                .BusId;

        private void CalculateBusIdTimesWaitingTime(int arrivalTime) =>
            BusIdTimesWaitingTime = EarliestBusArriving * (arrivalTime - Arrival);

        public void CalculateEarliestConsecutiveArrival()
        {
            OptimizeBusArrival();
            Calculate();
        }

        private void OptimizeBusArrival()
        {
            LookFor(x => x, (x, y) => x <= y);
            LookFor(x => -x, (x, _) => x >= 0);
        }

        private void LookFor(Func<long, long> step, Func<long, long, bool> condition)
        {
            var buses = BusesArrivingByOffset;

            foreach (var (busId, initialOffset) in buses)
            {
                for (var offset = initialOffset + step.Invoke(busId); condition.Invoke(offset, buses[^1].Offset); offset += step.Invoke(busId))
                {
                    UpdateBusesArrivingByOffsetIfNeeded(buses, busId, offset);
                }
            }
        }

        private void Calculate()
        {
            ObtainMaximumBusId();

            var found = false;
            var testedValue = _maximumBusId;
            var indexOfMaximumBusId = BusesArrivingByOffset
                .Single(p => p.BusId == _maximumBusId)
                .Offset;

            while (! found)
            {
                if (BusesArrivingByOffset.All(p => (testedValue - indexOfMaximumBusId + p.Offset) % p.BusId == 0))
                {
                    EarliestConsecutiveBusArrival = testedValue - indexOfMaximumBusId;
                    found = true;
                }
                else
                {
                    testedValue += _maximumBusId;
                }
            }
        }

        private void UpdateBusesArrivingByOffsetIfNeeded(List<(long BusId, long Offset)> buses, long busId, long offset)
        {
            if (buses.Any(p => p.Offset == offset))
            {
                UpdateBusesArrivingByOffset(buses, busId, offset);
            }
        }

        private void UpdateBusesArrivingByOffset(List<(long BusId, long Offset)> buses, long busId, long offset) =>
            BusesArrivingByOffset = BusesArrivingByOffset
                .Select((p, i) => i != GetIndexFor(buses, busId, offset)
                    ? p
                    : (BusId: p.BusId * busId, p.Offset))
                .ToList();

        private static int GetIndexFor(List<(long BusId, long Offset)> buses, long busId, long offset) =>
            buses.Select((p, i) => new
                {
                    p.BusId,
                    p.Offset,
                    Index = i
                })
                .Where(p => p.Offset == offset || p.BusId == busId)
                .OrderByDescending(p => p.BusId)
                .Select(p => p.Index)
                .First();
    }
}