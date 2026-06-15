using Algorithms_Data_Structures;
using Xunit;

namespace tests.DataStructures
{
    public class LinkedListTest
    {
        [Fact]
        public void MustAppendsNodeToTheStartOfTheList()
        {
            var list = new LinkedList();
            list.InsertFirst(1);
            Assert.Equal(1,list.GetFirst().Data);
            list.InsertFirst(2);
            Assert.Equal(2,list.GetFirst().Data);
            Assert.Equal(1, list.GetFirst().Next.Data);
        }

        [Fact]
        public void MustReturnSizeOfList()
        {
            var list = new LinkedList();
            Assert.Equal(0, list.Size());
            list.InsertFirst(1);
            list.InsertFirst(1);
            list.InsertFirst(1);
            list.InsertFirst(1);
            Assert.Equal(4, list.Size());
        }

        [Fact]
        public void MustGetFirstNodeOfList()
        {
            var list = new LinkedList();
            Assert.Null(list.GetFirst()?.Data);
            list.InsertFirst(13);
            Assert.Equal(13, list.GetFirst()?.Data);
            list.InsertFirst(7);
            Assert.Equal(7, list.GetFirst()?.Data);
        }

        [Fact]
        public void MustGetLastNodeOfList()
        {
            var list = new LinkedList();
            Assert.Null(list.GetLast()?.Data);
            list.InsertFirst(13);
            Assert.Equal(13, list.GetLast()?.Data);
            list.InsertFirst(7);
            Assert.Equal(13, list.GetLast()?.Data);
        }

        [Fact]
        public void MustEmptyList()
        {
            var list = new LinkedList();
            list.InsertFirst(1);
            list.InsertFirst(1);
            list.InsertFirst(1);
            Assert.Equal(3, list.Size());
            list.Clear();
            Assert.Equal(0, list.Size());
            Assert.Null(list.GetLast()?.Data);
            Assert.Null(list.GetFirst()?.Data);
        }

        [Fact]
        public void MustRemoveFirst()
        {
            var list = new LinkedList();
            list.RemoveFirst();
            Assert.Equal(0, list.Size());
            Assert.Null(list.GetLast()?.Data);
            Assert.Null(list.GetFirst()?.Data);
            list.InsertFirst('a');
            list.RemoveFirst();
            Assert.Equal(0, list.Size());
            Assert.Null(list.GetLast()?.Data);
            Assert.Null(list.GetFirst()?.Data);
            list.InsertFirst('c');
            list.InsertFirst('b');
            list.InsertFirst('a');
            list.RemoveFirst();
            Assert.Equal('b', list.GetFirst()?.Data);
            Assert.Equal(2, list.Size());
        }

        [Fact]
        public void MustRemoveLast()
        {
            var list = new LinkedList();
            list.RemoveLast();
            Assert.Equal(0, list.Size());
            Assert.Null(list.GetLast()?.Data);
            Assert.Null(list.GetFirst()?.Data);
            list.InsertFirst('a');
            list.RemoveLast();
            Assert.Equal(0, list.Size());
            Assert.Null(list.GetLast()?.Data);
            Assert.Null(list.GetFirst()?.Data);
            list.InsertFirst('c');
            list.InsertFirst('b');
            list.InsertFirst('a');
            list.RemoveLast();
            Assert.Equal('b', list.GetLast()?.Data);
            Assert.Equal(2, list.Size());
        }

        [Fact]
        public void MustInsertLast()
        {
            var list = new LinkedList();
            list.InsertLast('a');
            Assert.Equal(1, list.Size());
            Assert.Equal('a', list.GetLast()?.Data);
            Assert.Equal('a', list.GetFirst()?.Data);
            list.InsertFirst('b');
            list.InsertLast('c');
            Assert.Equal(3, list.Size());
            Assert.Equal('c', list.GetLast()?.Data);
            Assert.Equal('b', list.GetFirst()?.Data);
            list.InsertLast('d');
            Assert.Equal(4, list.Size());
            Assert.Equal('d', list.GetLast()?.Data);
            Assert.Equal('b', list.GetFirst()?.Data);
        }

        [Fact]
        public void MustGetNodeAtIndex()
        {
            var list = new LinkedList();
            list.InsertLast('a');
            list.InsertLast('b');
            list.InsertLast('c');
            list.InsertLast('d');
            Assert.Equal('a', list.GetAt(0)?.Data);
            Assert.Equal('b', list.GetAt(1)?.Data);
            Assert.Equal('c', list.GetAt(2)?.Data);
            Assert.Equal('d', list.GetAt(3)?.Data);
            Assert.Equal(4, list.Size());
            Assert.Null(list.GetAt(4)?.Data);
        }

        [Fact]
        public void MustIterateEachNode()
        {
            var list = new LinkedList();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast('b');
            list.Map((node) =>
            {
                node.Data = node.Data + "12";
                return node;
            });
            Assert.Equal("112", list.GetAt(0)?.Data);
            Assert.Equal("212", list.GetAt(1)?.Data);
            Assert.Equal("b12", list.GetAt(2)?.Data);
        }

        [Fact]
        public void MustRemoveAt()
        {
            var list = new LinkedList();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);
            list.InsertLast(4);
            list.RemoveAt(1);
            Assert.Equal(1, list.GetAt(0)?.Data);
            Assert.Equal(3, list.GetAt(1)?.Data);
            Assert.Equal(4, list.GetAt(2)?.Data);
            Assert.Equal(3, list.Size());
            list.RemoveAt(0);
            Assert.Equal(3, list.GetAt(0)?.Data);
            Assert.Equal(4, list.GetAt(1)?.Data);
            Assert.Equal(2, list.Size());
            list.RemoveAt(1);
            Assert.Equal(3, list.GetAt(0)?.Data);
            Assert.Null(list.GetAt(1)?.Data);
            Assert.Equal(1, list.Size());
            list.RemoveAt(0);
            Assert.Null(list.GetAt(0)?.Data);
            Assert.Equal(0, list.Size());
        }

        [Fact]
        public void MustInsertAt()
        {
            var list = new LinkedList();
            list.InsertAt('a',0);
            Assert.Equal('a', list.GetAt(0)?.Data);
            Assert.Null(list.GetAt(1)?.Data);
            Assert.Equal(1, list.Size());
            list.InsertAt('b', 0);
            Assert.Equal('b', list.GetAt(0)?.Data);
            Assert.Equal('a', list.GetAt(1)?.Data);
            Assert.Equal(2, list.Size());
            list.InsertAt('c', 2);
            Assert.Equal('b', list.GetAt(0)?.Data);
            Assert.Equal('a', list.GetAt(1)?.Data);
            Assert.Equal('c', list.GetAt(2)?.Data);
            Assert.Equal(3, list.Size());
            list.InsertAt('d', 2);
            Assert.Equal('b', list.GetAt(0)?.Data);
            Assert.Equal('a', list.GetAt(1)?.Data);
            Assert.Equal('d', list.GetAt(2)?.Data);
            Assert.Equal('c', list.GetAt(3)?.Data);
            Assert.Equal(4, list.Size());
        }
    }
}