# define ONE

using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace HelloWorldWithAutofac
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            #region 01 - avoid new
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

            #region 02 - look for class in assembly
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

            #region 03 with config file
#if THREE
            //var executionFolder = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            //AssemblyLoadContext.Default.Resolving += (AssemblyLoadContext context, AssemblyName assembly) =>
            //{
            //    // DISCLAIMER: NO PROMISES THIS IS SECURE. You may or may not want this strategy. It's up to
            //    // you to determine if allowing any assembly in the directory to be loaded is acceptable. This
            //    // is for demo purposes only.
            //    return context.LoadFromAssemblyPath(Path.Combine(executionFolder, $"{assembly.Name}.dll"));
            //};

            var config = new ConfigurationBuilder()
                .AddJsonFile("autofac.json")
                .Build();
            var configModule = new ConfigurationModule(config);
            var builder = new ContainerBuilder();
            builder.RegisterModule(configModule);
            var container = builder.Build(); 

            try
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var mr = scope.Resolve<IMessageRenderer>();
                    var mp = scope.Resolve<IMessageProvider>();
                    mr.MessageProvider = mp;
                    mr.Render();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error during configuration demonstration: {0}", ex);
            }
#endif
            #endregion

            #region 04 modules
#if FOUR
            var builder = new ContainerBuilder();
            builder.RegisterModule<ProgramModule>();

            var container = builder.Build();
            try
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var mr = scope.Resolve<IMessageRenderer>();
                    var mp = scope.Resolve<IMessageProvider>();
                    mr.MessageProvider = mp;
                    mr.Render();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error during configuration demonstration: {0}", ex);
            }
#endif
            #endregion

            #region 05 autoscan
#if FIVE
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsSelf().AsImplementedInterfaces();

            var container = builder.Build();
            try
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    scope.Resolve<IMessageRenderer>().Render();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error during configuration demonstration: {0}", ex);
            }

#endif
            #endregion

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }


}