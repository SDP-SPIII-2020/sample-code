// Binary Search Tree

using System;
using System.Collections.Generic;

namespace Dependencies
{
    // exceptions used in either Tree or Node

    // generic over type of value in each node
    public class Node<T> where T : IComparable
    {
        // Private member-variables
        private T _data;
        private Node<T> _left;
        private Node<T> _right;

        // delegates used in this class
        public delegate T TreeMapperDelegate(T t);

        // constructors
        public Node() : this(default(T), null, null)
        {
        }

        public Node(T x) : this(x, null, null)
        {
        }

        public Node(T x, Node<T> left, Node<T> right)
        {
            _data = x;
            Left = left;
            Right = right;
        }

        // properties accessing fields
        public T Value
        {
            get => _data;
            set => _data = value;
        }

        public Node<T> Left
        {
            get => _left;
            set => _left = value;
        }

        public Node<T> Right
        {
            get => _right;
            set => _right = value;
        }

        // -----------------------------------------------------------------------------
        // basic operations on Nodes
        public void Insert(T x)
        {
            if (Value.CompareTo(x) < 0)
            {
                if (Right == null)
                {
                    Right = new Node<T>(x);
                }
                else
                {
                    Right.Insert(x);
                }
            }
            else
            {
                if (Left == null)
                {
                    Left = new Node<T>(x);
                }
                else
                {
                    Left.Insert(x);
                }
            }
        }

        public bool Find(T x)
        {
            if (Value.CompareTo(x) == 0)
            {
                return true;
            }

            if (Value.CompareTo(x) >= 0) return Left != null && Left.Find(x);
            return Right != null && Right.Find(x);
        }

        /* generic depth-first traversal */
        public LinkedList<T> dfs()
        {
            var result = new LinkedList<T>();
            DfsAux(result);
            return result;
        }

        private void DfsAux(LinkedList<T> accum)
        {
            Left?.DfsAux(accum);

            accum.AddLast(Value);
            Right?.DfsAux(accum);
        }

        // -----------------------------------------------------------------------------
        // higher-order functions over trees
        public void MapTree(TreeMapperDelegate f)
        {
            Value = f(Value);
            Left?.MapTree(f);

            Right?.MapTree(f);
        }

        public override string ToString() => ToStringIndent(0);

        public string ToStringIndent(int n)
        {
            var str = "";
            for (var i = 0; i < n; i++)
            {
                str += " ";
            }

            return str + _data + "\n" +
                   ((Left == null) ? str + " ." + "\n" : Left.ToStringIndent(n + 1)) +
                   ((Right == null) ? str + " ." + "\n" : Right.ToStringIndent(n + 1));
        }
    }
}