using System;
using System.Collections.Generic;

public class TrainComposition
{
    public void AttachWagonFromLeft(int wagonId)
    {
        throw new NotImplementedException("Waiting to be implemented.");
    }

    public void AttachWagonFromRight(int wagonId)
    {
        throw new NotImplementedException("Waiting to be implemented.");
    }

    public int DetachWagonFromLeft()
    {
        throw new NotImplementedException("Waiting to be implemented.");
    }

    public int DetachWagonFromRight()
    {
        throw new NotImplementedException("Waiting to be implemented.");
    }

    public static void Main(string[] args)
    {
        TrainComposition train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
        Console.WriteLine(train.DetachWagonFromRight()); // 7 
        Console.WriteLine(train.DetachWagonFromLeft()); // 13
    }
}
