namespace Day16.Logic
{
    public class VersionSumVisitor
    {
        public long Sum { get; private set; }

        public void Visit(LiteralPacket packet) =>
            Sum += packet.Version;

        public void Visit(OperatorPacket operatorPacket)
        {
            Sum += operatorPacket.Version;
            operatorPacket.SubPackets.ForEach(p => p.Accept(this));
        }
    }
}