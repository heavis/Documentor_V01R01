using STSdb4.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Persistence.STSdb.Extension
{
    public static class StorageEngineEx
    {
        public static ITable<TKey, TRecord> OpenXTable<TKey, TRecord>(this IStorageEngine engine)
        {
            return engine.OpenXTable<TKey, TRecord>(typeof(TRecord).Name);
        }
    }
}
