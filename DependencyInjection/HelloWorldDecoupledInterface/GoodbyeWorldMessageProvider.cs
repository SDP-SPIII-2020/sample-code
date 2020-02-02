namespace HelloWorldDecoupledInterface
{
    internal class GoodbyeWorldMessageProvider : IMessageProvider
    {
        public GoodbyeWorldMessageProvider()
        {
            Message = "Goodbye World!";
        }

        public string Message { get; set; }
    }
}