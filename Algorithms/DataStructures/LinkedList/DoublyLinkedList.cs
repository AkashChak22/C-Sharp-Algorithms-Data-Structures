/*
 * A doubly linked list implementation
 * 
 * Author: Akash Chakrabarti
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DataStructures.LinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private int size = 0;
        public Node<T> head { get; set; }
        public Node<T> tail { get; set; }

        // Internal node class to represent data
        public class Node<T>
        {
            public T data;
            public Node<T> prev, next;

            public Node(T data, Node<T> prev, Node<T> next)
            {
                this.data = data;
                this.prev = prev;
                this.next = next;
            }

            public override string ToString()
            {
                return Convert.ToString(data);
            }
        }

        // Empty this linked list, O(n)
        public void Clear()
        {
            Node<T> trav = head;
            while (trav != null)
            {
                Node<T> next = trav.next;
                trav.prev = trav.next = null;
                trav.data = default(T);
                trav = next;
            }

            head = tail = trav = null;
            size = 0;
        }

        // Return the size of this linked list
        public int Size()
        {
            return size;
        }

        // Is this linked list empty
        public bool IsEmpty()
        {
            return Size() == 0;
        }

        // Add an element to the linked list
        // by default at the end, O(1)
        public void Add(T elem)
        {
            AddLast(elem);
        }

        // Add a node to the end of the linked list, O(1)
        public void AddLast(T elem)
        {
            if (IsEmpty())
            {
                head = tail = new Node<T>(elem, null, null);
            } else
            {
                tail.next = new Node<T>(elem, tail, null);
                tail = tail.next;
            }
            size++;
        }

        // Add a node to the beginning of the linked list, O(1)
        public void AddFirst(T elem)
        {
            if (IsEmpty())
            {
                head = tail = new Node<T>(elem, null, null);
            } else
            {
                head.prev = new Node<T>(elem, null, head);
                head = head.prev;
            }
            size++;
        }

        // Add a node at a specified index, O(n)
        public void AddAt(T elem, int index)
        {
            if (index < 0 || index > Size())
            {
                throw new ArgumentException("Illegal index", "index");
            }

            if (index == 0)
            {
                AddFirst(elem);
                return;
            }

            if (index == size)
            {
                AddLast(elem);
                return;
            }

            Node<T> temp = head;
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.next;
            }

            Node<T> newNode = new Node<T>(elem, temp, temp.next);
            temp.next.prev = newNode;
            temp.next = newNode;

            size++;
        }

        // Check the value of the first node, if it exists, O(1)
        public T PeekFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List");
            }
            return head.data;
        }

        // Check the value of the last node, if it exists, O(1)
        public T PeekLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List");
            }
            return tail.data;
        }

        // Remove the first value at the head of the linked list, O(1)
        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty list");
            }

            // Extract the data at the head and move
            // the head pointer forward one node
            T data = head.data;
            head = head.next;
            size--;

            // If the list is empty set the tail to null
            if (IsEmpty())
            {
                tail = null;
            }
            // Do a memory cleanup of the previous node
            else
            {
                head.prev = null;
            }

            return data;
        }

        // Remove the last value at the tail of the linked list, O(1)
        public T RemoveLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty list");
            }

            // Extract the data at the tail and move
            // the tail pointer back one node
            T data = tail.data;
            tail = tail.prev;
            size--;

            // If the list is empty set the head to null
            if (IsEmpty())
            {
                head = null;
            }
            // Do a memory cleanup of the next node
            else
            {
                tail.next = null;
            }

            return data;
        }

        // Remove an arbitrary node from the linked list, O(1)
        private T Remove(Node<T> node)
        {
            // If the node to remove is at the head or tail of the list
            // handle those separately
            if (node.prev == null)
            {
                return RemoveFirst();
            }

            if (node.next == null)
            {
                return RemoveLast();
            }

            // Make the pointers of adjacent nodes skip over 'node'
            node.next.prev = node.prev;
            node.prev.next = node.next;

            // Temporarily store the data we want to return
            T data = node.data;

            // Do cleanup of node
            node.data = default(T);
            node = node.prev = node.next = null;

            size--;

            return data;
        }

        // Remove a node at a particular index, O(n)
        public T RemoveAt(int index)
        {
            // Make sure the index provided is valid
            if (index < 0 || index >= Size())
            {
                throw new ArgumentException("Illegal index", "index");
            }

            int i;
            Node<T> trav;

            // Search from the front of the list
            if (index < size / 2)
            {
                for (i = 0, trav = head; i < index; i++)
                {
                    trav = trav.next;
                }
            }
            // Search from the end of the list
            else
            {
                for (i = size - 1, trav = tail; i > index; i--)
                {
                    trav = trav.prev;
                }
            }

            return Remove(trav);
        }

        // Remove a particular value in the linked list, O(n)
        public bool Remove(Object obj)
        {
            Node<T> trav;

            // Search for null object
            if (obj == null)
            {
                for (trav = head; trav != null; trav = trav.next)
                {
                    if (trav.data == null)
                    {
                        Remove(trav);
                        return true;
                    }
                }
            }
            // Search for non-null object
            else
            {
                for (trav = head; trav != null; trav = trav.next)
                {
                    if (obj.Equals(trav.data))
                    {
                        Remove(trav);
                        return true;
                    }
                }
            }

            return false;
        }

        // Find the index of a particular value in the linked list, O(n)
        public int IndexOf(Object obj)
        {
            Node<T> trav;
            int index;

            // Search for null object
            if (obj == null)
            {
                for (trav = head, index = 0; trav != null; trav = trav.next, index++)
                {
                    if (trav.data == null)
                    {
                        return index;
                    }
                }
            }
            // Search for non null object
            else
            {
                for (trav = head, index = 0; trav != null; trav = trav.next, index++)
                {
                    if (obj.Equals(trav.data)) 
                    {
                        return index;
                    }
                }
            }

            return -1;
        }

        // Check if a value is contained within the linked list
        public bool Contains(Object obj)
        {
            return IndexOf(obj) != -1;
        }

        // Get string representation of the list
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            
            Node<T> trav = head;
            while (trav != null)
            {
                sb.Append(Convert.ToString(trav.data));

                // If not last node add ','
                if (trav.next != null)
                {
                    sb.Append(", ");
                }

                trav = trav.next;
            }

            sb.Append(" ]");
            return sb.ToString();
        }

        // Implement GetEnumerator method to support foreach iteration
        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    // Enumerator for DoublyLinkedList
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private DoublyLinkedList<T> linkedlist;
        DoublyLinkedList<T>.Node<T> trav;
        DoublyLinkedList<T>.Node<T> prev;

        public DoublyLinkedListEnumerator(DoublyLinkedList<T> linkedlist) 
        {
            this.linkedlist = linkedlist;
            trav = this.linkedlist.head;
            prev = trav.prev;
        }

        public T Current
        {
            get
            {
                return prev.data;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            if (trav == null)
            {
                return false;
            } 
            else
            {
                prev = trav;
                trav = trav.next;
                return true;
            }
        }

        public void Dispose()
        {
            linkedlist = null;
            trav = null;
            prev = null;
        }

        public void Reset()
        {
            trav = linkedlist.head;
            prev = null;
        }
    }
}
