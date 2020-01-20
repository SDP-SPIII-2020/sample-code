using Autofac;
using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ProgramModule>();

            var container = containerBuilder.Build();

            var notificationService = container.Resolve<INotificationService>();
            var userService = container.Resolve<UserService>();

            var user1 = new User("Tim");
            userService.ChangeUsername(user1, "Robert");

            Console.ReadKey();
        }
    }
}
