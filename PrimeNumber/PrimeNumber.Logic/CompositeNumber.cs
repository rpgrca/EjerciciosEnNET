namespace PrimeNumber.Logic
{
    public class CompositeNumber : IClassifier
    {
        public bool IsClassificationOf(int _value)
        {
            if (_value <= 3)
            {
                return false;
            }

            return !new Number(_value).CanBeClassifiedAs(new PrimeNumber());
        }
    }
}
