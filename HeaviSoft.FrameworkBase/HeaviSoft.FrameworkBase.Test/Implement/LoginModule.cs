using HeaviSoft.FrameworkBase.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeaviSoft.FrameworkBase.Core;

namespace HeaviSoft.FrameworkBase.Test.Implement
{
    public class LoginModule : ILoginModule
    {
        public void Login(ExtendedApplicationBase app)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }

        public void LoginFailed(ExtendedApplicationBase app, object message)
        {
            throw new NotImplementedException();
        }

        public void LoginSuccessed(ExtendedApplicationBase app, object message)
        {
            throw new NotImplementedException();
        }
    }
}
