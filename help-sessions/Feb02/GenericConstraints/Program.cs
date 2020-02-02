using System;
using System.Collections.Generic;

namespace GenericConstraints
{
    public class Employee
    {
        public Employee(string s, int i) => (Name, Id) = (s, i);
        public string Name { get; set; }
        private int Id { get; set; }
    }

    public class GenericList<T> where T : Employee
    {
        private class Node
        {
            public Node(T t) => (Next, Data) = (null, t);

            public Node Next { get; set; }
            public T Data { get; set; }
        }

        private Node _head;

        public void AddHead(T t)
        {
            Node n = new Node(t) {Next = _head};
            _head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = _head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public T FindFirstOccurrence(string s)
        {
            var current = _head;
            T t = null;

            while (current != null)
            {
                //The constraint enables access to the Name property.
                if (current.Data.Name == s)
                {
                    t = current.Data;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            return t;
        }
    }

    class Program
    {
        static void Main()
        {
            // your code here...
        }
    }
}