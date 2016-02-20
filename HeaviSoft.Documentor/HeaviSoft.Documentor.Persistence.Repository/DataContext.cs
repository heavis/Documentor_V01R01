using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Persistence.Repository
{
    public abstract class Context : IDisposable
    {
        public abstract void Dispose();
    }
}
