using System;
using System.Collections;
using System.Collections.Generic;

namespace Dependencies
{
    internal class PostfixEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private Node<T> _currNode;
        private Node<T> _root;
        private Stack _stack;
        private T _current;
        public const string Name = "PostfixEnumerator";

        public PostfixEnumerator(Tree<T> t)
        {
        }

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

        public bool MoveNext()
        {
            throw new TreeException("PostfixEnumerator: Not implemented");
        }

        public void Reset()
        {
            throw new TreeException("PostfixEnumerator: Not implemented");
        }

        T IEnumerator<T>.Current => _current;

        public object Current => throw new TreeException("PostfixEnumerator: Not implemented");

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}