using System;

namespace trees
{
    public abstract class Tree<T> : IEquatable<Tree<T>>
    {
        public abstract R Match<R>(Func<T, R> leaf, Func<Tree<T>, Tree<T>, R> branch);

        public bool Equals(Tree<T> other) => other != null && this.ToString() == other.ToString(); // hack
        public override bool Equals(object obj) => Equals((Tree<T>) obj);
    }

    internal class Branch<T> : Tree<T>
    {
        public Tree<T> Left { get; }
        public Tree<T> Right { get; }

        public Branch(Tree<T> left, Tree<T> right)
        {
            Left = left;
            Right = right;
        }

        public override string ToString() => $"Branch({Left}, {Right})";

        public override R Match<R>(Func<T, R> leaf, Func<Tree<T>, Tree<T>, R> branch) => branch(Left, Right);
    }

    internal class Leaf<T> : Tree<T>
    {
        public T Value { get; }

        public Leaf(T value) => Value = value;

        public override string ToString() => Value.ToString();

        public override R Match<R>(Func<T, R> leaf, Func<Tree<T>, Tree<T>, R> branch) => leaf(Value);
    }

    public static class Tree
    {
        public static Tree<T> Leaf<T>(T value) => new Leaf<T>(value);

        public static Tree<T> Branch<T>(Tree<T> left, Tree<T> right) => new Branch<T>(left, right);

        public static Tree<R> Map<T, R>(this Tree<T> @this, Func<T, R> f)
            => @this.Match(
                leaf: t => Leaf(f(t)),
                branch: (left, right) => Branch<R>(
                    left: Map((Tree<T>) left, f),
                    right: Map((Tree<T>) right, f)
                )
            );

        public static Tree<T> Insert<T>(this Tree<T> @this, T value)
            => @this.Match(
                leaf: t => Branch<T>(Leaf<T>(t), Leaf(value)),
                branch: (l, r) => Branch<T>(l, Insert((Tree<T>) r, value)));

        public static T Aggregate<T>(this Tree<T> tree, Func<T, T, T> f)
            => tree.Match(
                leaf: t => t,
                branch: (l, r) => f(Aggregate((Tree<T>) l, f), Aggregate((Tree<T>) r, f)));

        public static Acc Aggregate<T, Acc>(this Tree<T> tree, Acc acc, Func<Acc, T, Acc> f)
            => tree.Match(
                leaf: t => f(acc, t),
                branch: (l, r) =>
                {
                    var leftAcc = Aggregate((Tree<T>) l, acc, f);
                    return Aggregate((Tree<T>) r, leftAcc, f);
                });

        public static Tree<R> Run<T, R>(this Holder<Tree<T>, R> @this) => @this.Value.Map(t => @this.Func(t));
    }
}