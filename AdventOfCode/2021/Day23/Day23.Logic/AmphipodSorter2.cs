using System;
using System.Collections.Generic;

namespace Day23.Logic
{
    public interface IMovementFrom2
    {
        IMovementTo To(int node);
    }

    public interface IMovementTo
    {
        bool AndStopOnFail();
        bool OrReturnBack();
        void OrFail();
    }

    public class AmphipodSorter2 : IMovementFrom2, IMovementTo
    {
        private readonly IMapInformation _mapInformation;

        private readonly int[] _amphipodeTypes;
        private int _currentAmphipod;
        private int _currentTarget;
        private Action<AmphipodSorter2, int> _onFinalPositionCallback;
        private int _count;
        private int _minimumCost;

        public int TotalCost { get; private set; }

        public static AmphipodSorter2 CreateShortMapSorter(string data) => new(new ShortMap(data));
        public static AmphipodSorter2 CreateLongMapSorter(string data) => new(new LongMap(data));

        private AmphipodSorter2(IMapInformation mapInformation)
        {
            _mapInformation = mapInformation;
            _minimumCost = int.MaxValue;
            _amphipodeTypes = new int[] { 1, 10, 100, 1000 };
        }

        public int[] GetAmphipods() => _mapInformation.GetStartingAmphipods();

        public void OnFinalPositionReached(Action<AmphipodSorter2, int> onFinalPositionCallback) =>
            _onFinalPositionCallback = onFinalPositionCallback;

        public override string ToString() => _mapInformation.ToString();

        public IMovementFrom2 MoveAmphipodFrom(int node)
        {
            if (!_mapInformation.IsThereAnAmphipodAt(node))
            {
                throw new ArgumentException("No amphipod there");
            }

            _currentAmphipod = node;
            return this;
        }

        public IMovementTo To(int target)
        {
            _currentTarget = target;
            return this;
        }

        public void WalkWith(IEnumerable<int> amphipods, List<(int From, int To)> stack)
        {
            _count++;

            if (TotalCost > _minimumCost)
            {
                return;
            }

            if (_mapInformation.HasFinalPositionBeenReached())
            {
                if (TotalCost < _minimumCost)
                {
                    _minimumCost = TotalCost;
                    _onFinalPositionCallback(this, _count);
                }
            }

            foreach (var amphipod in amphipods)
            {
                if (! _mapInformation.IsThereAnAmphipodAt(amphipod))
                {
                    continue;
                }

                foreach (var option in _mapInformation.AvailableMovementOptions(amphipod))
                {
                    if (! _mapInformation.CanAmphipodMoveTo(amphipod, option))
                    {
                        continue;
                    }

                    var totalCostSoFar = TotalCost;
                    var anyPossiblePath = MoveAmphipodFrom(amphipod).To(option).OrReturnBack();
                    if (anyPossiblePath)
                    {
                        stack.Add((amphipod, option));
                        WalkWith(CalculateAmphipodsAbleToMove(), stack);

                        var reset = stack[^1];
                        stack.Remove(reset);

                        _mapInformation.MoveFrom(reset.From, reset.To);
                        TotalCost = totalCostSoFar;
                    }
                }
            }
        }

        private IEnumerable<int> CalculateAmphipodsAbleToMove()
        {
            for (var index = 0; index < _mapInformation.GetRoomLength(); index++)
            {
                if (_mapInformation.IsThereAnAmphipodAt(index))
                {
                    if (_mapInformation.InHomeArea(index))
                    {
                        if (_mapInformation.InOwnHomeArea(index))
                        {
                            if (_mapInformation.ForeignersInOwnHomeArea(index))
                            {
                                yield return index;
                            }
                        }
                        else
                        {
                            yield return index;
                        }
                    }
                    else
                    {
                        if (_mapInformation.IsHomeAreaBeingCompleted(index))
                        {
                            yield return index;
                        }
                    }
                }
            }
        }

        public bool AndStopOnFail()
        {
            var currentLocation = _currentAmphipod;

            if (_mapInformation.GetNextStep(currentLocation, _currentTarget) != -1)
            {
                var nextRoom = _mapInformation.GetNextStep(currentLocation, _currentTarget);
                if (_mapInformation.GetRoomAt(nextRoom) == '.')
                {
                    var totalCost = _amphipodeTypes[_mapInformation.GetRoomAt(currentLocation) - 'A'];
                    TotalCost += totalCost;
                    _mapInformation.MoveFrom(nextRoom, currentLocation);

                    if (! MoveAmphipodFrom(nextRoom).To(_currentTarget).AndStopOnFail())
                    {
                        if (CanStayInThisPosition(nextRoom))
                        {
                            return true;
                        }
                        else
                        {
                            _currentAmphipod = currentLocation;
                            _mapInformation.MoveFrom(currentLocation, nextRoom);
                            TotalCost -= totalCost;
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public void OrFail()
        {
            if (!OrReturnBack())
            {
                throw new ArgumentException("Could not complete path");
            }
        }

        public bool OrReturnBack()
        {
            var currentLocation = _currentAmphipod;
            var totalCostSoFar = TotalCost;
            var originalPosition = currentLocation;

            while (_mapInformation.GetNextStep(currentLocation, _currentTarget) != -1)
            {
                var nextRoom = _mapInformation.GetNextStep(currentLocation, _currentTarget);

                if (_mapInformation.GetRoomAt(nextRoom) == '.')
                {
                    TotalCost += _amphipodeTypes[_mapInformation.GetRoomAt(currentLocation) - 'A'];
                    _mapInformation.MoveFrom(nextRoom, currentLocation);
                    currentLocation = nextRoom;
                    //System.IO.File.AppendAllText("./shortmap.txt", _mapInformation.ToString() + $"     {_count} - {TotalCost}\n\n");
                }
                else
                {
                    if (TotalCost != totalCostSoFar)
                    {
                        TotalCost = totalCostSoFar;
                        _mapInformation.MoveFrom(originalPosition, currentLocation);
                    }

                    return false;
                }
            }

            if (! CanStayInThisPosition(currentLocation))
            {
                if (TotalCost != totalCostSoFar)
                {
                    TotalCost = totalCostSoFar;
                    _mapInformation.MoveFrom(originalPosition, currentLocation);
                }

                return false;
            }

            return true;
        }

        private bool CanStayInThisPosition(int currentLocation)
        {
            if (_mapInformation.AtHomeAreaEntrance(currentLocation))
            {
                return false;
            }

            if (_mapInformation.InHomeArea(currentLocation))
            {
                if (!_mapInformation.InOwnHomeArea(currentLocation))
                {
                    return false;
                }
                else
                {
                    if (_mapInformation.StrangersAtHome(currentLocation))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}