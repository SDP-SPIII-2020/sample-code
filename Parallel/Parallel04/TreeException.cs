namespace Parallel04
{
    // exceptions used in either Tree or Node
    internal class TreeException : System.Exception
    {
        public TreeException(string msg) : base(msg)
        {
        }
    }
}