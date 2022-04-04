using System;
using System.Linq;

namespace GravityFlip.Logic
{
    public sealed class GravityFlip
    {
        public class ChangeGravityFor
        {
            private readonly int[] _values;
            private Func<int[], int[]> _flipAction;

            public ChangeGravityFor(int[] values)
            {
                _values = values;
                _flipAction = _ => Array.Empty<int>();
            }

            public ChangeGravityFor To(char direction)
            {
                _flipAction = direction switch
                {
                    'R' => p => p.OrderBy(n => n).ToArray(),
                    'L' => p => p.OrderByDescending(n => n).ToArray(),
                    _ => throw new ArgumentOutOfRangeException(nameof(direction))
                };

                return this;
            }

            public GravityFlip Build() =>
                new(_values, _flipAction);
        }

        public static ChangeGravityFor For(int[] values) => new(values);

        private readonly int[] _values;
        private readonly Func<int[], int[]> _flipAction;

        public int[] NewConfiguration { get; set; }

        private GravityFlip(int[] values, Func<int[], int[]> flipAction)
        {
            _values = values;
            _flipAction = flipAction;

            NewConfiguration = Array.Empty<int>();
            Flip();
        }

        private void Flip() =>
            NewConfiguration = _flipAction(_values);
    }
}
