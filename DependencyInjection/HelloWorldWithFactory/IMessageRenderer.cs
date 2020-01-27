using System;
namespace HelloWorldWithFactory
{
    interface IMessageRenderer
    {
        abstract IMessageProvider MessageProvider { get; set; }
        abstract void Render();
    }
}