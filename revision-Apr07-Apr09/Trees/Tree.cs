using System;
using System.Collections;
using System.Collections.Generic;

namespace Dependencies
{
    public sealed class Tree<T> where T : IComparable
    {
        internal Node<T> _root = null;

        public Tree()
        {
            _root = null;
        }

        public void Clear()
        {
            _root = null;
        }

        public Node<T> Root
        {
            get => _root;
            set => _root = value;
        }

        public void Insert(T x)
        {
            if (Root == null)
            {
                Root = new Node<T>(x);
            }
            else
            {
                Root.Insert(x);
            }
        }

        public bool Find(T x) => Root != null && Root.Find(x);

        // ToDo: implement the following method, which should be a class invariant
        // public bool WellFormedTree ( ) { ... }

        public LinkedList<T> Dfs() => Root.dfs();

        public override string ToString() => Root == null ? "<empty>" : Root.ToStringIndent(0);

        public void Print(Fixity how)
        {
            IEnumerator iter;
            string str;
            switch (how)
            {
                case Fixity.Prefix:
                    iter = new PrefixEnumerator<T>(this);
                    str = "PrefixEnumerator";
                    break;
                case Fixity.Infix:
                    iter = new InfixEnumerator<T>(this);
                    str = "InfixEnumerator";
                    break;
                case Fixity.Postfix:
                    iter = new PostfixEnumerator<T>(this);
                    str = "PostfixEnumerator";
                    break;
                default:
                    iter = new InfixEnumerator<T>(this);
                    str = "InfixEnumerator";
                    break;
            }

            Console.Write("Flatten tree using " + str + " : [");
            if (iter.MoveNext())
            {
                Console.Write($"{iter.Current}");
            }

            while (iter.MoveNext())
            {
                Console.Write($",{iter.Current}");
            }

            Console.WriteLine("]");
        }

        // -------------------------------------------------------
        // IEnumerator implementation 
        // This does a depth-first, pre-fix traversal of the tree
        // see http://msdn.microsoft.com/en-us/library/78dfe2yb.aspx

        public enum Fixity
        {
            Prefix,
            Infix,
            Postfix
        };


        // -------------------------------------------------------
        // IEnumerator implementation 
        // This does a depth-first, in-fix traversal of the tree
        // see http://msdn.microsoft.com/en-us/library/78dfe2yb.aspx

        private IEnumerator GetEnumerator() => new InfixEnumerator<T>(this);
    }
}