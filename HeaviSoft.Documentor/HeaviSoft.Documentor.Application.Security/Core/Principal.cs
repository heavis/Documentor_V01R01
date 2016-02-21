using HeaviSoft.FrameworkBase.Core.ExpcetionEx;
using HeaviSoft.FrameworkBase.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Application.Security.Core
{
    public class Principal : IPrincipal
    {
        private IIdentity _identity;
        private UserWorkRequest _request;

        public Principal(UserWorkRequest request, IIdentity identity)
        {
            if (request == null)
            {
                throw new FatalException("request arguement can't be null.");
            }
            if (identity == null)
            {
                throw new FatalException("identity arguement can't be null.");
            }

            _request = request;
            _identity = identity;
        }

        public IIdentity Identity { get { return _identity; } }

        public bool IsInRole(string role)
        {
            return _request.IsUserInRole(role);
        }
    }
}
