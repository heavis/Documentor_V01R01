using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core.Module
{
    public interface IExecutionModule
    {
        void Execute(ExtendedApplicationBase app);
    }
}
