using System;

namespace HelloWorldDecoupled
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

    internal interface IMessageProvider
    {
        string Message { get; }
    }

    class HelloWorldMessageProvider : IMessageProvider
    {
        public string Message { get; }

        public HelloWorldMessageProvider(string Message)
        {
            this.Message = Message;
        }
    }

    internal interface IMessageRenderer
    {
        IMessageProvider MessageProvider { get; set; }
        void Render();
    }

    class StandardOutMessageRenderer : IMessageRenderer
    {
        public IMessageProvider MessageProvider { get; set; }

        public void Render()
        {
            if (MessageProvider == null)
            {
                throw new Exception("You must set the property messageProvider of class:"
                        + this.GetType().ToString());
            }
            Console.WriteLine(MessageProvider.Message);
        }
    }
}
