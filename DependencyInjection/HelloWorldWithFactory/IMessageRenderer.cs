namespace HelloWorldWithFactory
{
    internal interface IMessageRenderer
    {
        IMessageProvider MessageProvider { get; set; }
        void Render();
    }
}