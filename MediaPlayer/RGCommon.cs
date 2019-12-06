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

using System.Windows.Controls;
namespace MediaPlayer
{
    public static class RGCommon
    {
        #region 构造函数
        #endregion
        #region Variables
        public static string Title => "媒体播放器";
        public static string Version => "1.0.0.0";
        public static string VersionTime => "2019-12-06 20:00:00";
        public static string ToLocalString(this TimeSpan @this)
        {
            return $"{@this.Hours}:{@this.Minutes}:{@this.Seconds}";
        }
        #endregion
        #region private Variables
        #endregion
        #region Methods
        #endregion
        #region private Methods
        #endregion
        #region Event
        #endregion
    }
}
