using System.Collections.Generic;

namespace Day12.Logic
{
    public sealed partial class PathFinding
    {
        private interface ISmallCaveBehaviour
        {
            void Do(PathFinding pathFinding, string from, List<string> walkedThrough, ISmallCaveBehaviour smallCaveSearch);
        }

        private class WalkOnlyOnceInSmallCave : ISmallCaveBehaviour
        {
            public void Do(PathFinding pathFinding, string from, List<string> walkedThrough, ISmallCaveBehaviour smallCave)
            {
            }
        }

        private class RepeatUpToOneSmallCave : ISmallCaveBehaviour
        {
            private readonly ISmallCaveBehaviour _noRepeat = new WalkOnlyOnceInSmallCave();

            public void Do(PathFinding pathFinding, string from, List<string> walkedThrough, ISmallCaveBehaviour smallCave) =>
                pathFinding.WalkThisCave(from, walkedThrough, _noRepeat);
        }
    }
}