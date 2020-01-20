using Autofac;

namespace DependencyInjection
{
    class ProgramModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleNotification>().As<INotificationService>();
            builder.RegisterType<UserService>().AsSelf();
        }
    }
}
