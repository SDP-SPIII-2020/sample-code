using System;
using LanguageExt;
using static LanguageExt.List;
using static LanguageExt.Prelude;

namespace help_session_Apr12
{
    // Implement functions to work with the singly linked List defined in this chapter:

    // InsertAt inserts an item at the given index
    // RemoveAt removes the item at the given index
    // TakeWhile takes a predicate, and traverses the list yielding all items until it find one that fails the predicate
    // DropWhile works similarly, but excludes all items at the front of the list

    // avoids the use of similarly named functions in Language.Ext

    public static class ListExtensions
    {
        // One could use Insert from LanguageExt but let us write our own version
        public static Lst<T> InsertAt<T>(this Lst<T> @this, int m, T value)
            => new Lst<T>(m != 0
                ? append(create(head(@this)), rhs: tail(@this).InsertAt(m - 1, value)
                : append(create(value), @this));

        // RemoveAt removes the item at the given index
        public static Lst<T> RemoveAt<T>(this Lst<T> @this, int m)
            => new Lst<T>(m == 0
                ? tail(@this)
                : append(create<T>(head(@this)), ((Lst<T>) tail(@this)).RemoveAt(m - 1)));

        // TakeWhile takes a predicate, and traverses the list yielding all items until it find one that fails the predicate
        public static Lst<T> TakeWhile<T>(this Lst<T> @this, Func<T, bool> pred)
            => new Lst<T>(@this.Match(
                () => @this,
                (hd, tl) => pred(hd)
                    ? append(create<T>(hd), ((Lst<T>) tail(tl)).TakeWhile(pred))
                    : create<T>()));

        // DropWhile works similarly, but excludes all items at the front of the list
        public static Lst<T> DropWhile<T>(this Lst<T> @this, Func<T, bool> pred)
            => new Lst<T>(@this.Match(
                () => @this,
                (hd, tl) => pred(hd)
                    ? createRange(tl).DropWhile(pred) // Seq to Lst
                    : @this));
    }
}