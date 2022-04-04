namespace AdventOfCode2020.Day23.Logic
{
    public static class CircularLinkedList
    {
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current) =>
            current.Next ?? current.List.First;
    }
}