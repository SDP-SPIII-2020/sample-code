using System;
namespace HelloWorldDecoupledInterface
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
