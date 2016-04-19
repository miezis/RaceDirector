using System.Net;
using System.Windows;
using Autofac;
using RaceDirector.ServiceContracts;
using RaceDirector.Services;

namespace RaceDirector
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Register Autofac stuff
            Container.Build();

            base.OnStartup(e);
        }
    }
}
