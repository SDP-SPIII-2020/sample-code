namespace PredsVsDelegates
{
    public static class StringExtensions
    {
        public static bool IsLowerCase(this string str) => str.Equals(str.ToLower());
    }
}