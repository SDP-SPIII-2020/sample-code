using System;
namespace HelloWorldDecoupledInterface
{
    class HelloWorldMessageProvider : IMessageProvider
    {
        public string Message { get; set; }

        public HelloWorldMessageProvider(string msg)
        {
            Message = msg;
        }
    }
}
