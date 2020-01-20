using System;
using System.Configuration;

namespace HelloWorldDecoupledWithFactory
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

    internal static class MessageSupportFactory
    {
        internal static IMessageRenderer MessageRenderer { get; private set; }
        internal static IMessageProvider MessageProvider { get; private set; }

        static MessageSupportFactory()
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count == 0)
            {
                throw new Exception("AppSettings is empty.");
            }
            var classRenderer = appSettings["Renderer"];
            var classProvider = appSettings["Provider"];

            // get instance of class
            var t = Type.GetType(classRenderer);
            MessageRenderer = (IMessageRenderer)Activator.CreateInstance(t);
            t = Type.GetType(classProvider);
            MessageProvider = (IMessageProvider)Activator.CreateInstance(t);
        }
    }

    interface IMessageProvider
    {
        abstract string Message { get; set; }
    }

    interface IMessageRenderer
    {
        abstract IMessageProvider MessageProvider { get; set; }
        abstract void Render();
    }

    class HelloWorldMessageProvider : IMessageProvider
    {
        public string Message { get; set; }

        public HelloWorldMessageProvider()
        {
            Message = "Hello World";
        }
    }

    class GoodbyeWorldMessageProvider : IMessageProvider
    {
        public string Message { get; set; }

        public GoodbyeWorldMessageProvider()
        {
            Message = "Goodbye World!";
        }
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
