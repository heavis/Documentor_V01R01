using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Persistence.Repository
{
    public interface IHasKeyEntity<TKey>
    {
        TKey Key { get; set; }
    }
}
