using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core.Security
{
    public sealed class DefaultPrincipal : IPrincipal
    {
        private IIdentity _identity;

        public DefaultPrincipal(IIdentity identity)
        {
            _identity = identity;
        }

        public IIdentity Identity { get { return _identity; } }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}
