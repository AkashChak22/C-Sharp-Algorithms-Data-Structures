using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        // Return the number of elements in the stack
        public int Count { get => _list.Count; }

        // Check if the stack is empty
        public bool IsEmpty { get => Count == 0; }

        // Create an empty stack
        public Stack() { }

        // Create a stack with an initial element
        public Stack(T firstElem)
        {
            Push(firstElem);
        }

        // Push an element on the stack
        public void Push(T elem)
        {
            _list.AddLast(elem);
        }

        // Pop an element off the stack
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new Exception("Stack is empty");
            }
            else
            {
                T lastElem = _list.Last.Value;
                _list.RemoveLast();
                return lastElem;
            }
        }

        // Peek the element at the top of the stack without removing it
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Stack is empty");
            }
            else
            {
                return _list.Last.Value;
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
