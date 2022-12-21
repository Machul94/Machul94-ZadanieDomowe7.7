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
using System.Windows.Shapes;
using Diary.ViewModels;
using MahApps.Metro.Controls;

namespace Diary.Views
{
    /// <summary>
    /// Logika interakcji dla klasy DataBaseSettingsView.xaml
    /// </summary>
    public partial class DataBaseSettingsView : MetroWindow
    {
        public DataBaseSettingsView()
        {
            InitializeComponent();
            DataContext = new DataBaseSettingViewModel();
        }
    }
}
