﻿using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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
                );
            }));
        }
    }
}
