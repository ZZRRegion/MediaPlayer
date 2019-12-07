/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：MediaPlayer.Converters
* 类 名 称：TimeSpan2StringConverter
* 创建日期：2019/12/7 11:31:35
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：TimeSpan2StringConverter
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows.Data;

namespace MediaPlayer.Converters
{
    public class TimeSpan2StringConverter : IValueConverter
    {
        #region 构造函数
        #endregion
        #region Variables
        #endregion
        #region private Variables
        #endregion
        #region Methods
        #endregion
        #region private Methods
        #endregion
        #region Event
        #endregion
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is TimeSpan timeSpan)
            {
                return timeSpan.ToString(@"hh\:mm\:ss");
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
