using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace PCInspectTool_Splash
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                InspectReady.Run();

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    prgbar_label.Content = "점검 준비 완료";

                    Thread.Sleep(1000);
                    Process.Start(@"PCInspectTool+Win10.exe");
                    Application.Current.Shutdown();
                }));
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
             string OS = OSVersionCheck.Run();               

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    
                    lb_osver.Content = OS;

                }));
            });

        }
    }
}
