namespace LinkedListDemo
{
    public class Node
    {
        public int Value;
        public Node? Prev;
        public Node? Next;

        public Node(int value)
        {
            Value = value;
            Prev = null;
            Next = null;
        }
    }
}
