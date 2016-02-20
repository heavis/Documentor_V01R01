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
using System.Windows.Shapes;

namespace HeaviSoft.UIDesign
{
    /// <summary>
    /// Interaction logic for TestMessageBox.xaml
    /// </summary>
    public partial class TestMessageBox : Window
    {
        public TestMessageBox()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxHelper.Show("Delete", "Do you want to delete selected data?");
        }
    }
}
