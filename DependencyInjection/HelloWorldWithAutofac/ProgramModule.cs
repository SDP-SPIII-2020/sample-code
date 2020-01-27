using Autofac;

namespace HelloWorldWithAutofac
{
    public class ProgramModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HelloWorldMessageProvider>().As<IMessageProvider>();
            builder.RegisterType<StandardOutMessageRenderer>().As<IMessageRenderer>();
        }
    }
}
