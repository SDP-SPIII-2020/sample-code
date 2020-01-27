using System;
namespace HelloWorldWithAutofac
{
    interface IMessageRenderer
    {
        abstract IMessageProvider MessageProvider { get; set; }
        abstract void Render();
    }
}