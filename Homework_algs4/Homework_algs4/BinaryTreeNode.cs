using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_algs4
{
    public enum Side
    {
        Left,
        Right
    }

    public class BinaryTreeNode
    {
        public int Data { get; set; }
        public BinaryTreeNode LeftNode { get; set; }
        public BinaryTreeNode RightNode { get; set; }
        public BinaryTreeNode ParentNode { get; set; }

        public Side? NodeSide =>
            ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.Left
                : Side.Right;
        public BinaryTreeNode(int data)
        {
            Data = data;
        }
    }
}
