using HeaviSoft.Documentor.Persistence.STSdb.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Domain.DataEntity
{
    public class User : DbEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
