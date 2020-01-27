using System;
namespace HelloWorldDecoupledInterface
{
    interface IMessageRenderer
    {
        abstract IMessageProvider MessageProvider { get; set; }
        abstract void Render();
    }
}