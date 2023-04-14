using Xunit;

namespace TrainComposition;

public class TrainCompositionMust
{
    [Fact]
    public void ReturnFirstWagon_WhenTrainHasOneWagonDetachedFromLeft()
    {
        var train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        Assert.Equal(7, train.DetachWagonFromLeft());
    }

    [Fact]
    public void ReturnFirstWagon_WhenTrainHasOneWagonDetachedFromRight()
    {
        var train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        Assert.Equal(7, train.DetachWagonFromRight());
    }
}