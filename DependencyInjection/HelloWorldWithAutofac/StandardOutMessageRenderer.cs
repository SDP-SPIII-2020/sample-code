using System;

namespace HelloWorldWithAutofac
{
    internal class StandardOutMessageRenderer : IMessageRenderer
    {
        public StandardOutMessageRenderer(IMessageProvider provider)
        {
            MessageProvider = provider;
        }

        public IMessageProvider MessageProvider { get; set; }

        public void Render()
        {
            if (MessageProvider == null)
            {
                throw new Exception($"You must set the property messageProvider of class: {GetType()}");
            }

            Console.WriteLine(MessageProvider.Message);
        }
    }
}