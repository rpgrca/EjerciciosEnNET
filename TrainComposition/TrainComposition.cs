using System;
using System.Collections.Generic;

namespace TrainComposition;

public class TrainComposition
{
    private const int CAPACITY = 1000001;

    private readonly int[] _wagons;
    private int _head;
    private int _tail;

    public TrainComposition()
    {
        _wagons = new int[CAPACITY];
        _head = CAPACITY / 2;
        _tail = _head + 1;
    }

    public void AttachWagonFromLeft(int wagonId)
    {
        _wagons[_head--] = wagonId;
    }

    public void AttachWagonFromRight(int wagonId)
    {
        _wagons[_tail++] = wagonId;
    }

    public int DetachWagonFromLeft()
    {
        return _wagons[++_head];
    }

    public int DetachWagonFromRight()
    {
        return _wagons[--_tail];
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
