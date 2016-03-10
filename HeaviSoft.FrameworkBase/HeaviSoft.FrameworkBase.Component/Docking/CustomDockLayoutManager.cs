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

namespace HeaviSoft.FrameworkBase.Component.Docking
{
    /// <summary>
    /// CustomDockLayoutManager
    /// </summary>
    [TemplatePart(Name = "PART_LAYOUT0_TABCONTROL", Type = typeof(CustomTabControl))]
    [TemplatePart(Name = "PART_LAYOUT1_TABCONTROL", Type = typeof(CustomTabControl))]
    [TemplatePart(Name = "PART_DOCKING_RIGHT", Type = typeof(StackPanel))]
    [TemplatePart(Name = "PART_LAYOUT1", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_LAYOUT0", Type = typeof(Grid))]
    public class CustomDockLayoutManager : Control
    {
        #region Private Field
        private const string Grid_Layout1_Column1_Name = "PART_LAYOUT1_COLUMN1";
        private ColumnDefinition _colomn1ForLayout0;
        #endregion

        static CustomDockLayoutManager()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomDockLayoutManager), new FrameworkPropertyMetadata(typeof(CustomDockLayoutManager)));
        }

        public CustomDockLayoutManager()
        {
            CustomDocumentGroup = new CustomDocumentGroup();
            CustomLayoutGroup = new CustomLayoutGroup();
            _colomn1ForLayout0 = new ColumnDefinition();
            _colomn1ForLayout0.SharedSizeGroup = Grid_Layout1_Column1_Name;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            AttachToVisualTree();
        }

        #region Visual Control
        private CustomTabControl DocumentTabControl { get; set; }
        private CustomTabControl LayoutTabContorl { get; set; }
        private StackPanel DockingPanel { get; set; }
        private Grid DockingLayout1 { get; set; }
        private Grid DockingLayout0 { get; set; }

        //停靠按钮集合
        private List<Button> DockingButtonList
        {
            get { return DockingPanel.Children.Cast<Button>().ToList(); }
        }

        //停靠LayoutPanel集合
        private List<CustomLayoutPanel> LayoutPanelList
        {
            get {
                return CustomLayoutGroup != null ? CustomLayoutGroup.Items.Cast<CustomLayoutPanel>().ToList() : new List<CustomLayoutPanel>(); }
        }

        //停靠按钮可见
        public bool HasVisibleDockingButton
        {
            get { return DockingButtonList.Any(btn => btn.Visibility == Visibility.Visible); }
        }

        #endregion

        #region Attach Visual Tree
        /// <summary>
        /// 添加附加按钮
        /// </summary>
        private void AttachToVisualTree()
        {
            AttachDocumentTabControl();
            AttachLayoutTabContorl();
            AttachDockingPanel();
            AttachDockingLayout();
        }

        private void AttachDockingLayout()
        {
            //Layout1
            var dockingLayout = this.GetChildControl<Grid>("PART_LAYOUT1");
            if (dockingLayout != null)
            {
                DockingLayout1 = dockingLayout;
            }

            //Layout0
            if (DockingLayout0 != null)
            {
                DockingLayout0.RemoveHandler(UIElement.MouseEnterEvent, new MouseEventHandler(DockingLayout_MouseEnter));
            }
            dockingLayout = this.GetChildControl<Grid>("PART_LAYOUT0");
            if (dockingLayout != null)
            {
                dockingLayout.AddHandler(UIElement.MouseEnterEvent, new MouseEventHandler(DockingLayout_MouseEnter));
                DockingLayout0 = dockingLayout;
            }
        }

        /// <summary>
        /// Layout0 MouseEnter
        /// </summary>
        private void DockingLayout_MouseEnter(object sender, MouseEventArgs e)
        {
            //停靠的button可见，隐藏Layout1
            if (HasVisibleDockingButton)
            {
                DockingLayout1.Visibility = Visibility.Collapsed;
            }
        }

        private void AttachDockingPanel()
        {
            if (DockingPanel != null)
            {
                DockingPanel.Children.Clear();
            }
            var panel = this.GetChildControl<StackPanel>("PART_DOCKING_RIGHT");
            if (panel != null)
            {
                foreach (var layoutPanel in LayoutPanelList)
                {
                    #region Docking Button Event
                    var button = new Button() { Content = layoutPanel.Caption };
                    // Docking Button MouseEnter Event
                    button.MouseEnter += (sender, e) =>
                    {
                        if (DockingLayout1.Visibility != Visibility.Visible)
                        {
                            DockingLayout1.Visibility = Visibility.Visible;
                        }
                        //LayoutTabControl的页签切换到当前button对应的页签
                        LayoutTabContorl.SelectedIndex = CustomLayoutGroup.Items.Cast<CustomLayoutPanel>().ToList().IndexOf(layoutPanel);
                    };
                    // Docking Button Click Event
                    button.Click += (sender, e) =>
                    {
                        LockDockingPanel(layoutPanel);
                    };
                    #endregion
                    panel.Children.Add(button);
                }
                DockingPanel = panel;
            }
        }

        private void AttachLayoutTabContorl()
        {
            if (LayoutTabContorl != null)
            {
                LayoutTabContorl.Items.Clear();
            }
            var tabControl = this.GetChildControl<CustomTabControl>("PART_LAYOUT1_TABCONTROL");
            if (tabControl != null)
            {
                foreach (var layoutPanel in LayoutPanelList)
                {
                    tabControl.Items.Add(new CustomTabItem() { Header = layoutPanel.Caption, Content = layoutPanel, CanClose = false });
                }

                LayoutTabContorl = tabControl;
            }
        }

        private void AttachDocumentTabControl()
        {
            if (DocumentTabControl != null)
            {
                DocumentTabControl.Items.Clear();
            }
            var tabControl = this.GetChildControl<CustomTabControl>("PART_LAYOUT0_TABCONTROL");
            if (tabControl != null)
            {
                if (CustomDocumentGroup != null)
                {
                    foreach (var documentPanel in CustomDocumentGroup.Items.Cast<CustomDocumentPanel>())
                    {
                        tabControl.Items.Add(new CustomTabItem() { Header = documentPanel.Caption, Content = documentPanel });
                    }
                }

                DocumentTabControl = tabControl;
            }
        }

        public void LockDockingPanel(CustomLayoutPanel selectedLayoutPanel)
        {
            //1.设置Layout0的共享列
            DockingLayout0.ColumnDefinitions.Add(_colomn1ForLayout0);
            //2.设置Layout1中浮动窗项的Image图片路径
            CustomLayoutGroup.Items.Cast<CustomLayoutPanel>().ToList().ForEach(layout => {
                layout.SetDockState(true);
            });
            //3.LayoutTabControl的页签切换到当前button对应的页签
            LayoutTabContorl.SelectedIndex = LayoutPanelList.IndexOf(selectedLayoutPanel);
            //4.设置右边StackPanel的Button的可见性为Collapse
            DockingButtonList.ForEach(btn => btn.Visibility = Visibility.Collapsed);
        }

        public void UnlockDockingPanel()
        {
            DockingLayout0.ColumnDefinitions.Remove(_colomn1ForLayout0);
            DockingLayout1.Visibility = Visibility.Visible;
            LayoutPanelList.ForEach(layout => {
                layout.SetDockState(false);
            });
            DockingButtonList.ForEach(btn => btn.Visibility = Visibility.Visible);
        }

        #endregion

        #region CustomLayoutGroup
        public static readonly DependencyProperty CustomLayoutGroupProperty = DependencyProperty.Register(
                                                                            "CustomLayoutGroup",
                                                                            typeof(CustomLayoutGroup),
                                                                            typeof(CustomDockLayoutManager),
                                                                            new PropertyMetadata(null));

        public CustomLayoutGroup CustomLayoutGroup
        {
            get { return (CustomLayoutGroup)GetValue(CustomLayoutGroupProperty); }
            set { SetValue(CustomLayoutGroupProperty, value); }
        }
        #endregion

        #region CustomDocumentGroup
        public static readonly DependencyProperty CustomDocumentGroupProperty = DependencyProperty.Register(
                                                                              "CustomDocumentGroup",
                                                                              typeof(CustomDocumentGroup),
                                                                              typeof(CustomDockLayoutManager),
                                                                              new PropertyMetadata(null)
                                                                            );

        public CustomDocumentGroup CustomDocumentGroup
        {
            get { return (CustomDocumentGroup)GetValue(CustomDocumentGroupProperty); }
            set { SetValue(CustomDocumentGroupProperty, value); }
        }
        #endregion

        #region Help Method
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
   
        #endregion
    }
}
