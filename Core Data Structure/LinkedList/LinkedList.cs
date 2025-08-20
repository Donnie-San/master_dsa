namespace LinkedListDemo
{
    public class LinkedList
    {
        public Node? Head { get; private set; }
        public Node? Tail { get; private set; }
        public int Count { get; private set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        // Push Methods
        public void PushHead(int value)
        {
            var newNode = new Node(value);

            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
            }

            Count++;
        }

        public void PushTail(int value)
        {
            var newNode = new Node(value);

            if (Tail == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Prev = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }

            Count++;
        }

        public bool PushAfter(int target, int value)
        {
            if (Head == null)
                return false;

            Node? current = Head;
            while (current != null && current.Value != target)
            {
                current = current.Next;
            }

            if (current == null)
                return false;

            var newNode = new Node(value);
            newNode.Prev = current;
            newNode.Next = current.Next;

            if (current.Next != null)
            {
                current.Next.Prev = newNode;
            }
            else
            {
                Tail = newNode;
            }

            current.Next = newNode;
            Count++;
            return true;
        }

        // Pop Methods
        public int? PopHead()
        {
            if (Head == null)
                return null;

            int value = Head.Value;

            if (Head.Next == null)
            {
                Head = Tail = null;
            }
            else
            {
                Head = Head.Next;
                if (Head != null)
                    Head.Prev = null;
            }

            Count--;
            return value;
        }

        public int? PopTail()
        {
            if (Tail == null)
                return null;

            int value = Tail.Value;

            if (Tail.Prev == null)
            {
                Head = Tail = null;
            }
            else
            {
                Tail = Tail.Prev;
                if (Tail != null)
                    Tail.Next = null;
            }

            Count--;
            return value;
        }

        public int? PopMiddle(int value)
        {
            if (Head == null)
                return null;

            Node? current = Head;
            while (current != null && current.Value != value)
            {
                current = current.Next;
            }

            if (current == null)
                return null;

            if (current == Head)
                return PopHead();
            if (current == Tail)
                return PopTail();

            int removedValue = current.Value;

            if (current.Prev != null)
                current.Prev.Next = current.Next;

            if (current.Next != null)
                current.Next.Prev = current.Prev;

            Count--;
            return removedValue;
        }

        // Sorting
        public void BubbleSort()
        {
            if (Head == null || Head.Next == null)
                return;

            bool swapped;
            do
            {
                swapped = false;
                Node? current = Head;

                while (current?.Next != null)
                {
                    if (current.Value > current.Next.Value)
                    {
                        int temp = current.Value;
                        current.Value = current.Next.Value;
                        current.Next.Value = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }

        public void SelectionSort()
        {
            for (Node? start = Head; start != null; start = start.Next)
            {
                Node min = start;
                for (Node? current = start.Next; current != null; current = current.Next)
                {
                    if (current.Value < min.Value)
                        min = current;
                }

                int temp = start.Value;
                start.Value = min.Value;
                min.Value = temp;
            }
        }

        public void InsertionSort()
        {
            if (Head == null || Head.Next == null)
                return;

            Node? sortedHead = null;
            Node? current = Head;

            while (current != null)
            {
                Node? next = current.Next;
                current.Prev = current.Next = null;
                sortedHead = InsertSorted(sortedHead, current);
                current = next;
            }

            Head = sortedHead;
            Tail = Head;
            while (Tail?.Next != null)
            {
                Tail = Tail.Next;
            }
        }

        private Node InsertSorted(Node? sortedHead, Node newNode)
        {
            if (sortedHead == null || newNode.Value < sortedHead.Value)
            {
                newNode.Next = sortedHead;
                if (sortedHead != null)
                    sortedHead.Prev = newNode;
                return newNode;
            }

            Node current = sortedHead;
            while (current.Next != null && current.Next.Value < newNode.Value)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            if (current.Next != null)
                current.Next.Prev = newNode;

            current.Next = newNode;
            newNode.Prev = current;

            return sortedHead;
        }

        // Searching
        public Node? LinearSearch(int target)
        {
            Node? current = Head;
            while (current != null)
            {
                if (current.Value == target)
                    return current;
                current = current.Next;
            }
            return null;
        }

        private Node? GetNodeAt(int index)
        {
            if (index < 0 || index >= Count)
                return null;

            Node? current = Head;
            int i = 0;
            while (current != null && i < index)
            {
                current = current.Next;
                i++;
            }
            return current;
        }

        public Node? BinarySearch(int target)
        {
            int left = 0;
            int right = Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                Node? midNode = GetNodeAt(mid);

                if (midNode == null)
                    return null;

                if (midNode.Value == target)
                    return midNode;
                else if (midNode.Value < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }

        // Utility
        public string ToStringForward()
        {
            var output = new System.Text.StringBuilder();
            Node? current = Head;

            while (current != null)
            {
                output.Append($"{current.Value} ⇨ ");
                current = current.Next;
            }

            output.Append("null");
            return output.ToString();
        }

        public string ToStringBackward()
        {
            var output = new System.Text.StringBuilder();
            Node? current = Tail;

            while (current != null)
            {
                output.Append($"{current.Value} ⇦ ");
                current = current.Prev;
            }

            output.Append("null");
            return output.ToString();
        }
    }
}
