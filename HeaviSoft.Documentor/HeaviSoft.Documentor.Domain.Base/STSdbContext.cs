using HeaviSoft.Documentor.Persistence.STSdb;
using HeaviSoft.FrameworkBase.Core;
using STSdb4.Database;
using System;
using System.Collections.Generic;
using System.IO;
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
            this.Context = STSdb.FromFile(GetDatabaseFile());
        }

        private string GetDatabaseFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ExtendedApplicationBase.Current.Data[STSdb_FiePath].ToString());
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return filePath;
        }
    }
}
