using Diary.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Diary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    internal delegate void Invoker();
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var metroWindow = Current.MainWindow as MetroWindow;
            metroWindow.ShowMessageAsync("Nieoczekiwany  wyjątek",
                "Wystąpił nieoczekiwany wyjątek." +
                Environment.NewLine +
                e.Exception.Message);

            e.Handled = true;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            
            var splashScreen = new SplashScreenWindow();
            this.MainWindow = splashScreen;
            splashScreen.Show();

          
            Task.Factory.StartNew(() =>
            {
               
                for (int i = 1; i <= 100; i++)
                {
                   
                    System.Threading.Thread.Sleep(30);
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = i);
                }

           
                this.Dispatcher.Invoke(() =>
                {
                 
                    var mainWindow = new MainWindow();
                    this.MainWindow = mainWindow;
                    mainWindow.Show();
                    splashScreen.Close();
                });
            });
        }
    }
}





