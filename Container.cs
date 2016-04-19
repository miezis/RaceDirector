using System.Runtime.Remoting.Services;
using Autofac;
using RaceDirector.ServiceContracts;
using RaceDirector.Services;

namespace RaceDirector
{
    public static class Container
    {
         public static IContainer BaseContainer { get; private set; }

        public static void Build()
        {
            if (BaseContainer == null)
            {
                var builder = new ContainerBuilder();

                builder.RegisterType<ArduinoService>().As<IArduinoService>().InstancePerLifetimeScope();

                BaseContainer = builder.Build();
            }
        }

        public static TService Resolve<TService>()
        {
            return BaseContainer.Resolve<TService>();
        }
    }
}