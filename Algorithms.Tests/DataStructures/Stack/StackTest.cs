using System;

using Xunit;
using Algorithms.DataStructures.Stack;

namespace Algorithms.Tests.DataStructures.Stack
{
    public class StackTest
    {
        private Stack<int> _stack;

        public StackTest()
        {
            _stack = new Stack<int>();
        }

        [Fact]
        public void IsEmpty_EmptyStackShouldWork()
        {
            Assert.True(_stack.IsEmpty);
            Assert.Equal(0, _stack.Count);
        }

        [Fact]
        public void IsEmpty_NonEmptyStackShouldWork()
        {
            _stack.Push(0);
            Assert.False(_stack.IsEmpty);
            Assert.Equal(1, _stack.Count);
        }

        [Fact]
        public void Pop_EmptyStackShouldFail()
        {
            Assert.Throws<Exception>(() => _stack.Pop());
        }

        [Fact]
        public void Peek_EmptyStackShouldFail()
        {
            Assert.Throws<Exception>(() => _stack.Peek());
        }

        [Fact]
        public void Push_AnyStackShouldWork()
        {
            Assert.True(_stack.IsEmpty);
            _stack.Push(1);
            Assert.Equal(1, _stack.Count);

            Assert.False(_stack.IsEmpty);
            _stack.Push(3);
            Assert.Equal(2, _stack.Count);
        }

        [Fact]
        public void Pop_NonEmptyStackShouldWork()
        {
            _stack.Push(10);
            _stack.Push(20);
            _stack.Push(30);

            Assert.Equal(3, _stack.Count);
            Assert.Equal(30, _stack.Pop());
            Assert.Equal(2, _stack.Count);
        }

        [Fact]
        public void Peek_NonEmptyStackShouldWork()
        {
            _stack.Push(10);
            _stack.Push(20);
            _stack.Push(30);

            Assert.Equal(3, _stack.Count);
            Assert.Equal(30, _stack.Peek());
            Assert.Equal(3, _stack.Count);
        }
    }
}
