using System;
using System.Collections.Generic;

namespace Algorithms_Data_Structures
{
    public class TreeNode
    {
        public Guid Identifier { private set; get; }
        public object Data;
        public List<TreeNode> Childrens { private set; get; }

        public TreeNode()
        {
            Identifier = Guid.NewGuid();
            Childrens = new List<TreeNode>();
        }

        public void Add(TreeNode node)
        {
            Childrens.Add(node);
        }

        public bool Remove(Guid identifier)
        {
            var node = Childrens.Find((node) => node.Identifier == identifier);
            if (node == null) return false;
            return Childrens.Remove(node);
        }
    }
}
