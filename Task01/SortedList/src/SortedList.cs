namespace CSharpBasics.src
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

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
}
