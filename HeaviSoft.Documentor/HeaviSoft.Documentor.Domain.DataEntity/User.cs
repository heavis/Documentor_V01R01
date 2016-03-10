using HeaviSoft.Documentor.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Domain.DataEntity
{
    public class User : IHasKeyEntity<long>
    {
        public long Key { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
    }
}
