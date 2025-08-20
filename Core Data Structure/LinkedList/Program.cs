using System;

namespace LinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();

            Console.WriteLine("=== Push Operations ===");
            list.PushHead(30);
            list.PushTail(10);
            list.PushAfter(30, 20);
            list.PushTail(40);
            list.PushTail(25);
            list.PushTail(35);
            Console.WriteLine("Forward: " + list.ToStringForward());
            Console.WriteLine("Backward: " + list.ToStringBackward());
            Console.WriteLine($"Count: {list.Count}");

            Console.WriteLine("\n=== Pop Operations ===");
            Console.WriteLine($"PopHead: {list.PopHead()}");
            Console.WriteLine($"PopTail: {list.PopTail()}");
            Console.WriteLine($"PopMiddle (value 20): {list.PopMiddle(20)}");
            Console.WriteLine("Forward: " + list.ToStringForward());
            Console.WriteLine($"Count: {list.Count}");

            Console.WriteLine("\n=== Search Operations ===");
            var foundLinear = list.LinearSearch(25);
            Console.WriteLine($"LinearSearch(25): {(foundLinear != null ? "Found" : "Not Found")}");

            list.InsertionSort();
            Console.WriteLine("Sorted Forward: " + list.ToStringForward());
            var foundBinary = list.BinarySearch(25);
            Console.WriteLine($"BinarySearch(25): {(foundBinary != null ? "Found" : "Not Found")}");

            Console.WriteLine("\n=== Sorting Tests ===");
            list.PushTail(5);
            list.PushTail(50);
            list.PushTail(15);
            Console.WriteLine("Before BubbleSort: " + list.ToStringForward());
            list.BubbleSort();
            Console.WriteLine("After BubbleSort: " + list.ToStringForward());

            list.SelectionSort();
            Console.WriteLine("After SelectionSort: " + list.ToStringForward());

            list.InsertionSort();
            Console.WriteLine("After InsertionSort: " + list.ToStringForward());

            Console.WriteLine("\n=== Final Summary ===");
            Console.WriteLine("Forward: " + list.ToStringForward());
            Console.WriteLine("Backward: " + list.ToStringBackward());
            Console.WriteLine($"Count: {list.Count}");
        }
    }
}