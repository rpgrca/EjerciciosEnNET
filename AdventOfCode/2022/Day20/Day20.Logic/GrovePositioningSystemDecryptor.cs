namespace Day20.Logic;

public class GrovePositioningSystemDecryptor
{
    private string _input;
    private List<long> _values;

    private CircularList.CircularListNode[] _originalValues;
    public CircularList CircularList { get; private set; }
    public long SumOfThousands { get; private set; }

    public GrovePositioningSystemDecryptor(string input, int decryptionKey = 1)
    {
        _input = input;
        _values = _input.Split("\n").Select(p => long.Parse(p) * decryptionKey).ToList();

        CircularList = new CircularList();
        foreach (var value in _values)
        {
            CircularList.AddLast(value);
        }

        _originalValues = new CircularList.CircularListNode[CircularList.Count];
        SetOriginalValues();
    }

    private void SetOriginalValues()
    {
        var index = 0;
        foreach (var node in CircularList)
        {
            _originalValues[index++] = node;
        }
    }

    public void Mix(int times)
    {
        while (times-- > 0)
        {
            for (var index = 0; index < _originalValues.Length; index++)
            {
                var currentNode = _originalValues[index];

                if (currentNode.Value > 0)
                {
                    var newForwardLocation = currentNode;
                    var oldCurrentPrevious = currentNode.Previous;
                    var oldCurrentNext = currentNode.Next;

                    oldCurrentPrevious.Next = oldCurrentNext;
                    oldCurrentNext.Previous = oldCurrentPrevious;

                    var counter = currentNode.Value;
                    while (counter > 0)
                    {
                        newForwardLocation = newForwardLocation.Next;
                        counter--;
                    }

                    var newForwardLocationNext = newForwardLocation.Next;
                    newForwardLocation.Next = currentNode;
                    newForwardLocationNext.Previous = currentNode;

                    currentNode.Previous = newForwardLocation;
                    currentNode.Next = newForwardLocationNext;
                }
                else if (currentNode.Value < 0)
                {
                    var newBackwardLocation = currentNode;
                    var oldCurrentPrevious = currentNode.Previous;
                    var oldCurrentNext = currentNode.Next;

                    oldCurrentPrevious.Next = oldCurrentNext;
                    oldCurrentNext.Previous = oldCurrentPrevious;

                    var counter = -currentNode.Value;
                    while (counter > 0)
                    {
                        newBackwardLocation = newBackwardLocation.Previous;
                        counter--;
                    }

                    var newBackwardLocationPrevious = newBackwardLocation.Previous;
                    newBackwardLocation.Previous = currentNode;
                    newBackwardLocationPrevious.Next = currentNode;

                    currentNode.Previous = newBackwardLocationPrevious;
                    currentNode.Next = newBackwardLocation;
                }
            }
        }

        var pointer = CircularList.Head;
        while (pointer.Value != 0)
        {
            pointer = pointer.Next;
        }

        var moves = 1000 % CircularList.Count;
        for (var index = 0; index < moves; index++)
        {
            pointer = pointer.Next;
        }

        SumOfThousands += pointer.Value;

        for (var index = 0; index < moves; index++)
        {
            pointer = pointer.Next;
        }

        SumOfThousands += pointer.Value;

        for (var index = 0; index < moves; index++)
        {
            pointer = pointer.Next;
        }

        SumOfThousands += pointer.Value;
    }
}
