using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RaceDirector.ViewModels;

namespace RaceDirector.Views
{
    /// <summary>
    /// Interaction logic for RaceConfigurationView.xaml
    /// </summary>
    public partial class RaceConfigurationView : Page
    {
        public RaceConfigurationView()
        {
            InitializeComponent();
            DataContext = new RaceConfigurationViewModel();
        }
    }
}
