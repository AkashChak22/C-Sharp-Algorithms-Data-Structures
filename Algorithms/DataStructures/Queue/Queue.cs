using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures.Queue
{
    public class Queue<T> : IEnumerable<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        // Return the number of elements in the queue
        public int Count { get => _list.Count; }

        // Check if the queue is empty
        public bool IsEmpty { get => Count == 0; }

        // Create an empty queue
        public Queue() { }

        // Create a queue with an initial element
        public Queue(T firstElem)
        {
            Enqueue(firstElem);
        }

        // Add an element to the end of the queue
        public void Enqueue(T elem)
        {
            _list.AddLast(elem);
        }

        // Remove an element from the front of the queue
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new Exception("Queue is empty");
            }
            else
            {
                T firstElem = _list.First.Value;
                _list.RemoveFirst();
                return firstElem;
            }
        }

        // Peek the element at the front of the queue without removing it
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Queue is empty");
            }
            else
            {
                return _list.First.Value;
            }
        }

        // Implement the GetEnumerator() method to support foreach iteration
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
