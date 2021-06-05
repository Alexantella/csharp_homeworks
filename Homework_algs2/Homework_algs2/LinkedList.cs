using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_algs2
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }
    class LinkedList
    {
        private Node head;

        public void GetCount()
        {
            Node current = head;

            int count = 1;

            while (current != null)
            {
                count++;
                current = current.NextNode;
            }

            Console.WriteLine(current.Value);
        }

        public void PrintAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.NextNode;
            }
        }

        public void AddNode(int value)
        {
            var node = new Node { Value = value };

            if (head == null)
            {
                head = node;
            }
            else
            {
                var current = head;
                while (current.NextNode != null)
                {
                    current = current.NextNode;
                }
                current.NextNode = node;
                node.PrevNode = current;
            }
        }

        public void AddNodeAfter(Node node, int value)
        {
            Node current = head;

            for (int i = 1; i <= value; i++)
            {
                if (i == value)
                {
                    node.PrevNode = current;
                    node.NextNode = current.NextNode;
                    current.NextNode = node;
                }

                if(i > value + 1)
                {
                    current.PrevNode = current.PrevNode.PrevNode;
                    current.NextNode = current.NextNode.NextNode;
                }

                current.PrevNode = current;
                current = current.NextNode;

                if (current.NextNode == null)
                {
                    break;
                }
            }
        }

        public void RemoveNode(int value)
        {
            if(value == 1)
            {
                head = head.NextNode;
                head.PrevNode = null;
                return;
            }

            Node current = head;
            int i = 1;

            while (current.NextNode != null)
            {
                if (i + 1 == value)
                {
                    current.NextNode = current.NextNode.NextNode;

                    if (current.NextNode != null)
                    {
                        current.NextNode.PrevNode = current.NextNode;
                    } 
                    else
                    {
                        break;
                    }
                }

                current = current.NextNode;
                i++;
            }
        }

        public void RemoveNode(Node node)
        {
            if (head == node)
            {
                head = head.NextNode;
                head.PrevNode = null;
                node.NextNode = null;
            }

            Node current = head;

            while (current.NextNode != null)
            {
                if (current.NextNode == node)
                {
                    current.NextNode = node.NextNode;
                    current.PrevNode = node.PrevNode;
                }

                if(current.NextNode == null)
                {
                    break;
                }

                current = current.NextNode;
            }
        }

        public Node FindNode(int searchValue)
        {
            Node current = head;
            int i = 1;

            while (current.NextNode != null)
            {
                if (i == searchValue)
                {
                    return current;
                }

                current = current.NextNode;
                i++;
            }

            return null;
        }
    }
}
