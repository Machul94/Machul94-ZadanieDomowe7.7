using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.Commands;
using System.Windows.Media.Animation;
using System.Windows.Input;
using System.Windows;
using Diary.Properties;
using System.Diagnostics;
using Diary.Models.Wrappers;
using System.Configuration;
using Diary.Models.Domains;

namespace Diary.ViewModels
{
    public class DataBaseSettingViewModel : ViewModelBase
    {
        public DataBaseSettingViewModel()
        {
           
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);
            _appSettings = new AppSettings();
        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private AppSettings _appSettings;
        public AppSettings AppSettings
        {
            get { return _appSettings; }
            set
            {
                _appSettings = value;
                OnPropertyChanged();
            }
        }


        private void Confirm(object obj)
        {
            if (!AppSettings.IsValid)
                return;

            AppSettings.SaveAppSettings();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }



    }
}
