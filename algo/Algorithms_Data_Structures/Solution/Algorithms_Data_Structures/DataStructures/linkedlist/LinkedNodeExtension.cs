using System;

namespace Algorithms_Data_Structures
{
    public static class LinkedNodeExtension
    {
        public static void Map(this LinkedList linkedList, Func<LinkedNode, LinkedNode> lambda)
        {
            LinkedNode currentNode = linkedList.GetFirst();

            while (currentNode != null)
            {
                currentNode = lambda(currentNode);
                if (currentNode.Next == null) return;
                currentNode = currentNode.Next;
            }
        }
    }
}
