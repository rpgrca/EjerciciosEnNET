using System;
using System.Linq;

namespace GravityFlip.Logic
{
    public class GravityFlip
    {
        public class Builder
        {
            private int[] _values;
            private Func<int[], int[]> _turningDirection;

            public Builder()
            {
                _values = Array.Empty<int>();
                _turningDirection = _ => Array.Empty<int>();
            }

            public Builder For(int[] values)
            {
                _values = values;
                return this;
            }

            public Builder To(char direction)
            {
                _turningDirection = direction switch
                {
                    'R' => p => p.OrderBy(n => n).ToArray(),
                    'L' => p => p.OrderByDescending(n => n).ToArray(),
                    _ => throw new ArgumentOutOfRangeException(nameof(direction))
                };

                return this;
            }

            public GravityFlip Build()
            {
                return new GravityFlip(_values, _turningDirection);
            }
        }

        public int[] Configuration { get; set; }
        private readonly int[] _values;
        private readonly Func<int[], int[]> _turningDirection;

        private GravityFlip(int[] values, Func<int[], int[]> turningDirection)
        {
            Configuration = _values = values;
            _turningDirection = turningDirection;
        }

        public void Flip()
        {
            Configuration = _turningDirection.Invoke(_values);
       }
    }
}
