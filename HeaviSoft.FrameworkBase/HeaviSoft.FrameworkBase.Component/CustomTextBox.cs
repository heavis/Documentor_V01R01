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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeaviSoft.FrameworkBase.Component
{
    /// <summary>
    /// 自定义TextBox
    /// </summary>
    public class CustomTextBox : TextBox
    {
        /// <summary>
        /// 设置默认样式
        /// </summary>
        static CustomTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTextBox), new FrameworkPropertyMetadata(typeof(CustomTextBox)));
        }

        /// <summary>
        /// 应用样式
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        #region MarkTextProperty
        public static readonly DependencyProperty MarkTextProperty = DependencyProperty.Register("MarkText", typeof(string), typeof(CustomTextBox), new PropertyMetadata(""));
        
        public string MarkText
        {
            get { return (string)GetValue(MarkTextProperty); }
            set { SetValue(MarkTextProperty, value); }
        }
        
        #endregion
    }
}
