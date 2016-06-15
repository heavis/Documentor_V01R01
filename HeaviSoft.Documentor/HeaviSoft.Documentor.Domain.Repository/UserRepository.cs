using HeaviSoft.Documentor.Domain.DataEntity;
using HeaviSoft.Documentor.Domain.Repository.Interface;
using HeaviSoft.Documentor.Persistence.STSdb;
using HeaviSoft.Documentor.Persistence.STSdb.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Domain.Repository
{
    public class UserRepository : RepositoryBase<long, User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User GetUserByName(string name)
        {
            return DbContext.Context.OpenXTable<long, User>( ).FirstOrDefault(pair => pair.Value.Name == name).Value;
        }

        public override long CreateKey()
        {
            long key = 0;
            var usrTable = DbContext.Context.OpenXTable<long, User>();
            if (usrTable != null && usrTable.Any())
            {
                key = DbContext.Context.OpenXTable<long, User>().Max(pair => pair.Key);
            }
            return key + 1;
        }
    }
}
