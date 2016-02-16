using HeaviSoft.FrameworkBase.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeaviSoft.FrameworkBase.Core;

namespace HeaviSoft.Documentor.Presentation.Login.Implements
{
    public class LoginModule : ILoginModule
    {
        public bool Login(ExtendedApplicationBase app)
        {
            LoginWindow login = new LoginWindow();
            login.ShowDialog();

            return true;
        }

        public void LoginFailed(ExtendedApplicationBase app, object message)
        {
            
        }

        public void LoginSuccessed(ExtendedApplicationBase app, object message)
        {
            
        }
    }
}
