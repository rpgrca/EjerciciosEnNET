using static Account.Account;

namespace Account.UnitTests;

public class AccountMust
{
    [Fact]
    public void ExampleCase() =>
        Assert.False(Access.Writer.HasFlag(Access.Delete));

    [Fact]
    public void WriterAccessHasCorrectAnswer()
    {
        Assert.True(Access.Writer.HasFlag(Access.Submit));
        Assert.True(Access.Writer.HasFlag(Access.Modify));
    }

    [Fact]
    public void EditorAccessHasCorrectAnswer()
    {
        Assert.True(Access.Editor.HasFlag(Access.Delete));
        Assert.True(Access.Editor.HasFlag(Access.Publish));
        Assert.True(Access.Editor.HasFlag(Access.Comment));
    }

    [Fact]
    public void OwnerAccessHasCorrectAnswer()
    {
        Assert.True(Access.Owner.HasFlag(Access.Writer));
        Assert.True(Access.Owner.HasFlag(Access.Editor));
    }
}