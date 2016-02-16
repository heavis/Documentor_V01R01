using HeaviSoft.FrameworkBase.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Test.Implemnents
{
    public class Identity : IIdentity
    {
        public Identity(string name, bool isAuthenticated)
        {
            Name = name;
            IsAuthenticated = isAuthenticated;
        }

        public bool IsAuthenticated { get; private set; }

        public string Name { get; private set; }
    }
}
