using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PCInspectTool_Win10
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

        private void StartInspection(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
            {
                Task.Run(() =>
                {
                    foreach (var InsList in Inslib.Main.AutoCheck)
                    {
                        Console.WriteLine(InsList.test());

                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            string a = "lb_" + InsList.test();

                            var SomeLabel = (Label)this.FindName(a);

                            SomeLabel.Content = InsList.check();
                        }
                        ));
                    }
                }
                ) ;

                Inslib.Main.ManualCheck.AsParallel().ForAll(chk => 
                {
                    Console.WriteLine(chk.test());
                    

                });
            }));
        }
    }
}
