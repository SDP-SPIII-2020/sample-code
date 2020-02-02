namespace HelloWorldWithAutofac
{
    internal interface IMessageRenderer
    {
        IMessageProvider MessageProvider { get; set; }
        void Render();
    }
}