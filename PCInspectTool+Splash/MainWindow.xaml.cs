using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
