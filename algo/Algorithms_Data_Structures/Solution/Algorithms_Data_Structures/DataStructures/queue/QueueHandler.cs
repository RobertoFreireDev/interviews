using System;

namespace Algorithms_Data_Structures
{
    public class QueueHandler
    {
        private Queue queue;

        public QueueHandler()
        {
            queue = new Queue();
        }

        public bool Handle(Func<object,bool> lambda)
        {
            var nextItem = queue.GetNext();
            bool successfullyHandle = lambda(nextItem);

            if (successfullyHandle) queue.Remove();

            return successfullyHandle;
        }

        public void Add(object item)
        {
            queue.Add(item);
        }

        public object GetNext()
        {
            return queue.GetNext();
        }

        public int Size()
        {
            return queue.Size();
        }
    }
}
