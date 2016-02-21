using HeaviSoft.FrameworkBase.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeaviSoft.FrameworkBase.Core;
using HeaviSoft.FrameworkBase.Component;

namespace HeaviSoft.Documentor.Presentation.Login.Implements
{
    public class LoginModule : ILoginModule
    {
        public bool Login(ExtendedApplicationBase app)
        {
            LoginWindow login = new LoginWindow(app);
            var dialogResult = login.ShowDialog();

            return dialogResult.HasValue && dialogResult.Value;
        }

        public void LoginFailed(ExtendedApplicationBase app, object message)
        {
            MessageBoxHelper.Info("Tips", message);
        }

        public void LoginSuccessed(ExtendedApplicationBase app, object message)
        {
        }
    }
}
