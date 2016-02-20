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
    /// 自定义MessageBox
    /// </summary>
    [TemplatePart(Name = "PART_TITLEBAR", Type = typeof(UIElement))]
    [TemplatePart(Name = "PART_TITLEBAR_TITLE", Type = typeof(UIElement))]
    [TemplatePart(Name = "PART_IMAGETIP", Type = typeof(Image))]
    [TemplatePart(Name = "PART_CONTENT", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_BUTTON_OK", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_BUTTON_CANCEL", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_BUTTON_YES", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_BUTTON_NO", Type = typeof(TextBlock))]
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

        private UIElement TitleBar { get; set; }

        private TextBlock ToolTipContent { get; set; }

        private Button ButtonOk { get; set; }

        private Button ButtonCanel { get; set; }

        private Button ButtonYes { get; set; }

        private Button ButtonNo { get; set; }

        public MessageBoxResult MessageBoxResult { get; private set; }

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
            AttachButton();
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
        /// 附加Button
        /// </summary>
        private void AttachButton()
        {
            #region ButtonOk
            if(ButtonOk != null)
            {
                ButtonOk.RemoveHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonOk_Click));
            }
            var buttonOk = GetChildControl<Button>("PART_BUTTON_OK");
            if(buttonOk != null)
            {
                buttonOk.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonOk_Click));
                ButtonOk = buttonOk;
            }
            #endregion

            #region
            if(ButtonCanel != null)
            {
                ButtonCanel.RemoveHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonCancel_Click));
            }
            var buttonCancel = GetChildControl<Button>("PART_BUTTON_CANCEL");
            if(buttonCancel != null)
            {
                buttonCancel.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonCancel_Click));
                ButtonCanel = buttonCancel;
            }

            #endregion

            #region ButtonYes
            if (ButtonYes != null)
            {
                ButtonYes.RemoveHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonYes_Click));
            }
            var buttonYes = GetChildControl<Button>("PART_BUTTON_YES");
            if(buttonYes != null)
            {
                buttonYes.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonYes_Click));
                ButtonYes = buttonYes;
            }
            #endregion

            #region ButonNo
            if (ButtonNo != null)
            {
                ButtonNo.RemoveHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonNo_Click));
            }
            var buttonNo = GetChildControl<Button>("PART_BUTTON_NO");
            if(buttonNo != null)
            {
                buttonNo.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonNo_Click));
                ButtonNo = buttonNo;
            }
            #endregion
        }

        #region Button Event
        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.Cancel;
            Close();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.Yes;
            Close();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.No;
            Close();
        }
        #endregion


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
        public static readonly DependencyProperty MessageBoxButtonProperty = DependencyProperty.Register("MessageBoxButton", typeof(MessageBoxButton), typeof(CustomMessageBox), new PropertyMetadata(MessageBoxButton.OK));

        public MessageBoxButton MessageBoxButton
        {
            get { return (MessageBoxButton)GetValue(MessageBoxButtonProperty); }
            set { SetValue(MessageBoxButtonProperty, value); }
        }
    }
}
