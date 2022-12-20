namespace Day20.Logic;

public class GrovePositioningSystemDecryptor
{
    private string _input;
    private List<int> _values;

    private CircularList.CircularListNode[] _originalValues;
    public CircularList CircularList { get; private set; }

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

            if (currentNode == CircularList.Head)
            {
                CircularList.MoveHeadToNext();
            }

            if (currentNode.Value > 0)
            {
                var newForwardLocation = currentNode;
                var counter = currentNode.Value;
                while (counter > 0)
                {
                    newForwardLocation = newForwardLocation.Next;
                    counter--;
                }

//
//
//   1 * 2 * -3 * 3 * -2 * 0 * 4   currentNode.next antes era currentNode.Next ahora es newForwardLocation
//    \                            currentNode.previous antes era currentNode.previous ahora es currentNode.Next
//     \                           currentNode.Next.previous antes era currentNode ahora es currentNode.previous
//      \                          currentNode.Next.next antes era newForwardLocation ahora es currentNode
//   2 * 1 * -3 * 3 * -2 * 0 * 4   newForwardLocation.previous antes era 2 ahora es currentNode
//                                 4.next antes era currentNode ahora es 2

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
            else if (currentNode.Value < 0)
            {
                var newBackwardLocation = currentNode;
                var counter = -currentNode.Value;
                while (counter > 0)
                {
                    newBackwardLocation = newBackwardLocation.Previous;
                    counter--;
                }

//
//
// 1, 2, -1, -3, 0, 3, 4         currentNode.Previous antes era newBackwardLocation ahora es newBackwardLocation.Previous
//       /                       currentNode.Next antes era currentNode.Next ahora es newBackwardLocation
//      /                        newBackwardLocation.Previous antes era newBackwardLocation.Previous ahora es currentNode
//     /                         newBackwardLocation.Next antes era currentNode ahora es currentNode.Next
// 1, -1, 2, -3, 0, 3, 4, -2     curretnNode.Next.Previous antes era currentNode ahora es newBackwardLocation
//                               newBackwardLocation.Previous.Next antes era newBackwardLocation ahora es currentNode

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
}
