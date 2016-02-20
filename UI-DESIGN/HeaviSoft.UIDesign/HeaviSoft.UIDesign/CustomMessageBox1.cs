using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HeaviSoft.UIDesign
{
    /// <summary>
    /// 自定义MessageBox
    /// </summary>
    [TemplatePart(Name = "PART_TITLEBAR", Type = typeof(UIElement))]
    [TemplatePart(Name = "PART_TITLEBAR_TITLE", Type = typeof(UIElement))]
    [TemplatePart(Name = "PART_IMAGETIP", Type = typeof(Image))]
    [TemplatePart(Name = "PART_CONTENT", Type = typeof(TextBlock))]
    public class CustomMessageBox : Window
    {
        private object _content;

        static CustomMessageBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomMessageBox), new FrameworkPropertyMetadata(typeof(CustomMessageBox)));
        }

        public CustomMessageBox(string title, object content) : this(title, content, MessageBoxButton.OK)
        {
        }

        public CustomMessageBox(string title, object content, MessageBoxButton button)
        {
            this.Title = title;
            this._content = content;
            this.MessageBoxButton = button;
        }

        //1.PART_TITLEBAR添加 DockPanel_MouseLeftButtonDown事件
        //2.PART_CONTENT添加内容
        private UIElement TitleBar { get; set; }

        private TextBlock ToolTipContent { get; set; }

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
            AttachTitleBar();
            AttachToolTipContent();
        }

        /// <summary>
        /// 附加TitleBar
        /// </summary>
        private void AttachTitleBar()
        {
            if (TitleBar != null)
            {
                TitleBar.RemoveHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(TitleBar_MouseLeftButtonDown));
            }
            var titleBar = this.GetChildControl<UIElement>("PART_TITLEBAR");
            if (titleBar != null)
            {
                titleBar.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(TitleBar_MouseLeftButtonDown));
                TitleBar = titleBar;
            }
        }

        /// <summary>
        /// 附加ToolTipContent
        /// </summary>
        private void AttachToolTipContent()
        {
            if (ToolTipContent != null)
            {
                ToolTipContent.Text = string.Empty;
            }
            var toolTipContent = this.GetChildControl<TextBlock>("PART_CONTENT");
            if (toolTipContent != null)
            {
                toolTipContent.Text = _content == null ? "" : _content.ToString();
                ToolTipContent = toolTipContent;
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



        /// <summary>
        /// 鼠标拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// MessageBoxButton
        /// </summary>
        public readonly DependencyProperty MessageBoxButtonProperty = DependencyProperty.Register("MessageBoxButton", typeof(MessageBoxButton), typeof(CustomMessageBox), new PropertyMetadata(MessageBoxButton.OK));

        public MessageBoxButton MessageBoxButton
        {
            get { return (MessageBoxButton)GetValue(MessageBoxButtonProperty); }
            set { SetValue(MessageBoxButtonProperty, value); }
        }
    }
}
