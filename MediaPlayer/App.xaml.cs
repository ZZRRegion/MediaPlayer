using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MediaPlayer
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Unosquare.FFME.MediaElement.FFmpegDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Dll");
            base.OnStartup(e);
        }
    }
}
