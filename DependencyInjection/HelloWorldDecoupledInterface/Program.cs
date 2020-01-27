using System;

namespace HelloWorldDecoupledInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageRenderer mr = new StandardOutMessageRenderer();
            IMessageProvider mp = new HelloWorldMessageProvider("Hello World");
            mr.MessageProvider = mp;
            mr.Render();
        }
    }
}
