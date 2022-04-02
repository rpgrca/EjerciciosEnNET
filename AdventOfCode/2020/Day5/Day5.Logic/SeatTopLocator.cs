using System.Linq;

namespace AdventOfCode2020.Day5.Logic
{
    public class SeatTopLocator
    {
        private readonly string[] _seatCodes;

        public int MaximumSeatId { get; private set; }

        public SeatTopLocator(string[] seatCodes)
        {
            _seatCodes = seatCodes;
            CalculateMaximumSeatId();
        }

        private void CalculateMaximumSeatId() =>
            MaximumSeatId = _seatCodes.Max(p => new Seat(p).Id);
    }
}