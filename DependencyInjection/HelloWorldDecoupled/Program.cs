using System;

namespace HelloWorldDecoupled
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardOutMessageRenderer mr = new StandardOutMessageRenderer();
            HelloWorldMessageProvider mp = new HelloWorldMessageProvider("Hello World");
            mr.MessageProvider = mp;
            mr.render();
        }
    }

    class HelloWorldMessageProvider
    {
        internal string Message { get; set; }

        public HelloWorldMessageProvider(string Message)
        {
            this.Message = Message;
        }
    }

    class StandardOutMessageRenderer
    {

        internal HelloWorldMessageProvider MessageProvider { get; set; }

        public void render()
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
