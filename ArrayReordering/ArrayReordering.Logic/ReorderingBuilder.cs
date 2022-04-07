namespace ArrayReordering.Logic;

public sealed partial class Reordering
{
    public class Builder
    {
        private IReorderAlgorithm _algorithm;
        private int[] _values;

        public Builder()
        {
            _algorithm = new FromBehindEveryOtherAlgorithm();
            _values = Array.Empty<int>();
        }

        public Builder Using(IReorderAlgorithm algorithm)
        {
            _algorithm = algorithm;
            return this;
        }

        public Builder Sorting(int[] values)
        {
            _values = values;
            return this;
        }

        public Reordering Build() => new(_values, _algorithm);
    }
}