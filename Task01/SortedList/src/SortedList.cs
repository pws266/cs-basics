using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpBasics
{
    // node for custom list
    class Node
    {
        public TestStruct Data { get; private set; }
        public Node Next { get; set; }

        public Node(TestStruct data)
        {
            Data = data;
        }
    }

    // custom sorted list
    public class SortedList : IEnumerable<TestStruct>
    {
        Node head;  // initial list node
        Node tail;  // final list node

        int size;  // nodes number in list

        // inserts new node in list performing ascending sorting on "Number" field
        public void Add(TestStruct data)
        {
            Node node = new Node(data);

            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                Node current = head;
                Node previous = null;

                // looking for node in list greater than new node
                while (current.Next != null && node.Data < current.Data)
                {
                    previous = current;
                    current = current.Next;
                }

                // inserting new node to list if greater node in list is found
                if (node.Data >= current.Data)
                {
                    if (previous == null)
                        head = node;
                    else
                        previous.Next = node;

                    node.Next = current;
                }
                // inserting new node in the end of the list if no greater element was found
                else
                {
                    tail = node;
                    current.Next = node;
                }
            }

            size++;
        }

        // returns sorted list size
        public int Size { get { return size; } }
        // returns "true" if sorted list is empty
        public bool IsEmpty { get { return size == 0; } }

        // implementing interface method for iterator usage in sorted list viewing via "foreach"
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        // implementing interface method for iterator usage in sorted list viewing via "foreach"
        IEnumerator<TestStruct> IEnumerable<TestStruct>.GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    // sorted list verification
    class VerifySortedList
    {
        public static void Main()
        {
            // creating sorted list instance
            SortedList list = new SortedList();

            // filling list instance and sorting data
            list.Add(TestStruct.Factory(10, "Lada Kalina"));
            list.Add(TestStruct.Factory(150, "Kia Sportage"));
            list.Add(TestStruct.Factory(25, "Kia Rio"));
            list.Add(TestStruct.Factory(70, "Renault Laguna"));
            list.Add(TestStruct.Factory(200, "Nissan Navaro"));
            list.Add(TestStruct.Factory(3, "Fiat Panda"));
            list.Add(TestStruct.Factory(45, "Opel Meriva"));

            // displaying sorted list content
            foreach (var item in list)
                // last argument invokes "item.ToString" method
                Console.WriteLine("Rent price: {0, 4}$ Model: {1}", item.Number, item);

            Console.WriteLine("\nList size: {0}", list.Size);
        }
    }
}
