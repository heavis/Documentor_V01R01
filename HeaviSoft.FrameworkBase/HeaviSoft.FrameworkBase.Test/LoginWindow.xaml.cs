using HeaviSoft.FrameworkBase.Component;
using HeaviSoft.FrameworkBase.Core;
using HeaviSoft.FrameworkBase.Core.Module;
using HeaviSoft.FrameworkBase.Utility;
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

namespace HeaviSoft.FrameworkBase.Test
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginWindow : CustomWindow
    {
        private ExtendedApplicationBase _app;

        public LoginWindow(ExtendedApplicationBase app)
        {
            InitializeComponent();

            _app = app;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(CheckInput())
            {
                _app.Properties[_app.PROPERTY_ACCOUNT] = TBoxAccount.Text.Trim();
                _app.Properties[_app.PROPERTY_PASSWORD] = EncryptHelper.DES3Encrypt(TBoxPassword.Password.Trim());

                if (!_app.ExecuteAutheticationModulesCore())
                {
                    return;
                }
                this.DialogResult = true;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(TBoxAccount.Text.Trim()) || string.IsNullOrEmpty(TBoxPassword.Password.Trim()))
            {
                MessageBox.Show("Account and Password can't be empty.");
                return false;
            }

            return true;
        }
    }
}
