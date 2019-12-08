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
        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register("Progress", typeof(int), typeof(MainWindow), new FrameworkPropertyMetadata(0, ProgressChanged));
        public static readonly DependencyProperty TotalTimeSpanProperty = DependencyProperty.Register("TotalTimeSpan", typeof(TimeSpan), typeof(MainWindow));
        public static readonly DependencyProperty IndexProperty = DependencyProperty.Register("Index", typeof(long), typeof(MainWindow));
        public long Index
        {
            get => (long)this.GetValue(IndexProperty);
            set => this.SetValue(IndexProperty, value);
        }
        public TimeSpan TotalTimeSpan
        {
            get => (TimeSpan)this.GetValue(TotalTimeSpanProperty);
            set => this.SetValue(TotalTimeSpanProperty, value);
        }
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
            if(e.ClickCount == 2)
            {
                this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            }
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
                this.player.Play();
            }
            else
            {
                this.player.Pause();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
            this.TotalTimeSpan = this.player.NaturalDuration.TimeSpan;
            this.Index = 0;
        }

        private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine(e.PropertyName);
            if (this.player.MediaState == MediaState.Play && this.player.NaturalDuration.HasTimeSpan)
            {
                int progress = (int)(this.player.Position.TotalSeconds * 100 / this.player.NaturalDuration.TimeSpan.TotalSeconds);
                this.Progress = progress;
                string name = $"{this.Index++}.png";
                string fileName = RGCommon.GetFileName("images", name);
                if (this.ckbToPng.IsChecked.HasValue && this.ckbToPng.IsChecked.Value)
                {
                    this.player.SaveAsImageFile(fileName);
                    this.ckbToPng.Content = $"帧转图片:{this.Index}";
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    if(this.WindowState == WindowState.Maximized)
                    {
                        this.WindowState = WindowState.Normal;
                    }
                    else
                    {
                        this.Close();
                    }
                    break;
            }
        }
    }
}
