using HeaviSoft.FrameworkBase.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeaviSoft.FrameworkBase.Core;
using HeaviSoft.FrameworkBase.Utility;
using HeaviSoft.FrameworkBase.Extension;
using System.Windows;

namespace HeaviSoft.FrameworkBase.Test.Implemnents
{
    public class LoginModule : ILoginModule
    {
        public bool Login(ExtendedApplicationBase app)
        {
            var loginWindow = new LoginWindow(app);
            var result = loginWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                return true;
            }

            return false;
        }

        public void LoginFailed(ExtendedApplicationBase app, object message)
        {
            MessageBox.Show(message.ToString());
        }

        public void LoginSuccessed(ExtendedApplicationBase app, object message)
        {
        }
    }
}
