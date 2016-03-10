using HeaviSoft.FrameworkBase.Utility.Visual;
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

namespace HeaviSoft.FrameworkBase.Component.Docking
{
    /// <summary>
    /// CustomLayoutPanel
    /// </summary>
    [TemplatePart(Name = "PART_HEADER_IMAGE", Type = typeof(Image))]
    [TemplatePart(Name = "PART_PIN_BTN", Type = typeof(Button))]
    public class CustomLayoutPanel : ContentControl
    {
        static CustomLayoutPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomLayoutPanel), new FrameworkPropertyMetadata(typeof(CustomLayoutPanel)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            AttachToVisualTree();
        }

        /// <summary>
        /// 附加界面元素
        /// </summary>
        private void AttachToVisualTree()
        {
            AttachDockLayoutManager();
            AttachHeaderImage();
            AttachPinButton();
        }

        /// <summary>
        /// 附加CustomDockLayoutManager
        /// </summary>
        private void AttachDockLayoutManager()
        {
            DockManager = VisualHelper.FindParent<CustomDockLayoutManager>(this);
        }

        /// <summary>
        /// 附加Pin按钮
        /// </summary>
        private void AttachPinButton()
        {
            if (PinButton != null)
            {
                PinButton.Click += PinButton_Click;
                PinButton.RemoveHandler(ButtonBase.ClickEvent, new RoutedEventHandler(PinButton_Click));
            }
            var pinButton = this.GetChildControl<Button>("PART_PIN_BTN");
            if (pinButton != null)
            {
                pinButton.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(PinButton_Click));
                PinButton = pinButton;
            }
        }


        /// <summary>
        /// 附加Pin图表
        /// </summary>
        private void AttachHeaderImage()
        {
            if (HeaderImage != null)
            {
                //
            }
            var headerImage = this.GetChildControl<Image>("PART_HEADER_IMAGE");
            if (headerImage != null)
            {
                HeaderImage = headerImage;
            }
        }



        #region Visual Element
        public Image HeaderImage { get; set; }
        public Button PinButton { get; set; }
        public CustomDockLayoutManager DockManager { get; set; }
        #endregion

        #region Caption
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
                                                                            "Caption",
                                                                            typeof(string),
                                                                            typeof(CustomLayoutPanel),
                                                                            new PropertyMetadata(""));

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
        #endregion

        #region Event
        private void PinButton_Click(object sender, RoutedEventArgs e)
        {
            if (DockManager == null)
            {
                return;
            }

            if (!DockManager.HasVisibleDockingButton)
            {
                DockManager.UnlockDockingPanel();
            }
            else
            {
                DockManager.LockDockingPanel(this);
            }
        }
        #endregion

        public void SetDockState(bool isDocking)
        {
            if(HeaderImage != null)
            {
                var pinFile = isDocking ? "pin.png" : "pin_horizontal.png";
                HeaderImage.Source = new BitmapImage(new Uri(string.Format("pack://application:,,,/HeaviSoft.FrameworkBase.Component;component/Themes/Images/{0}", pinFile)));
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
