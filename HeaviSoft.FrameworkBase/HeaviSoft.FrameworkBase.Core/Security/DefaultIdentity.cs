using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core.Security
{
    public sealed class DefaultIdentity : IIdentity
    {
        public bool IsAuthenticated { get { return false; } }

        public string Name { get { return null; } }
    }
}
