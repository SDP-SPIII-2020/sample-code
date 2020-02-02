namespace HelloWorldDecoupledInterface
{
    internal class HelloWorldMessageProvider : IMessageProvider
    {
        public HelloWorldMessageProvider(string msg)
        {
            Message = msg;
        }

        public string Message { get; set; }
    }
}