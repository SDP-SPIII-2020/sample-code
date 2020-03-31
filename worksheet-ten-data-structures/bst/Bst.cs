using System;
using System.Collections.Generic;
using LanguageExt;

namespace bst
{
    public abstract class Tree<T> where T : IComparable<T>
    {
        public abstract R Match<R>(Func<R> empty, Func<Tree<T>, T, Tree<T>, R> node);

        public abstract bool IsEmpty { get; }
        public abstract bool Contains(T value);
        public abstract Tree<T> Insert(T value);
        public abstract IEnumerable<T> AsEnumerable();

        public bool Equals(Tree<T> other) => this.ToString() == other.ToString(); // hack
        public override bool Equals(object obj) => Equals((Tree<T>) obj);
    }

    public class Empty<T> : Tree<T> where T : IComparable<T>
    {
        public override R Match<R>(Func<R> empty, Func<Tree<T>, T, Tree<T>, R> node)
            => empty();

        public override bool IsEmpty => true;
        public override bool Contains(T value) => false;

        public override Tree<T> Insert(T value)
            => Tree.Node(Tree.Empty<T>(), value, Tree.Empty<T>());

        public override string ToString() => string.Empty;

        public override IEnumerable<T> AsEnumerable()
        {
            yield break;
        }
    }

    public class Node<T> : Tree<T> where T : IComparable<T>
    {
        public Tree<T> Left { get; }
        public Tree<T> Right { get; }
        public T Value { get; }

        public Node(Tree<T> left, T value, Tree<T> right)
        {
            this.Left = left;
            this.Right = right;
            this.Value = value;
        }

        public override R Match<R>(Func<R> empty, Func<Tree<T>, T, Tree<T>, R> node)
            => node(Left, Value, Right);

        public override bool IsEmpty => false;

        public override string ToString() => $"Node(Left:({Left}), Value:{Value}, Right:({Right}))";

        public override bool Contains(T value)
        {
            var comparison = value.CompareTo(this.Value);
            if (comparison == 0) return true;
            return comparison < 0 ? Left.Contains(value) : Right.Contains(value);
        }

        public override Tree<T> Insert(T value)
        {
            var comparison = value.CompareTo(Value);
            if (comparison == 0) return this;
            return comparison < 0 ? Tree.Node(Left.Insert(value), Value, Right) : 
                Tree.Node(Left, Value, Right.Insert(value));
        }

        public override IEnumerable<T> AsEnumerable()
        {
            foreach (var item in this.Left.AsEnumerable())
                yield return item;

            yield return Value;

            foreach (var item in this.Right.AsEnumerable())
                yield return item;
        }
    }

    public static class Tree
    {
        public static Tree<T> Empty<T>() where T : IComparable<T> => new Empty<T>();

        public static Tree<T> Node<T>(Tree<T> left, T value, Tree<T> right)
            where T : IComparable<T>
            => new Node<T>(left, value, right);

        // Warning: The resulting tree is not necessarily sorted
        public static Tree<R> Map<T, R>(this Tree<T> tree, Func<T, R> func)
            where T : IComparable<T>
            where R : IComparable<R>
            => tree.Match(
                Empty<R>,
                (left, value, right) => Node
                (
                    left.Map(func),
                    func(value),
                    right.Map(func)
                )
            );
    }
}