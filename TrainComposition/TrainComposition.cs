using System;
using System.Collections.Generic;

namespace TrainComposition;

public class TrainComposition
{
    private readonly List<int> _wagons;

    public TrainComposition() => _wagons = new List<int>();

    public void AttachWagonFromLeft(int wagonId) => _wagons.Insert(0, wagonId);

    public void AttachWagonFromRight(int wagonId) => _wagons.Add(wagonId);

    public int DetachWagonFromLeft()
    {
        var wagon = _wagons[0];
        _wagons.RemoveAt(0);
        return wagon;
    }

    public int DetachWagonFromRight()
    {
        var wagon = _wagons[^1];
        _wagons.RemoveAt(_wagons.Count - 1);
        return wagon;
    }
/*
    public static void Main(string[] args)
    {
        TrainComposition train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
        Console.WriteLine(train.DetachWagonFromRight()); // 7 
        Console.WriteLine(train.DetachWagonFromLeft()); // 13
    }*/
}
