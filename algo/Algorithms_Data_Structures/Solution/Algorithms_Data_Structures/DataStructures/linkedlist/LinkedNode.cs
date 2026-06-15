namespace Algorithms_Data_Structures
{
    public class LinkedNode
    {
        public object Data;
        public LinkedNode Next;

        public LinkedNode(object data, LinkedNode next = null)
        {
            Data = data;
            Next = next;
        }
    }
}
