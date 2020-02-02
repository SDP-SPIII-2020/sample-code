namespace HelloWorldWithFactory
{
    internal class HelloWorldMessageProvider : IMessageProvider
    {
        public HelloWorldMessageProvider()
        {
            Message = "Hello World";
        }

        public string Message { get; set; }
    }
}