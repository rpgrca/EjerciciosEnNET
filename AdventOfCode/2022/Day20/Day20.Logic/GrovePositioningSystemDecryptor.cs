namespace Day20.Logic;

public class GrovePositioningSystemDecryptor
{
    private string _input;
    private List<int> _values;

    private CircularList.CircularListNode[] _originalValues;
    public CircularList CircularList { get; private set; }
    public int SumOfThousands { get; private set; }

    public GrovePositioningSystemDecryptor(string input)
    {
        _input = input;
        _values = _input.Split("\n").Select(p => int.Parse(p)).ToList();

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
        for (var index = 0; index < _originalValues.Length; index++)
        {
            var currentNode = _originalValues[index];

            /*if (currentNode == CircularList.Head)
            {
                CircularList.MoveHeadToNext();
            }*/

            if (currentNode.Value > 0)
            {
                var newForwardLocation = currentNode;
                var counter = currentNode.Value;
                while (counter > 0)
                {
                    newForwardLocation = newForwardLocation.Next;
                    if (newForwardLocation != currentNode)
                    {
                        counter--;
                    }
                }

                if (currentNode != newForwardLocation.Next)
                {
                    var oldCurrentPrevious = currentNode.Previous;
                    var oldCurrentNext = currentNode.Next;
                    var newForwardLocationNext = newForwardLocation.Next;

                    oldCurrentPrevious.Next = oldCurrentNext;
                    oldCurrentNext.Previous = oldCurrentPrevious;

                    newForwardLocation.Next = currentNode;
                    newForwardLocationNext.Previous = currentNode;

                    currentNode.Previous = newForwardLocation;
                    currentNode.Next = newForwardLocationNext;
                }
            }
            else if (currentNode.Value < 0)
            {
                var newBackwardLocation = currentNode;
                var counter = -currentNode.Value;
                while (counter > 0)
                {
                    newBackwardLocation = newBackwardLocation.Previous;
                    if (newBackwardLocation != currentNode)
                    {
                        counter--;
                    }
                }

                if (newBackwardLocation.Previous != currentNode)
                {
                    var oldCurrentPrevious = currentNode.Previous;
                    var oldCurrentNext = currentNode.Next;

                    oldCurrentPrevious.Next = oldCurrentNext;
                    oldCurrentNext.Previous = oldCurrentPrevious;

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
