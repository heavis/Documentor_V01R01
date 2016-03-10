using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HeaviSoft.FrameworkBase.Utility.Visual
{
    public class VisualHelper
    {
        /// <summary>
        /// 查找父元素
        /// </summary>
        /// <typeparam name="T">父元素类型</typeparam>
        /// <param name="element">起始元素</param>
        /// <returns></returns>
        public static T FindParent<T>(UIElement element) where T : UIElement
        {
            if (element.GetType() == typeof(T))
            {
                return element as T;
            }
            UIElement parent = (UIElement)VisualTreeHelper.GetParent(element);
            return FindParent<T>(parent);
        }
    }
}
