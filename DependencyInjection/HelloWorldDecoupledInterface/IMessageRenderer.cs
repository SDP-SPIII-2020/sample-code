namespace HelloWorldDecoupledInterface
{
    internal interface IMessageRenderer
    {
        IMessageProvider MessageProvider { get; set; }
        void Render();
    }
}