using System;
namespace HelloWorldDecoupledInterface
{
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
