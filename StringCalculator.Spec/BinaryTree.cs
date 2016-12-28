using System;

namespace StringCalculator.Spec
{
    internal class BinaryTree
    {
        private NodeT root;
        public BinaryTree()
        {
            root = null;
        }

        public void add(NodeT node)
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                add(root, node);
            }
        }

        public void add(NodeT rt, NodeT node)
        {
            if (node.Value < rt.Value)
            {
                if (rt.Left == null)
                {
                    rt.Left = node;
                }
                else
                {
                    add(rt.Left, node);
                }
            }
            else if (node.Value > rt.Value)
            {
                if (rt.Right == null)
                {
                    rt.Right = node;
                }
                else
                {
                    add(rt.Right,node);
                }
            }
        }

        public int[] GetStats()
        {
            int []stats = new int[2];
            if (root == null)
            {
                stats[0] = 0;
                stats[1] = 0;
            }
            else
            {
                stats[0] = getMax(root);
                stats[1] = getMin(root);
            }
            return stats;
        }

        private int getMin(NodeT node)
        {
            if (node.Left == null)
            {
                return node.Value;
            }
            return getMin(node.Left);
        }

        private int getMax(NodeT node)
        {
            if (node.Right == null)
            {
                return node.Value;
            }
            return getMax(node.Right);
        }
    }
}