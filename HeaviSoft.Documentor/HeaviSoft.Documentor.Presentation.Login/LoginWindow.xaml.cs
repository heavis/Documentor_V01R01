using HeaviSoft.FrameworkBase.Component;
using HeaviSoft.FrameworkBase.Extension;
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

namespace HeaviSoft.Documentor.Presentation.Login
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            this.CTBoxUserName.Text = "";
            this.CPBoxPassword.Text = "";
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput())
            {
                //开始验证

            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(CTBoxUserName.Text))
            {
                //请输入用户名
                MessageBoxHelper.Info("Tips", "Please input user name.");
                return false;
            }
            if (string.IsNullOrEmpty(CPBoxPassword.Password.GetOrginalString()))
            {
                //请输入密码
                MessageBoxHelper.Info("Tips", "Please input password.");
                return false;
            }

            return true;
        }

        #region Event
        /// <summary>
        /// 鼠标拖动窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 1)
            {
                this.DragMove();
            }
        }
        #endregion
    }
}
