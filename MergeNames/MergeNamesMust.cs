namespace MergeNames.UnitTests;

public class MergeNamesMust
{
    [Fact]
    public void SolveExampleCorrectly()
    {
        string[] names1 = new string[] {"Ava", "Emma", "Olivia"};
        string[] names2 = new string[] {"Olivia", "Sophia", "Emma"};
        var names = Logic.MergeNames.UniqueNames(names1, names2);

        Assert.Equal(4, names.Length);
        Assert.Single(names, "Ava");
        Assert.Single(names, "Emma");
        Assert.Single(names, "Olivia");
        Assert.Single(names, "Sophia");
    }
}