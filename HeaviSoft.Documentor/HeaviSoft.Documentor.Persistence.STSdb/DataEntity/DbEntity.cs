using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Persistence.STSdb.DataEntity
{
    public abstract class DbEntity
    {
        public Guid Key { get; set; }
    }
}
