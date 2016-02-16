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
    /// 自定义界面
    /// </summary>
    [TemplatePart(Name = "PART_TITLEBAR", Type = typeof(UIElement))]
    [TemplatePart(Name = "PART_CLOSE", Type = typeof(Button))]
    [TemplatePart(Name = "PART_MAXIMIZE_RESTORE", Type = typeof(Button))]
    [TemplatePart(Name = "PART_MINIMIZE", Type = typeof(Button))]
    public class CustomWindow : Window
    {
        static CustomWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomWindow), new FrameworkPropertyMetadata(typeof(CustomWindow)));
        }

        public CustomWindow()
        {
            CreateCommandBindings();
        }

        /// <summary>
        /// 创建绑定命令
        /// </summary>
        private void CreateCommandBindings()
        {
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, (a, b) => { Close(); }));
            CommandBindings.Add(new CommandBinding(MinimizedCommand, (a, b) => { WindowState = WindowState.Minimized; }));
            CommandBindings.Add(new CommandBinding(MaximizeRestoreCommand, (a, b) => { WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized; }));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            AttachToVisualTree();
        }

        /// <summary>
        /// 附加可视化树到模板
        /// </summary>
        private void AttachToVisualTree()
        {
            AttachCloseButton();
            AttachMinButton();
            AttachMaximizeRestoreButton();
            AttachTitleBar();
        }



        /// <summary>
        /// 附加关闭按钮
        /// </summary>
        private void AttachCloseButton()
        {
            if(CloseButton != null)
            {
                CloseButton.Command = null;
            }
            var closeButton = GetChildControl<Button>("PART_CLOSE");
            if(closeButton != null)
            {
                closeButton.Command = ApplicationCommands.Close;
                CloseButton = closeButton;
            }
        }

        /// <summary>
        /// 附加最小化按钮
        /// </summary>
        private void AttachMinButton()
        {
            if(MinimizeButton != null)
            {
                MinimizeButton.Command = null;
            }
            var minimizeButton = GetChildControl<Button>("PART_MINIMIZE");
            if(minimizeButton != null)
            {
                minimizeButton.Command = MinimizedCommand;
                MinimizeButton = minimizeButton;
            }
        }

        /// <summary>
        /// 附加最大化/复原按钮
        /// </summary>
        private void AttachMaximizeRestoreButton()
        {
            if(MaximizeRestoreButton != null)
            {
                MaximizeRestoreButton.Command = null;
            }
            var maximizeRestoreButton = GetChildControl<Button>("PART_MAXIMIZE_RESTORE");
            if(maximizeRestoreButton != null)
            {
                maximizeRestoreButton.Command = MaximizeRestoreCommand;
                MaximizeRestoreButton = maximizeRestoreButton;
            }
        }

        /// <summary>
        /// 附加标题栏
        /// </summary>
        private void AttachTitleBar()
        {
            if(TitleBar != null)
            {
                TitleBar.RemoveHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnTitlebarClick));
            }
            var titleBar = GetChildControl<UIElement>("PART_TITLEBAR");
            if(titleBar != null)
            {
                titleBar.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnTitlebarClick));
                TitleBar = titleBar;
            }
        }

        /// <summary>
        /// 鼠标操作标题栏事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTitlebarClick(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 1)
            {
                if(WindowState != WindowState.Maximized)
                {
                    DragMove();
                }
            } else if(e.ClickCount == 2)
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
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
        /// 关闭按钮
        /// </summary>
        private Button CloseButton { get; set; }

        /// <summary>
        /// 最小化按钮
        /// </summary>
        private Button MinimizeButton { get; set; }

        /// <summary>
        /// 最大化/ 复原 按钮
        /// </summary>
        /// <value>The maximize restore button.</value>
        private Button MaximizeRestoreButton { get; set; }

        /// <summary>
        /// 标题栏
        /// </summary>
        private UIElement TitleBar { get; set; }

        /// <summary>
        /// 最小化指令
        /// </summary>
        private readonly RoutedCommand MinimizedCommand = new RoutedUICommand("Minmize", "Minmize", typeof(CustomWindow));

        /// <summary>
        /// 最大化复原指令
        /// </summary>
        private readonly RoutedCommand MaximizeRestoreCommand = new RoutedUICommand("MaximizeRestore", "MaximizeRestore", typeof(CustomWindow));
    }
}
