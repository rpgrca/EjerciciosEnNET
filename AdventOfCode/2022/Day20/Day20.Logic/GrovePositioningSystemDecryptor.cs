using System.Collections;
using System.Diagnostics;

namespace Day20.Logic;

[DebuggerDisplay("{Value}")]
public class CircularListNode
{
    private CircularListNode _next;
    private CircularListNode _previous;
    private CircularListNode _updatedNext;
    private CircularListNode _updatedPrevious;

    public int Value { get; }

    public CircularListNode Next
    {
        get => _next;
        set { _next = value; }
    }
    public CircularListNode Previous
    {
        get => _previous;
        set { _previous = value; }
    }

    public CircularListNode UpdatedNext
    {
        get => _updatedNext;
        set { _updatedNext = value; }
    }

    public CircularListNode UpdatedPrevious
    {
        get => _updatedPrevious;
        set { _updatedPrevious = value; }
    }

    public CircularListNode(int value, CircularListNode previous, CircularListNode next)
    {
        Value = value;
        _previous = _updatedPrevious = previous;
        _next = _updatedNext = next;
    }

    public CircularListNode(int value)
    {
        Value = value;
        _previous = _updatedPrevious = this;
        _next = _updatedNext = this;
    }

    public void MoveBetween(CircularListNode previous, CircularListNode next)
    {
        _updatedPrevious = previous;
        _updatedNext = next;
    }

    public void PlaceAfter(CircularListNode previous)
    {
        _updatedPrevious = previous;
        previous.PlaceBefore(this);
    }

    public void PlaceBefore(CircularListNode next)
    {
        _updatedNext = next;
        next.PlaceAfter(this);
    }

    public void Update()
    {
        _next = UpdatedNext;
        _previous = UpdatedPrevious;
    }
}


public class CircularList : IEnumerable<CircularListNode>
{
    public class CircularListEnumerator : IEnumerator<CircularListNode>
    {
        private readonly CircularList _list;
        private CircularListNode? _current;
        private int _currentIndex;

        public CircularListEnumerator(CircularList list)
        {
            _list = list;
            _current = _list.Head;
            _currentIndex = -1;
        }

        public CircularListNode Current => _current;

        object IEnumerator.Current => _current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_currentIndex < 0)
            {
                _current = _list.Head;
            }
            else
            {
                _current = _current.Next;
            }

            _currentIndex++;
            return _currentIndex < _list._count;
        }

        public void Reset()
        {
            _current = null;
            _currentIndex = -1;
        }
    }

    private CircularListNode _head;
    private CircularListNode _tail;
    public CircularListNode Head => _head;
    public CircularListNode Tail => _tail;
    private IEnumerable<CircularListNode> _elements;
    private int _count;

    public CircularList()
    {
        _elements = Array.Empty<CircularListNode>();
        _count = 0;
    }

    public void AddLast(int value)
    {
        if (Tail is null)
        {
            var newNode = new CircularListNode(value);
            _head = newNode;
            _tail = newNode;
            _elements = _elements.Append(Head);
        }
        else
        {
            var newNode = new CircularListNode(value);
            _tail.Next = newNode;
            newNode.Previous = _tail;

            _tail = newNode;
            newNode.Next = _head;
            _head.Previous = newNode;

            _elements = _elements.Append(newNode);
        }

        _count++;
    }

    public void FinishLoading()
    {
    }

    public void Mix(int amount)
    {
        for (var currentNode = Head; currentNode != Tail; currentNode = currentNode.Next)
        {
            if (currentNode.Value > 0)
            {
                var newForwardLocation = currentNode;
                var counter = currentNode.Value;
                while (counter > 0)
                {
                    newForwardLocation = newForwardLocation.Next;
                    counter--;
                }

                currentNode.PlaceAfter(newForwardLocation);
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

                currentNode.PlaceBefore(newBackwardLocation);
            }
        }

        foreach (var element in _elements)
        {
            element.Update();
        }
    }

    public IEnumerator<CircularListNode> GetEnumerator()
    {
        return new CircularListEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GrovePositioningSystemDecryptor
{
    private string _input;
    private List<int> _values;

    private (LinkedListNode<int>, int)[] _nodes;

    public List<int> OriginalValues => _values;
    public CircularList CircularList { get; private set; }

    public GrovePositioningSystemDecryptor(string input)
    {
        _input = input;
        _values = _input.Split("\n").Select(p => int.Parse(p)).ToList();
        _nodes = new (LinkedListNode<int>, int)[_values.Count];

        CircularList = new CircularList();
        foreach (var value in _values)
        {
            CircularList.AddLast(value);
        }
    }

    public void Mix(int times)
    {
        CircularList.Mix(times);
    }
}
