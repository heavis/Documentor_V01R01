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
    /// CustomDocumentPanel
    /// </summary>
    public class CustomDocumentPanel : ContentControl
    {
        static CustomDocumentPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomDocumentPanel), new FrameworkPropertyMetadata(typeof(CustomDocumentPanel)));
        }

        #region Caption
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
                                                                            "Caption",
                                                                            typeof(string),
                                                                            typeof(CustomDocumentPanel),
                                                                            new PropertyMetadata(""));

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
        #endregion

        public override string ToString()
        {
            return Caption;
        }
    }
}
