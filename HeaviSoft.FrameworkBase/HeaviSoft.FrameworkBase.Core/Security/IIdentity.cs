using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core.Security
{
    public interface IIdentity
    {
        bool IsAuthenticated { get; }
        string Name { get; set; }
    }
}
