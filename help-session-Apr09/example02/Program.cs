using System;

namespace example02
{
    public static class Program
    {
        private static void Main()
        {
            var numbers1 = new Box<int[]>(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            var numbers2 = new Box<int[]>(new[] {11, 12, 13, 14, 15, 16, 17, 18, 19, 20});

            // var transformedResult1 = numbers1.Bind(item => MyFunction(item));
            // Console.WriteLine($"The result of the Bind operation is: {transformedResult1.Item}");
            // var transformedResult2 = numbers1.Select(x => MyFunction(x));
            // Console.WriteLine($"The result of the Select (Map) operation is: {transformedResult2.Item}");
            // var result = numbers1.Select(x => "ksadhadsh");
            // Console.WriteLine($"The result of the Select (Map) operation is: {result.Item}");

            var stringBox = new Box<string>("A string");
            var result2 = stringBox
                .Bind(s => new Box<int>(2)) // VETL
                .Bind(i => new Box<int>()) // Validate step only
                .Bind(s => new Box<string>("Finished!")); //Validate step only
            Console.WriteLine($"The result of the Bind operation is: \"{result2.Item}\"");
            
            // Validation only checks to see if the box is valid or not, in this case "empty"
            // If "empty" then the Bind function does not run!
        }

        private static Box<int[]> MyFunction(int[] intArr) =>
            new Box<int[]>(new int[] {99, 57});
    }
}