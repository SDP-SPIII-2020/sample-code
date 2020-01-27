using System;

namespace HelloWorldWithFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageRenderer mr = MessageSupportFactory.MessageRenderer;
            IMessageProvider mp = MessageSupportFactory.MessageProvider;
            mr.MessageProvider = mp;
            mr.Render();
        }
    }

    
}