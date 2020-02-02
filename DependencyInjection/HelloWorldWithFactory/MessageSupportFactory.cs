using System;
using System.Configuration;

namespace HelloWorldWithFactory
{
    internal static class MessageSupportFactory
    {
        static MessageSupportFactory()
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count == 0) throw new Exception("AppSettings is empty.");
            var classRenderer = appSettings["Renderer"];
            var classProvider = appSettings["Provider"];

            // get instance of class
            var t = Type.GetType(classRenderer);
            MessageRenderer = Activator.CreateInstance(t) as IMessageRenderer;
            t = Type.GetType(classProvider);
            MessageProvider = Activator.CreateInstance(t) as IMessageProvider;
        }

        internal static IMessageRenderer MessageRenderer { get; }
        internal static IMessageProvider MessageProvider { get; }
    }
}