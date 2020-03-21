namespace FunctionalProgrammingRedux
{
    public static class ExpressionsStatements
    {
    }
}

// expression is anything that results in a value.
// 12, "thing"
// Convert.ToInt32("12")
// comparison and boolean operators (e.g., && ||, etc.)

// statements are actions which do not necessarily result in values.

// public decimal CalculateDiscount(decimal amount, bool hasDiscount)
// {
//     decimal discount = 0;
//     if (hasDiscount)
//     {
//         discount = 10;
//     }
//     return ....
// }

// public decimal CalculateDiscount(decimal amount, bool hasDiscount)
// {
//      decimal discount = hasDiscount ? 10 : 0;
//      return .....
// }
/*
1. Combine expressions to build larger expressions - composition, "compose"
2. Expressions could be evaluated out of order. Statements are sequential.
3. Expressions are deterministic - given the same input they will produce the same output.
4. Expressions are easier to test.
*/