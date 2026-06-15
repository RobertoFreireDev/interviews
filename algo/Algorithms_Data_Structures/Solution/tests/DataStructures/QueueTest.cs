using Algorithms_Data_Structures;
using Xunit;
using Xunit.Abstractions;

namespace tests.DataStructures
{
    public class QueueTest
    {
        private readonly ITestOutputHelper output;

        public QueueTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void MustAddItem()
        {
            Queue queue = new Queue();
            queue.Add('b');
            queue.Add('a');
            Assert.Equal(2, queue.Size());
        }

        [Fact]
        public void MustGetNext()
        {
            Queue queue = new Queue();
            queue.Add('b');
            queue.Add('a');            
            Assert.Equal('b', queue.GetNext());
            Assert.Equal('b', queue.GetNext());
        }

        [Fact]
        public void MustRemoveItem()
        {
            Queue queue = new Queue();
            queue.Add('b');
            queue.Add('a');
            queue.Remove();
            Assert.Equal('a', queue.GetNext());
            Assert.Equal(1, queue.Size());
        }

        [Fact]
        public void MustGetSize()
        {
            Queue queue = new Queue();
            Assert.Equal(0,queue.Size());
            queue.Add('b');
            queue.Add('a');
            queue.Add('c');
            queue.Size();
            Assert.Equal(3, queue.Size());
        }

        [Fact]
        public void MustHandleQueueSuccessfully()
        {
            QueueHandler queueHandler = new QueueHandler();
            queueHandler.Add("a");
            queueHandler.Add("b");
            queueHandler.Add("c");
            queueHandler.Handle((item) => {
                output.WriteLine("item: " + item);
                return true;
            });
            queueHandler.Handle((item) => {
                output.WriteLine("item: " + item);
                return true;
            });
            Assert.Equal(1, queueHandler.Size());
            Assert.Equal("c", queueHandler.GetNext());
        }

        [Fact]
        public void MustHandleQueueInFail()
        {
            QueueHandler queueHandler = new QueueHandler();
            queueHandler.Add("a");
            queueHandler.Add("b");
            queueHandler.Add("c");
            queueHandler.Handle((item) => {
                output.WriteLine("item: " + item);
                return false;
            });
            queueHandler.Handle((item) => {
                output.WriteLine("item: " + item);
                return false;
            });
            Assert.Equal(3, queueHandler.Size());
            Assert.Equal("a", queueHandler.GetNext());
        }
    }
}