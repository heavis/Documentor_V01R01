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
            //默认TRecord为byte[]类型，需要强制转换为强类型
            if(engine[typeof(TRecord).Name] != null)
            {
                engine[typeof(TRecord).Name].RecordType = typeof(TRecord);
            }
            
            return engine.OpenXTable<TKey, TRecord>(typeof(TRecord).Name);
        }
    }
}
