# define THREE

using Autofac;
using System;
using System.Reflection;

namespace HelloWorldWithAutofac
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            #region avoid new
#if ONE
            var builder = new ContainerBuilder();
            builder.RegisterType<HelloWorldMessageProvider>().As<IMessageProvider>();
            builder.RegisterType<StandardOutMessageRenderer>().As<IMessageRenderer>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var mr = scope.Resolve<IMessageRenderer>();
                var mp = scope.Resolve<IMessageProvider>();
                mr.MessageProvider = mp;
                mr.Render();
            }
#endif
            #endregion

            #region look for class in assembly
#if TWO
            var dataAccess = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("MessageProvider"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("MessageRenderer"))
                .AsImplementedInterfaces();

            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var mr = scope.Resolve<IMessageRenderer>();
                var mp = scope.Resolve<IMessageProvider>();
                mr.MessageProvider = mp;
                mr.Render();
            }
#endif
            #endregion

            #region
#if THREE

#endif
#endregion
        }
    }


}