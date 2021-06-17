using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_algs4
{
    class BinaryTree
    {
        public BinaryTreeNode RootNode { get; set; }

        /*
         * The main method for adding nodes
         */
        public void Add(BinaryTreeNode node)
        {
            if (RootNode == null)
            {
                this.RootNode = node;
            } else
            {
                this.RootNode = this.InsertNode(this.RootNode, node);
            }
        }

        /*
         * Reload this one method for just make things easier
         */
        public void Add(int data)
        {
            Add(new BinaryTreeNode(data));
        }

        /*
         * Find node use its value
         */
        public BinaryTreeNode FindNode(int data, BinaryTreeNode startWithNode = null)
        {
            startWithNode ??= RootNode;

            return (data == startWithNode.Data)
                ? startWithNode
                : data < startWithNode.Data
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(data, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(data, startWithNode.RightNode);
        }

        /*
         * Method that ptints tree as... tree. Uses spicial class for beautify
         */
        public void PrintTreeAsTree()
        {
            BTreePrinter.Print(RootNode);
        }

        /*
         * Recursion height counting.
         * Should be rewrite on a staff like "previous path" or struct property, at least.
         * 'Cause eats too much, but who cares?
         */
        private int GetHeight(BinaryTreeNode node)
        {
            int height = 1;

            if(node != null)
            {
                int left = this.GetHeight(node.LeftNode);
                int right = this.GetHeight(node.RightNode);
                int maximum = Math.Max(left, right);
                height = maximum + 1;
            }

            return height;
        }

        /*
         * Return balance for two child trees of node
         */
        private int CheckBalance(BinaryTreeNode node) 
            => node != null
            ? this.GetHeight(node.LeftNode) - this.GetHeight(node.RightNode)
            : 0;

        /*
         * Main class for inserting node. Do some magic with balancing tree
         */
        private BinaryTreeNode InsertNode(BinaryTreeNode currentNode, BinaryTreeNode node)
        {
            if (currentNode == null)
            {
                currentNode = node;
                return currentNode;
            }
            else if (node.Data.CompareTo(currentNode.Data) < 0)
            {
                node.ParentNode = currentNode;
                currentNode.LeftNode = this.InsertNode(currentNode.LeftNode, node);
                currentNode = this.BalanceTree(currentNode);
            }
            else if (node.Data.CompareTo(currentNode.Data) > 0)
            {
                node.ParentNode = currentNode;
                currentNode.RightNode = this.InsertNode(currentNode.RightNode, node);
                currentNode = this.BalanceTree(currentNode);
            }

            return currentNode;
        }

        /*
         * Blances subtrees and makes our structure perfect... technically.
         */
        private BinaryTreeNode BalanceTree(BinaryTreeNode currentNode)
        {
            // Check balance first
            int balanceFactor = this.CheckBalance(currentNode);

            // If balance keep itself in bay (n < abs(2)) - do nothing
            if(balanceFactor == 0 || Math.Abs(balanceFactor) == 1)
            {
                return currentNode;
            }

            // Rotations depend on trees balance value, yeah. 
            if (balanceFactor > 1)
            {
                if (this.CheckBalance(currentNode.LeftNode) > 0)
                {
                    currentNode = this.LeftLeftRotation(currentNode);
                }
                else
                {
                    currentNode = this.LeftRightRotation(currentNode);
                }
            }
            else if (balanceFactor < 1)
            {
                if (this.CheckBalance(currentNode.RightNode) > 0)
                {
                    currentNode = this.RightLeftRotation(currentNode);
                }
                else
                {
                    currentNode = this.RightRightRotation(currentNode);
                }
            }

            return currentNode;
        }

        /*
         * Right right rotation. Move child right node to the right.
         * Use it when balance for current parent is lesser than -1, and left node embalance right.
         */
        private BinaryTreeNode RightRightRotation(BinaryTreeNode currentNode)
        {
            if (currentNode == null)
                return currentNode;

            BinaryTreeNode pivot = currentNode?.RightNode;
            currentNode.RightNode = pivot?.LeftNode;

            if(pivot == null)
                    return currentNode;

            if (currentNode.RightNode != null)
                currentNode.RightNode.ParentNode = currentNode;

            pivot.LeftNode = currentNode;
            pivot.LeftNode.ParentNode = pivot;

            return pivot;
        }

        /*
         * So called double rotation (RL)
         * Use it when balance for current parent is lesser than -1, and right node embalance left.
         */
        private BinaryTreeNode RightLeftRotation(BinaryTreeNode currentNode)
        {
            BinaryTreeNode pivot = currentNode.RightNode;
            currentNode.RightNode = this.RightRightRotation(pivot);

            return this.RightRightRotation(currentNode);
        }

        /*
         * So called double rotation (LR).
         * Use it when balance for current parent is bigger than 1, and right node embalance left.
         */
        private BinaryTreeNode LeftRightRotation(BinaryTreeNode currentNode)
        {
            BinaryTreeNode pivot = currentNode.LeftNode;
            currentNode.LeftNode = this.LeftLeftRotation(pivot);

            return this.LeftLeftRotation(currentNode);
        }

        /*
         * Left left rotation. Move child left node to the left
         * Use it when balance for current parent is bigger than 1, and left node embalance right.
         */
        private BinaryTreeNode LeftLeftRotation(BinaryTreeNode currentNode)
        {
            if (currentNode == null)
                return currentNode;

            BinaryTreeNode pivot = currentNode?.LeftNode;
            currentNode.LeftNode = pivot?.RightNode;

            if (pivot == null)
                return currentNode;

            if(currentNode.LeftNode != null)
                currentNode.LeftNode.ParentNode = currentNode;

            pivot.RightNode = currentNode;
            pivot.RightNode.ParentNode = pivot;

            return pivot;
        }
    }
}
