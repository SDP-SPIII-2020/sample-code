using System;
using System.Collections;
using System.Collections.Generic;

namespace Dependencies
{
    internal class InfixEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private Node<T> _currNode;
        private readonly Node<T> _root;
        private readonly Stack _stack;
        private T _current;
        public const string Name = "InfixEnumerator";

        public InfixEnumerator()
        {
            throw new TreeException("InfixEnumerator: Missing argument to constructor");
        }

        public InfixEnumerator(Tree<T> t)
        {
            _currNode = null; // NB: needs to start with -1; 
            _root = t._root;
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

            var parent = (Node<T>) _stack.Pop();
            if (parent.Left == _currNode)
            {
                // I am a left child
                _currNode = parent;
                return true;
            }

            _currNode = parent; // otw, go one step up and unwind further
            return Unwind();
        }

        // go down to left-most node in this tree
        private void LeftMost(Node<T> node)
        {
            if (node.Left != null)
            {
                _stack.Push((object) node);
                LeftMost(node.Left);
            }
            else
            {
                _stack.Push((object) node);
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

            _currNode = (Node<T>) _stack.Pop();
            return true;
        }

        public bool MoveNext()
        {
            if (_currNode == null)
            {
                return (EnterTree(_root));
            }

            // left sub-tree has been processed
            if (_currNode.Right != null)
            {
                _stack.Push((object) _currNode);
                return (EnterTree(_currNode.Right));
            }

            // I am a leaf
            return (Unwind());
        }

        public void Reset() => _currNode = null;

        T IEnumerator<T>.Current => _current;

        public object Current => _currNode.Value;

        public void Dispose()
        {
        }
    }
}