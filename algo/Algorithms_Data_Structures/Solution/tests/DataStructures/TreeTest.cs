using Algorithms_Data_Structures;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace tests.DataStructures
{
    public class TreeTest
    {
        private readonly ITestOutputHelper output;

        public TreeTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void MustRemoveNestedNode()
        {
            /*  ------ Tree ------
             *  ------ A (Root) --
             *  ---- D ----- E ---
             *   -- C - B -------- 
             *  ------------------
             *  ---- listNodes ---
             *  - A, D, E, C, B --
             *  ------------------
            */

            (var tree, var listNodes) = TreeUtil.GenerateTree();

            var nodesArrays = listNodes.ToArray();

            var result = tree.Remove(nodesArrays[nodesArrays.Length - 1].Identifier);

            var allNodes = tree.GetAll();

            foreach (var node in allNodes)
            {
                output.WriteLine(node.Data.ToString());
            }

            result.Should().BeTrue();

            allNodes.ToArray().Length.Should().Be(listNodes.Count - 1);
        }

        [Fact]
        public void MustRemoveNestedNode_SecondTest()
        {
            /*  ------ Tree ------
             *  ------ A (Root) --
             *  ---- D ----- E ---
             *   -- C - B -------- 
             *  ------------------
             *  ---- listNodes ---
             *  - A, D, E, C, B --
             *  ------------------
            */

            (var tree, var listNodes) = TreeUtil.GenerateTree();

            var nodesArrays = listNodes.ToArray();

            var result = tree.Remove(nodesArrays[1].Identifier);

            var allNodes = tree.GetAll();

            foreach (var node in allNodes)
            {
                output.WriteLine(node.Data.ToString());
            }

            result.Should().BeTrue();
            allNodes.ToArray().Length.Should().Be(listNodes.Count - 3);
        }
    }

    public class TreeNodeTest
    {
        private readonly ITestOutputHelper output;

        public TreeNodeTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void MustAddNode()
        {
            TreeNode treeNodeA = new TreeNode();
            treeNodeA.Data = "A";
            TreeNode treeNodeB = new TreeNode();
            treeNodeB.Data = "B";
            TreeNode treeNodeC = new TreeNode();
            treeNodeC.Data = "C";

            treeNodeA.Add(treeNodeB);
            treeNodeA.Add(treeNodeC);

            Assert.Equal(2, treeNodeA.Childrens.Count);
        }

        [Fact]
        public void MustGetAll()
        {
            (var tree, var expectedResult) = TreeUtil.GenerateTree();
            
            var result = tree.GetAll();

            foreach (var node in result)
            {
                output.WriteLine(node.Data.ToString());
            }

            Assert.Equal(expectedResult,result);
        }

        [Fact]
        public void MustRemoveNode()
        {
            TreeNode treeNodeA = new TreeNode();
            treeNodeA.Data = "A";
            TreeNode treeNodeB = new TreeNode();
            treeNodeB.Data = "B";
            TreeNode treeNodeC = new TreeNode();
            treeNodeC.Data = "C";

            treeNodeA.Add(treeNodeB);
            treeNodeA.Add(treeNodeC);
            treeNodeA.Remove(treeNodeB.Identifier);

            Assert.Single(treeNodeA.Childrens);
            Assert.Equal(treeNodeC, treeNodeA.Childrens[0]);
        }        
    }

    public static class TreeUtil
    {
        public static Tuple<Tree, List<TreeNode>> GenerateTree()
        {
            Tree tree = new Tree();
            TreeNode treeNodeA = new TreeNode();
            treeNodeA.Data = "A";
            TreeNode treeNodeB = new TreeNode();
            treeNodeB.Data = "B";
            TreeNode treeNodeC = new TreeNode();
            treeNodeC.Data = "C";
            TreeNode treeNodeD = new TreeNode();
            treeNodeD.Data = "D";
            TreeNode treeNodeE = new TreeNode();
            treeNodeE.Data = "E";

            treeNodeA.Add(treeNodeD);
            treeNodeA.Add(treeNodeE);
            treeNodeD.Add(treeNodeC);
            treeNodeD.Add(treeNodeB);

            /*
             * --------------------------------
             * ---------- Tree ----------------
             * --------------------------------
             * -------- A (Root) --------------
             * ---- D ---------- E ------------
             * -- C - B -----------------------
             * --------------------------------
            */

            tree.Root = treeNodeA;

            var ListNodes = new List<TreeNode> {
                treeNodeA,
                treeNodeD,
                treeNodeE,
                treeNodeC,
                treeNodeB
            };

            return Tuple.Create(tree, ListNodes);
        }
    }
}
