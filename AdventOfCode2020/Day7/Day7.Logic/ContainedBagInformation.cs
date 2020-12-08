namespace AdventOfCode2020.Day7.Logic
{
    public record ContainedBagInformation(string Description, int Amount)
    {
        public static ContainedBagInformation Create(string containedDescription)
        {
            var parsedInformation = containedDescription.Trim().Split(" ");
            return new ContainedBagInformation(
                string.Join(" ", parsedInformation[1..3]),
                int.Parse(parsedInformation[0]));
        }
    }
}