using HeaviSoft.Documentor.Domain.DataEntity;
using HeaviSoft.Documentor.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Domain.Repository.Interface
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetUserByName(string name);
    }
}
