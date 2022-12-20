using System.Collections;
using System.Diagnostics;

namespace Day20.Logic;

public class CircularList : IEnumerable<CircularList.CircularListNode>
{
    [DebuggerDisplay("{Value}")]
    public class CircularListNode
    {
        private CircularListNode _next;
        private CircularListNode _previous;

        public long Value { get; }

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

        public CircularListNode(long value, CircularListNode previous, CircularListNode next)
        {
            Value = value;
            _previous = previous;
            _next = next;
        }

        public CircularListNode(long value)
        {
            Value = value;
            _previous = this;
            _next = this;
        }
    }

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
    private int _count;

    public int Count => _count;

    public CircularList()
    {
        _count = 0;
    }

    public void AddLast(long value)
    {
        if (Tail is null)
        {
            var newNode = new CircularListNode(value);
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            var newNode = new CircularListNode(value);
            _tail.Next = newNode;
            newNode.Previous = _tail;

            _tail = newNode;
            newNode.Next = _head;
            _head.Previous = newNode;
        }

        _count++;
    }

    public IEnumerator<CircularListNode> GetEnumerator()
    {
        return new CircularListEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    internal void MoveHeadToNext()
    {
        var oldHead = _head;
        _head = _head.Next;
        _tail = oldHead;
    }

    public CircularListNode this[int index]
    {
        get
        {
            var pointer = _head;
            while (index-- > 0)
            {
                pointer = pointer.Next;
            }

            return pointer;
        }
    }
}
