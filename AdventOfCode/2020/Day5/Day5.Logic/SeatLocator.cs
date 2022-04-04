namespace AdventOfCode2020.Day5.Logic
{
    public class SeatLocator
    {
        private readonly string[] _seatCodes;
        private List<int> _orderedIds;
        private IEnumerable<int> _possibleValues;
        private IEnumerable<int> _missingIds;

        public int SeatId { get; private set; }

        public SeatLocator(string[] seatCodes)
        {
            _seatCodes = seatCodes;
            _orderedIds = new List<int>();
            _possibleValues = new List<int>();
            _missingIds = new List<int>();
            FindSeatId();
        }

        private void FindSeatId()
        {
            ObtainIdsInAscendingOrder();
            ObtainPossibleIds();
            CalculateSeatId();
        }

        private void ObtainIdsInAscendingOrder() =>
            _orderedIds = _seatCodes
                .Select(p => new Seat(p).Id)
                .OrderBy(p => p)
                .ToList();

        private void ObtainPossibleIds() =>
            _possibleValues = Enumerable.Range(_orderedIds[0], _orderedIds[^1]);

        private void CalculateSeatId()
        {
            FindMissingIds();
            FindMissingIdWithPresentPreviousAndNextIds();
        }

        private void FindMissingIdWithPresentPreviousAndNextIds()
        {
            var possibleSolutions = new List<int>();

            foreach (var missingId in _missingIds)
            {
                if (_orderedIds.Contains(missingId - 1) && _orderedIds.Contains(missingId + 1))
                {
                    possibleSolutions.Add(missingId);
                }
            }

            SeatId = possibleSolutions.Single();
        }

        private void FindMissingIds() =>
            _missingIds = _possibleValues.Except(_orderedIds);
    }
}