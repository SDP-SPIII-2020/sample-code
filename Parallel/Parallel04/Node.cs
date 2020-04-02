using System;
using System.Threading.Tasks;

namespace Parallel04
{
    public class Node<T> // generic over type of value in each node
        where T : IComparable // T implements a CompareTo method
    {
        // Private member-variables
        public T Value { get; private set; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }

        // delegates used in this class
        public delegate T TreeMapperDelegate(T t);

        // constructors
        public Node(T x)
        {
            Value = x;
            Left = null;
            Right = null;
        }

        public Node(T x, Node<T> left, Node<T> right)
        {
            Value = x;
            Left = left;
            Right = right;
        }

        // operations on Nodes
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

            if (Value.CompareTo(x) < 0)
            {
                return Right != null && Right.Find(x);
            }

            return Left != null && Left.Find(x);
        }

        // higher-order functions over trees
        public void MapTree(TreeMapperDelegate f)
        {
            Value = f(Value);
            Left?.MapTree(f);
            Right?.MapTree(f);
        }

        // parallel version of the same higher-order function
        public void ParMapTree(TreeMapperDelegate f)
        {
            var i = 0;
            var tasks = new Task[3];
            var t1 = Task.Factory.StartNew(() => this.Value = f(this.Value));
            tasks[i++] = t1;
            
            if (Left != null)
            {
                var t2 = Task.Factory.StartNew(() => this.Left.ParMapTree(f));
                tasks[i++] = t2;
            }

            if (Right != null)
            {
                var t3 = Task.Factory.StartNew(() => this.Right.ParMapTree(f));
                tasks[i++] = t3;
            }

            Task.WaitAll(tasks);
        }

        public override string ToString() => ToStringIndent(0);

        public string ToStringIndent(int n)
        {
            var str = "";
            for (var i = 0; i < n; i++)
            {
                str += " ";
            }

            return
                $"{str}{Value}\n{(Left == null ? str + " ." + "\n" : Left.ToStringIndent(n + 1))}{(Right == null ? str + " ." + "\n" : Right.ToStringIndent(n + 1))}";
        }
    }
}