using System;
using System.Collections;

namespace Parallel04
{
    public sealed class Tree<T> where T : IComparable
    {
        public Tree() => Root = null;

        public void Clear() => Root = null;

        public Node<T> Root { get; private set; }

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

        public override string ToString() => Root == null ? "<empty>" : Root.ToStringIndent(0);

        public void Print(Fixity how)
        {
            IEnumerator iter;
            string str;
            switch (how)
            {
                case Fixity.Prefix:
                    iter = new PrefixEnumerator(this);
                    str = "PrefixEnumerator";
                    break;
                case Fixity.Infix:
                    iter = new InfixEnumerator(this);
                    str = "InfixEnumerator";
                    break;
                case Fixity.Postfix:
                    iter = new PostfixEnumerator(this);
                    str = "PostfixEnumerator";
                    break;
                default:
                    iter = new InfixEnumerator(this);
                    str = "InfixEnumerator";
                    break;
            }

            Console.Write("Flatten tree using " + str + " : [");
            if (iter.MoveNext())
            {
                Console.Write("{0}", iter.Current);
            }

            while (iter.MoveNext())
            {
                Console.Write(",{0}", iter.Current);
            }

            Console.WriteLine("]\n");
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

        private IEnumerator GetEnumerator() => (IEnumerator) new PrefixEnumerator(this);

        private class PrefixEnumerator : IEnumerator
        {
            private Node<T> _currNode;
            private readonly Node<T> _root;
            private readonly Stack _stack;
            public const string Name = "PrefixEnumerator";

            public PrefixEnumerator() =>
                throw new TreeException("PrefixEnumerator: Missing argument to constructor");

            public PrefixEnumerator(Tree<T> t)
            {
                _currNode = null; // NB: needs to start with -1; 
                _root = t.Root;
                _stack = new Stack();
            }

            // go up in the tree, and find the next node
            private bool Unwind()
            {
                if (_stack.Count == 0)
                {
                    // we are done
                    _currNode = null;
                    return false;
                }
                else
                {
                    var parent = (Node<T>) this._stack.Pop();
                    if (parent.Left == _currNode)
                    {
                        // I am a left child
                        if (parent.Right != null)
                        {
                            // and there is a right sub-tree
                            _stack.Push((object) parent);
                            _currNode = parent.Right; // pick it as next
                        }
                        else
                        {
                            _currNode = parent; // otw, go one step up and unwind further
                            return Unwind();
                        }
                    }
                    else if (parent.Right == _currNode)
                    {
                        // I am a right child
                        _currNode = parent; // otw, go one step up and unwind further
                        return Unwind();
                    }
                    else
                    {
                        throw new TreeException(
                            $"Ill-formed spine during Unwind(): node {parent} should be a parent of {_currNode}");
                    }

                    return true;
                }
            }

            public bool MoveNext()
            {
                // both sub-trees haven't been traversed, yet
                if (_currNode == null)
                {
                    _currNode = this._root;
                    return true;
                }

                if (_currNode.Left != null)
                {
                    _stack.Push((object) _currNode);
                    _currNode = _currNode.Left;
                    return true;
                }

                if (_currNode.Right != null)
                {
                    _stack.Push((object) _currNode);
                    _currNode = _currNode.Right;
                    return true;
                }

                // I am a leaf
                return (Unwind());
            }

            public void Reset() => _currNode = null;

            public object Current => _currNode.Value;
        }
        
        // -------------------------------------------------------
        // IEnumerator implementation 
        // This does a depth-first, in-fix traversal of the tree
        // see http://msdn.microsoft.com/en-us/library/78dfe2yb.aspx

        private class InfixEnumerator : IEnumerator
        {
            private Node<T> _currNode;
            private readonly Node<T> _root;
            private readonly Stack _stack;
            public const string Name = "InfixEnumerator";

            public InfixEnumerator() =>
                throw new TreeException("InfixEnumerator: Missing argument to constructor");

            public InfixEnumerator(Tree<T> t)
            {
                _currNode = null; // NB: needs to start with -1; 
                _root = t.Root;
                _stack = new Stack();
            }

            // go up in the tree, and find the next node
            private bool Unwind()
            {
                if (_stack.Count == 0)
                {
                    // we are done
                    _currNode = null;
                    return false;
                }

                var parent = (Node<T>) this._stack.Pop();
                if (parent.Left == _currNode)
                {
                    // I am a left child
                    _currNode = parent;
                    return true;
                }
                else
                {
                    _currNode = parent; // otw, go one step up and unwind further
                    return Unwind();
                }
            }

            // go down to left-most node in this tree
            private void LeftMost(Node<T> node)
            {
                if (node.Left != null)
                {
                    _stack.Push(node);
                    LeftMost(node.Left);
                }
                else
                {
                    _stack.Push(node);
                }
            }

            private bool EnterTree(Node<T> node)
            {
                // need to traverse both sub-trees
                LeftMost(node); // fills stack
                if (_stack.Count == 0)
                {
                    return false;
                }
                else
                {
                    _currNode = (Node<T>) _stack.Pop();
                    return true;
                }
            }

            public bool MoveNext()
            {
                if (_currNode == null)
                {
                    return (EnterTree(_root));
                }
                else
                {
                    // left sub-tree has been processed
                    if (_currNode.Right == null) return Unwind();
                    _stack.Push(_currNode);
                    return (EnterTree(_currNode.Right));
                }
            }

            public void Reset() => _currNode = null;

            public object Current => this._currNode.Value;
        }

        private class PostfixEnumerator : IEnumerator
        {
            private Node<T> _currNode;
            private Node<T> _root;
            private Stack _stack;
            public const string Name = "PostfixEnumerator";

            public PostfixEnumerator(Node<T> currNode, Node<T> root, Stack stack)
            {
                _currNode = currNode;
                _root = root;
                _stack = stack;
                throw new TreeException("PostfixEnumerator: Missing argument to constructor");
            }

            public PostfixEnumerator(Tree<T> t, Node<T> currNode, Node<T> root, Stack stack)
            {
                _currNode = currNode;
                _root = root;
                _stack = stack;
                throw new TreeException("PostfixEnumerator: Not implemented");
            }

            public PostfixEnumerator(Tree<T> tree) => throw new TreeException("PostfixEnumerator: Not implemented");

            public bool MoveNext() => throw new TreeException("PostfixEnumerator: Not implemented");

            public void Reset() => throw new TreeException("PostfixEnumerator: Not implemented");

            public object Current => throw new TreeException("PostfixEnumerator: Not implemented");
        }
    }
}