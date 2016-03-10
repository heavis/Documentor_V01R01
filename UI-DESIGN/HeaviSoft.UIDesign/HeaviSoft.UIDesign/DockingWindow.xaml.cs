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
    /// Interaction logic for DockingWindow.xaml
    /// </summary>
    public partial class DockingWindow : Window
    {
        private ColumnDefinition _column1ForLayout0;
        private ColumnDefinition _column2ForLayout0;
        private ColumnDefinition _column2ForLayout1;

        public DockingWindow()
        {
            InitializeComponent();

            InitalizeGridColumns();
        }

        private void InitalizeGridColumns()
        {
            _column1ForLayout0 = new ColumnDefinition();
            _column1ForLayout0.SharedSizeGroup = "PART_LAYOUT1_COLUMN1";
            _column2ForLayout0 = new ColumnDefinition();
            _column2ForLayout0.SharedSizeGroup = "PART_LAYOUT2_COLUMN2";
            _column2ForLayout1 = new ColumnDefinition();
            _column2ForLayout1.SharedSizeGroup = "PART_LAYOUT2_COLUMN2";
        }

        #region MouseEnter Event

        private void PART_LAYOUT0_MouseEnter(object sender, MouseEventArgs e)
        {
            if(PART_DOCKING_RIGHT_BTN1.Visibility == Visibility.Visible)
            {
                PART_LAYOUT1.Visibility = Visibility.Collapsed;
            }
            if(PART_DOCKING_RIGHT_BTN2.Visibility == Visibility.Visible)
            {
                PART_LAYOUT2.Visibility = Visibility.Collapsed;
            }
        }

        private void PART_LAYOUT1_MouseEnter(object sender, MouseEventArgs e)
        {
            if(PART_DOCKING_RIGHT_BTN2.Visibility == Visibility.Visible)
            {
                PART_LAYOUT2.Visibility = Visibility.Collapsed;
            }
        }

        private void PART_LAYOUT2_MouseEnter(object sender, MouseEventArgs e)
        {
            if(PART_DOCKING_RIGHT_BTN1.Visibility == Visibility.Visible)
            {
                PART_LAYOUT1.Visibility = Visibility.Collapsed;
            }
        }


        private void PART_DOCKING_RIGHT_BTN1_MouseEnter(object sender, MouseEventArgs e)
        {
            PART_LAYOUT1.Visibility = Visibility.Visible;

            Grid.SetZIndex(PART_LAYOUT1, 1);
            Grid.SetZIndex(PART_LAYOUT2, 0);

            if(PART_DOCKING_RIGHT_BTN2.Visibility == Visibility.Visible)
            {
                PART_LAYOUT2.Visibility = Visibility.Collapsed;
            }
        }

        private void PART_DOCKING_RIGHT_BTN2_MouseEnter(object sender, MouseEventArgs e)
        {
            PART_LAYOUT2.Visibility = Visibility.Visible;

            Grid.SetZIndex(PART_LAYOUT2, 1);
            Grid.SetZIndex(PART_LAYOUT1, 0);

            if(PART_DOCKING_RIGHT_BTN1.Visibility == Visibility.Visible)
            {
                PART_LAYOUT1.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region Click Event


        private void PART_LAYOUT1_PIN_BTN_Click(object sender, RoutedEventArgs e)
        {
            if(PART_DOCKING_RIGHT_BTN1.Visibility == Visibility.Visible)
            {
                DockPanel(1);
            }
            else
            {
                UnDockPanel(1);
            }
        }

        private void PART_LAYOUT2_PIN_BTN_Click(object sender, RoutedEventArgs e)
        {
            if(PART_DOCKING_RIGHT_BTN2.Visibility == Visibility.Visible)
            {
                DockPanel(2);
            }
            else
            {
                UnDockPanel(2);
            }
        }
        #endregion

        #region Dock Method
        private void UnDockPanel(int number)
        {
           if(number == 1)
            {
                PART_LAYOUT1.Visibility = Visibility.Visible;
                PART_DOCKING_RIGHT_BTN1.Visibility = Visibility.Visible;
                PART_LAYOUT1_PIN_IMAGE.Source = new BitmapImage(new Uri("pin.png", UriKind.Relative));

                //移除从layout1克隆到layout0的列；
                PART_LAYOUT0.ColumnDefinitions.Remove(_column1ForLayout0);
                //移除从layout2可能到layout1的列，不一定都会执行；
                PART_LAYOUT1.ColumnDefinitions.Remove(_column2ForLayout1);
            }
           else if(number == 2)
            {
                PART_LAYOUT2.Visibility = Visibility.Visible;
                PART_DOCKING_RIGHT_BTN2.Visibility = Visibility.Visible;
                PART_LAYOUT2_PIN_IMAGE.Source = new BitmapImage(new Uri("pin.png", UriKind.Relative));

                //移除从layout2克隆到layout0的列；
                PART_LAYOUT0.ColumnDefinitions.Remove(_column2ForLayout0);
                //移除从layout2可能到layout1的列，不一定都会执行；
                PART_LAYOUT1.ColumnDefinitions.Remove(_column2ForLayout1);
            }
        }

        private void DockPanel(int number)
        {
            if (number == 1)
            {
                PART_DOCKING_RIGHT_BTN1.Visibility = Visibility.Collapsed;
                PART_LAYOUT1_PIN_IMAGE.Source = new BitmapImage(new Uri("pin_horizontal.png", UriKind.Relative));

                PART_LAYOUT0.ColumnDefinitions.Add(_column1ForLayout0);
                if (PART_DOCKING_RIGHT_BTN2.Visibility == Visibility.Collapsed)
                {
                    PART_LAYOUT1.ColumnDefinitions.Add(_column2ForLayout1);
                }
            }
            else if (number == 2)
            {
                PART_DOCKING_RIGHT_BTN2.Visibility = Visibility.Collapsed;
                PART_LAYOUT2_PIN_IMAGE.Source = new BitmapImage(new Uri("pin_horizontal.png", UriKind.Relative));

                PART_LAYOUT0.ColumnDefinitions.Add(_column2ForLayout0);
                if (PART_DOCKING_RIGHT_BTN1.Visibility == Visibility.Collapsed)
                {
                    PART_LAYOUT1.ColumnDefinitions.Add(_column2ForLayout1);
                }
            }
        }
        #endregion

    }
}
