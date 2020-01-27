﻿using System;
namespace HelloWorldWithFactory
{
    class HelloWorldMessageProvider : IMessageProvider
    {
        public string Message { get; set; }

        public HelloWorldMessageProvider()
        {
            Message = "Hello World";
        }
    }
}
