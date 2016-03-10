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
    /// CustomLayoutGroup
    /// </summary>
    public class CustomLayoutGroup : ItemsControl
    {
        static CustomLayoutGroup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomLayoutGroup), new FrameworkPropertyMetadata(typeof(CustomLayoutGroup)));
        }
    }
}
