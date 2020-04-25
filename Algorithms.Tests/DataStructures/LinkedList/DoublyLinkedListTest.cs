using System;
using System.Text;

using Algorithms.DataStructures.LinkedList;
using Xunit;

namespace Algorithms.Tests.DataStructures.LinkedList
{
    public class DoublyLinkedListTest
    {
        DoublyLinkedList<int> list;

        // Setup
        public DoublyLinkedListTest()
        {
            list = new DoublyLinkedList<int>();
        }

        [Fact]
        public void IsEmpty_EmptyListShouldWork()
        {
            Assert.True(list.IsEmpty());
        }

        [Fact]
        public void IsEmpty_NonEmptyListShouldWork()
        {
            list.Add(0);
            Assert.False(list.IsEmpty());
        }

        [Fact]
        public void AddAt_NegativeIndexShouldFail()
        {
            Assert.Throws<ArgumentException>("index", () => list.AddAt(10, -1));
        }

        [Fact]
        public void AddAt_LargerThanSizeIndexShouldFail()
        {
            Assert.Throws<ArgumentException>("index", () => list.AddAt(10, 4));
        }

        [Fact]
        public void RemoveFirst_EmptyListShouldFail()
        {
            Assert.Throws<Exception>(() => list.RemoveFirst());
        }

        [Fact]
        public void RemoveLast_EmptyListShouldFail()
        {
            Assert.Throws<Exception>(() => list.RemoveLast());
        }

        [Fact]
        public void PeekFirst_EmptyListShouldFail()
        {
            Assert.Throws<Exception>(() => list.PeekFirst());
        }

        [Fact]
        public void PeekLast_EmptyListShouldFail()
        {
            Assert.Throws<Exception>(() => list.PeekLast());
        }

        [Fact]
        public void AddFirst_ShouldWork()
        {
            list.AddFirst(3);
            Assert.Equal(1, list.Size());
            list.AddFirst(5);
            Assert.Equal(2, list.Size());
        }

        [Fact]
        public void AddLast_ShouldWork()
        {
            list.AddLast(3);
            Assert.Equal(1, list.Size());
            list.AddLast(5);
            Assert.Equal(2, list.Size());
        }

        [Fact]
        public void AddAt_ShouldWork()
        {
            list.AddAt(10, 0);
            Assert.Equal(1, list.Size());
            list.AddAt(0, 1);
            Assert.Equal(2, list.Size());
            list.AddAt(15, 1);
            Assert.Equal(3, list.Size());
            list.AddAt(10, 0);
            Assert.Equal(4, list.Size());
        }

        [Fact]
        public void RemoveFirst_ShouldWork()
        {
            list.AddFirst(4);
            Assert.Equal(4, list.RemoveFirst());
            Assert.True(list.IsEmpty());
        }

        [Fact]
        public void RemoveLast_ShouldWork()
        {
            list.AddLast(4);
            Assert.Equal(4, list.RemoveLast());
            Assert.True(list.IsEmpty());
        }

        [Fact]
        public void PeekFirst_ShouldWork()
        {
            // 5
            list.AddFirst(5);
            Assert.Equal(5, list.PeekFirst());
            Assert.Equal(1, list.Size());

            // 5 -> 6
            list.AddLast(6);
            Assert.Equal(5, list.PeekFirst());
            Assert.Equal(2, list.Size());

            // 8 -> 5 -> 6
            list.AddFirst(8);
            Assert.Equal(8, list.PeekFirst());
            Assert.Equal(3, list.Size());

            // 5 -> 6
            list.RemoveFirst();
            Assert.Equal(5, list.PeekFirst());
            Assert.Equal(2, list.Size());

            // 5
            list.RemoveLast();
            Assert.Equal(5, list.PeekFirst());
            Assert.Equal(1, list.Size());
        }

        [Fact]
        public void PeekLast_ShouldWork()
        {
            // 5
            list.AddFirst(5);
            Assert.Equal(5, list.PeekLast());
            Assert.Equal(1, list.Size());

            // 5 -> 6
            list.AddLast(6);
            Assert.Equal(6, list.PeekLast());
            Assert.Equal(2, list.Size());

            // 8 -> 5 -> 6
            list.AddFirst(8);
            Assert.Equal(6, list.PeekLast());
            Assert.Equal(3, list.Size());

            // 5 -> 6
            list.RemoveFirst();
            Assert.Equal(6, list.PeekLast());
            Assert.Equal(2, list.Size());

            // 5
            list.RemoveLast();
            Assert.Equal(5, list.PeekLast());
            Assert.Equal(1, list.Size());
        }

        [Fact]
        public void Remove_ShouldWork()
        {
            DoublyLinkedList<string> chars = new DoublyLinkedList<string>();

            chars.Add("a");
            chars.Add("b");
            chars.Add("c");
            chars.Add("d");
            chars.Add("e");

            chars.Remove("d");
            chars.Remove("a");
            chars.Remove("e");
            chars.Remove("c");
            chars.Remove("b");

            Assert.True(list.IsEmpty());
        }

        [Fact]
        public void RemoveAt_ShouldWork()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.RemoveAt(0);
            list.RemoveAt(2);
            Assert.Equal(2, list.PeekFirst());
            Assert.Equal(3, list.PeekLast());
            list.RemoveAt(1);
            list.RemoveAt(0);
            Assert.True(list.IsEmpty());
        }

        [Fact]
        public void Clear_ShouldWork()
        {
            list.Clear();
            Assert.True(list.IsEmpty());

            list.Add(1);
            list.Add(3);
            list.Add(2);
            Assert.Equal(3, list.Size());
            list.Clear();
            Assert.True(list.IsEmpty());

            list.Add(5);
            list.Add(4);
            list.Add(6);
            Assert.Equal(3, list.Size());
            list.Clear();
            Assert.True(list.IsEmpty());
        }

        [Fact]
        public void ToString_ShouldWork()
        {
            Assert.Equal("[  ]", list.ToString());

            list.Add(10);
            list.Add(3);
            list.Add(2);
            Assert.Equal("[ 10, 3, 2 ]", list.ToString());

            list.Remove(3);
            list.AddLast(5);
            Assert.Equal("[ 10, 2, 5 ]", list.ToString());
        }
    }
}
