namespace Day13.Logic;

public class DistressSignalDecoder
{
    public int SumOfCorrectIndexes { get; }
    public int DecoderKey { get; }

    public DistressSignalDecoder(string input)
    {
        SumOfCorrectIndexes = 0;

        var packets = new List<INumber>();
        var index = 0;
        var lines = input.Split("\n");
        for (var counter = 0; counter < lines.Length; counter += 3)
        {
            index++;

            var numbersAbove = new NumbersParser(lines[counter]).Values;
            var numbersBelow = new NumbersParser(lines[counter + 1]).Values;

            if (numbersAbove.Compare(numbersBelow) < 0)
            {
                SumOfCorrectIndexes += index;
            }

            packets.Add(numbersAbove);
            packets.Add(numbersBelow);
        }

        var dividerPacket1 = new NumbersParser("[[2]]").Values;
        var dividerPacket2 = new NumbersParser("[[6]]").Values;
        packets.Add(dividerPacket1);
        packets.Add(dividerPacket2);

        for (var outer = 0; outer < packets.Count - 1; outer++)
        {
            for (var inner = outer + 1; inner < packets.Count; inner++)
            {
                if (packets[outer].Compare(packets[inner]) > 0)
                {
                    (packets[inner], packets[outer]) = (packets[outer], packets[inner]);
                }
            }
        }

        DecoderKey = 1;
        for (index = 0; index < packets.Count; index++)
        {
            if (packets[index].Compare(dividerPacket1) == 0)
            {
                DecoderKey *= index + 1;
            }
            else if (packets[index].Compare(dividerPacket2) == 0)
            {
                DecoderKey *= index + 1;
            }
        }
    }
}
