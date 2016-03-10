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
            return DbContext.Context.OpenXTable<long, User>().Where( pair => pair.Value.Name == name).FirstOrDefault().Value;
        }

        public override long CreateKey()
        {
            return DbContext.Context.OpenXTable<long, User>().Max(pair => pair.Key) + 1;
        }
    }
}
