namespace PrimeNumber.Logic
{
    public class Number
    {
        protected readonly int _value;
        public bool IsCorrect { get; protected set; }

        public Number(int value) =>
            _value = value;

        public bool CanBeClassifiedAs(IClassifier classifier) =>
            classifier.IsClassificationOf(_value);
    }
}