using HeaviSoft.Documentor.Persistence.STSdb;
using HeaviSoft.FrameworkBase.Core;
using STSdb4.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Domain.Base
{
    public class STSdbContext : DbContext
    {
        private const string STSdb_FiePath = "stsdb";

        public STSdbContext()
        {
            this.Context = STSdb.FromFile(ExtendedApplicationBase.Current.Data[STSdb_FiePath].ToString());
        }
    }
}
