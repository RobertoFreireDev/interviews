using System.Collections.Generic;
using System.Linq;

namespace Algorithms_Data_Structures
{
    public class Queue
    {
        private List<object> array;

        public Queue() {
            array = new List<object>();
        }

        public void Add(object item)
        {
            array.Add(item);
        }

        public void Remove()
        {
            array.RemoveAt(0);
        }

        public object GetNext()
        {
            return array.First();
        }

        public int Size()
        {
            return array.Count;
        }
    }
}
