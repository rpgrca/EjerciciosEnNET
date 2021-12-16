namespace Day16.Logic
{
    public class Parser
    {
        private readonly string _bits;

        public Packet ParsedPacket { get; private set; }
        public int Consumed { get; private set; }

        public Parser(string bits)
        {
            _bits = bits;
            Parse();
        }

        private void Parse()
        {
            if (IsFinalPadding())
            {
                Consumed = _bits.Length;
            }
            else
            {
                ParsedPacket = PacketFactory.Create(_bits);
                Consumed = ParsedPacket.Consumed;
            }
        }

        private bool IsFinalPadding() =>
            string.IsNullOrEmpty(_bits.Replace("0", string.Empty));
    }
}