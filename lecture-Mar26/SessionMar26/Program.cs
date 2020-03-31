using System;
using LanguageExt;
using static LanguageExt.Prelude;
using static System.Console;

namespace SessionMar26
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var x = Some(123);
            var y = None;

            var optional = Some(456);
            var result = optional.Match(
                Some: item => item * 2,
                None: () => 12
            );
            WriteLine(result);
        }
    }
}