using System.Runtime.Remoting.Services;
using Autofac;
using RaceDirector.Models;
using RaceDirector.ServiceContracts;
using RaceDirector.Services;
using RaceDirector.ViewModels;
using RaceDirector.Views;

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

                builder.RegisterType<Application>().AsSelf().SingleInstance();
                builder.RegisterType<Race>().AsSelf().SingleInstance();

                builder.RegisterType<FreePracticeView>().AsSelf().InstancePerDependency();
                builder.RegisterType<RaceConfigurationView>().AsSelf().InstancePerDependency();
                builder.RegisterType<RaceResultsView>().AsSelf().InstancePerDependency();
                builder.RegisterType<RacersEntryView>().AsSelf().InstancePerDependency();
                builder.RegisterType<RaceView>().AsSelf().InstancePerDependency();
                builder.RegisterType<TrackConnectionView>().AsSelf().InstancePerDependency();

                BaseContainer = builder.Build();
            }
        }

        public static TService Resolve<TService>()
        {
            return BaseContainer.Resolve<TService>();
        }
    }
}