using HeaviSoft.FrameworkBase.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeaviSoft.FrameworkBase.Core;
using HeaviSoft.FrameworkBase.Utility;
using System.Threading;

namespace HeaviSoft.FrameworkBase.Test.Implemnents
{
    public class AuthenticationModule : IAuthenticationModule
    {
        public bool Authenticate(ExtendedApplicationBase app)
        {
            AuthenticationWindow loadingWindow = new AuthenticationWindow();
            loadingWindow.Show();

            var account = app.Properties[app.PROPERTY_ACCOUNT];
            var password = app.Properties[app.PROPERTY_PASSWORD];

            if(account == null || password == null)
            {
                loadingWindow.Close();
                return false;
            }

            if(Authenticate(account.ToString(), password.ToString())){
                //1. 获取用户信息
                UserWorkRequest request = new UserWorkRequest();
                var identity = new Identity(account.ToString(), true);
                app.Context.User = new Principal(request, identity);
                Thread.Sleep(5000);
                loadingWindow.Close();

                return true;
            }
            loadingWindow.Close();
            return false;
        }

        private bool Authenticate(string account, string password)
        {
            if(string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            return account == "test" && EncryptHelper.DES3Encrypt("test") == password;
        }
    }
}
