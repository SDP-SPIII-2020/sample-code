namespace HelloWorldWithFactory
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mr = MessageSupportFactory.MessageRenderer;
            var mp = MessageSupportFactory.MessageProvider;
            mr.MessageProvider = mp;
            mr.Render();
        }
    }
}