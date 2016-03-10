using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// CustomTabItem
    /// </summary>
    [TemplatePart(Name = "PART_BUTTON_CLOSE", Type = typeof(Button))]
    public class CustomTabItem : TabItem
    {
        static CustomTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTabItem), new FrameworkPropertyMetadata(typeof(CustomTabItem)));
        }

        #region CanClose
        public static DependencyProperty CanCloseProperty = DependencyProperty.Register("CanClose", typeof(bool), typeof(CustomTabItem), new PropertyMetadata(true));
     
        public bool CanClose
        {
            get { return (bool)GetValue(CanCloseProperty); }
            set { SetValue(CanCloseProperty, value); }
        }
        #endregion

        private Button CloseButton { get; set; }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            AttachToVisualTree();
        }

        /// <summary>
        /// 添加附加按钮
        /// </summary>
        private void AttachToVisualTree()
        {
            AttachCloseButton();
        }

        /// <summary>
        /// 添加关闭按钮
        /// </summary>
        private void AttachCloseButton()
        {
            if(CloseButton != null)
            {
                CloseButton.RemoveHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonClose_Click));
            }
            var closeButton = this.GetChildControl<Button>("PART_BUTTON_CLOSE");
            if(closeButton != null)
            {
                closeButton.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonClose_Click));
                CloseButton = closeButton;
            }
        }

        /// <summary>
        /// 关闭TabItem事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            var parent = (TabControl)this.Parent;
            if(parent != null && parent.Items.Count > 1)
            {
                parent.Items.Remove(this);
            }
        }

        /// <summary>
        /// 查找子元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controlName"></param>
        /// <returns></returns>
        private T GetChildControl<T>(string controlName) where T : DependencyObject
        {
            T control = GetTemplateChild(controlName) as T;
            return control;
        }
    }
}
