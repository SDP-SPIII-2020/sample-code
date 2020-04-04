using System;
using System.Collections;
using System.Collections.Generic;

namespace Dependencies
{
    internal class PrefixEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private Node<T> _currNode;
        private readonly Node<T> _root;
        private readonly Stack _stack;
        private T _current;
        public const string Name = "PrefixEnumerator";

        public PrefixEnumerator()
        {
            throw new TreeException("PrefixEnumerator: Missing argument to constructor");
        }

        public PrefixEnumerator(Tree<T> t)
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

        public bool MoveNext()
        {
            // both sub-trees haven't been traversed, yet
            if (_currNode == null)
            {
                _currNode = _root;
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
            return Unwind();
        }

        public void Reset()
        {
            _currNode = null;
        }

        T IEnumerator<T>.Current => _current;

        public object Current => _currNode.Value;

        public void Dispose()
        {
        }
    }
}