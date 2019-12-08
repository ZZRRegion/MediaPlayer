/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：MediaPlayer
* 类 名 称：RGCommon
* 创建日期：2019/12/6 19:26:54
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：RGCommon
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

namespace MediaPlayer
{
    public static class RGCommon
    {
        #region 构造函数
        #endregion
        #region Variables
        public static string Title => "媒体播放器";
        public static string Version => "1.0.0.0";
        public static string VersionTime => "2019-12-07 20:00:00";
        public static string ToLocalString(this TimeSpan @this)
        {
            return @this.ToString(@"hh\:mm\:ss");
        }
        #endregion
        #region private Variables
        #endregion
        #region Methods
        public static void SaveAsImageFile(this FrameworkElement @this, string fileName)
        {
            RenderTargetBitmap render = new RenderTargetBitmap((int)@this.ActualWidth, (int)@this.ActualHeight, 96, 96, PixelFormats.Default);
            render.Render(@this);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(render));
            FileStream fileStream = File.Create(fileName);
            encoder.Save(fileStream);
            fileStream.Close();
        }
        public static string GetFileName(string directory, string name)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string fileName = Path.Combine(directory, name);
            return fileName;
        }
        #endregion
        #region private Methods
        #endregion
        #region Event
        #endregion
    }
}
