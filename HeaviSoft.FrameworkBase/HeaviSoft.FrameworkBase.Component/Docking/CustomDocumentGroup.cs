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
    /// CustomDocumentGroup
    /// </summary>
    public class CustomDocumentGroup : ItemsControl
    {
        static CustomDocumentGroup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomDocumentGroup), new FrameworkPropertyMetadata(typeof(CustomDocumentGroup)));
        }
    }
}
