namespace AdventOfCode2020.Day25.Logic
{
    public class Handshake
    {
        private readonly long _initialSubject;
        private long _loopSize;

        public long PublicKey { get; private set; }
        public long EncryptionKey { get; private set; }

        public Handshake(long loopSize)
        {
            _loopSize = loopSize;
            _initialSubject = 7;

            GeneratePublicKey();
        }

        private long ApplyLoopSizeTo(long initialValue)
        {
            var value = 1L;
            for (var index = 0; index < _loopSize; index++)
            {
                value *= initialValue;
                value %= 20201227;
            }

            return value;
        }

        public bool LoopSizeIs(long expectedLoopSize) =>
            _loopSize == expectedLoopSize;

        private void GeneratePublicKey() =>
            PublicKey = ApplyLoopSizeTo(_initialSubject);

        public void CalculateEncryptionKeyWith(long otherPublicKey) =>
            EncryptionKey = ApplyLoopSizeTo(otherPublicKey);

        public void CalculateLoopSizeWith(long publicKey)
        {
            var value = 1L;
            while (value != publicKey)
            {
                _loopSize++;
                value *= _initialSubject;
                value %= 20201227;
            }
        }
    }
}