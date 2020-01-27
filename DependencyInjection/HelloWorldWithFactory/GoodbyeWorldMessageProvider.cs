using System;
namespace HelloWorldWithFactory
{
    class GoodbyeWorldMessageProvider : IMessageProvider
    {
        public string Message { get; set; }

        public GoodbyeWorldMessageProvider()
        {
            Message = "Goodbye World!";
        }
    }
}
