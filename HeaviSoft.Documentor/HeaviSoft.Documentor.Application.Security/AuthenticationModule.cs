using HeaviSoft.FrameworkBase.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeaviSoft.FrameworkBase.Core;
using HeaviSoft.Documentor.Domain.Repository;
using HeaviSoft.Documentor.Application.Security.Core;

namespace HeaviSoft.Documentor.Application.Security
{
    public class AuthenticationModule : IAuthenticationModule
    {
        public bool Authenticate(ExtendedApplicationBase app)
        {
            var account = app.Data[app.PROPERTY_ACCOUNT];
            var password = app.Data[app.PROPERTY_PASSWORD];

            if (account == null || password == null)
            {
                return false;
            }

            using(var work = new UnitOfWork())
            {
                var user = work.UserRepository.GetUserByName(account.ToString());
                if( user != null && user.Password == password.ToString())
                {
                    UserWorkRequest request = new UserWorkRequest();
                    var identity = new Identity(account.ToString(), true);
                    app.Context.User = new Principal(request, identity);

                    return true;
                }
            }

            return false;
        }
    }
}
