using HeaviSoft.Documentor.Persistence.Repository;
using HeaviSoft.Documentor.Persistence.STSdb.DataEntity;
using STSdb4.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Persistence.STSdb
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : DbEntity
    {
        private DbContext _context;

        public RepositoryBase(DbContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException("context");
            }
            _context = context;
        }

        public DbContext DbContext
        {
            get { return _context; }
        }

        public void Add(TEntity entity)
        {
            var table = GetTable();
            var key = new Guid();
            table[key] = entity;

            DbContext.Context.Commit();
        }

        public void Delete(object id)
        {
            if(!(id is Guid))
            {
                throw new ArgumentException(" argument:id must be type of Guid");
            }

            GetTable().Delete((Guid)id);

            DbContext.Context.Commit();
        }

        public TEntity FindById(object id)
        {
            if (!(id is Guid))
            {
                throw new ArgumentException(" argument:id must be type of Guid");
            }
            var pair = GetTable().FirstOrDefault(pr => pr.Key == ((Guid)id));
            if(pair.Value != null)
            {
                pair.Value.Key = pair.Key;
            }

            return pair.Value;
        }

        public IEnumerable<TEntity> Get()
        {
            var rows = new List<TEntity>();
            foreach(var row in GetTable())
            {
                row.Value.Key = row.Key;
                rows.Add(row.Value);
            }

            return rows;
        }

        public void Update(TEntity entity)
        {
            var table = GetTable();
            if (table.Exists(entity.Key))
            {
                DbContext.Context.Commit();
            }
        }

        public void Save()
        {
            DbContext.Context.Commit();
        }

        /// <summary>
        /// 获取实体表
        /// </summary>
        /// <returns></returns>
        private ITable<Guid, TEntity> GetTable()
        {
            return DbContext.Context.OpenXTable<Guid, TEntity>(typeof(TEntity).Name);
        }
    }
}
