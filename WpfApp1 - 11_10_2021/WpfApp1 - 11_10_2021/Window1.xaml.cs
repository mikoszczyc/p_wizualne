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
using System.Windows.Threading;
using System.Diagnostics;

namespace WpfApp1___11_10_2021
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();
        string currentTime = string.Empty;
        public Window1()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval += new TimeSpan(0, 0, 0, 0, 1);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                TimeSpan ts = stopwatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                StopwatchFace.Content = currentTime;
            }
        }

        void StopwatchStart_OnClick(object sender, EventArgs e)
        {
            stopwatch.Restart();
            timer.Start();
        }

        void StopwatchStop_OnClick(object sender, EventArgs e)
        {
            stopwatch.Stop();
            timer.Stop();
        }
    }
}
