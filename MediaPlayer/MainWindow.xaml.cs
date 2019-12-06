using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace MediaPlayer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private System.Windows.Threading.DispatcherTimer timer;
        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register("Progress", typeof(int), typeof(MainWindow), new FrameworkPropertyMetadata(0, ProgressChanged));
        public static void ProgressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow mainWindow = d as MainWindow;

        }

        /// <summary>
        /// 进度条
        /// </summary>
        public int Progress
        {
            get => (int)GetValue(ProgressProperty);
            set => this.SetValue(ProgressProperty, value);
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        protected void OnPropertyChanged<T>(ref T @this, T value, [CallerMemberName] string propertyName = "")
        {
            @this = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
            base.OnMouseLeftButtonDown(e);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "mp4|*.mp4";
            bool? result = ofd.ShowDialog(this);
            if(result.HasValue && result.Value)
            {
                this.player.Source = new Uri(ofd.FileName);
            }
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if(this.player.MediaState != MediaState.Play)
            {
                this.btnPlay.Content = "暂停";
                this.player.Play();
            }
            else
            {
                this.btnPlay.Content = "播放";
                this.player.Pause();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.timer = new System.Windows.Threading.DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(1);
            this.timer.Tick += Timer_Tick;
            this.timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(this.player.MediaState == MediaState.Play)
            {
                this.txtProgress.Text = $"{this.player.Position.ToLocalString()}/{this.player.NaturalDuration.TimeSpan.ToLocalString()}";
            }
        }
    }
}
