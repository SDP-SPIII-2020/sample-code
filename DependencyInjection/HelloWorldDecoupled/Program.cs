using System;

namespace HelloWorldDecoupled
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mr = new StandardOutMessageRenderer();
            var mp = new HelloWorldMessageProvider("Hello World");
            //mr.MessageProvider = mp;
            mr.Render();
        }
    }

    internal class HelloWorldMessageProvider
    {
        public HelloWorldMessageProvider(string Message)
        {
            this.Message = Message;
        }

        internal string Message { get; set; }
    }

    internal class StandardOutMessageRenderer
    {
        internal HelloWorldMessageProvider MessageProvider { get; set; }

        public void Render()
        {
            if (MessageProvider == null)
                throw new Exception("You must set the property messageProvider of class:"
                                    + GetType());
            Console.WriteLine(MessageProvider.Message);
        }
    }
}