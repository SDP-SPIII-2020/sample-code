using System;
namespace HelloWorldWithAutofac
{
    class StandardOutMessageRenderer : IMessageRenderer
    {
        public IMessageProvider MessageProvider { get; set; }

        public StandardOutMessageRenderer(IMessageProvider provider)
        {
            MessageProvider = provider;
        }

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
