using System;

namespace Day16.Logic
{
    public class TransmissionDecoder
    {
        private readonly string _transmission;

        public TransmissionDecoder(string transmission)
        {
            if (string.IsNullOrWhiteSpace(transmission))
            {
                throw new ArgumentException("Invalid transmission");
            }

            _transmission = transmission;
        }
    }
}
