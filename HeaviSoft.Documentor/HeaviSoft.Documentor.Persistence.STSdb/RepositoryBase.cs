using HeaviSoft.Documentor.Persistence.Repository;
using STSdb4.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeaviSoft.Documentor.Persistence.STSdb
{
    public abstract class RepositoryBase<TKey, TEntity> : IRepositoryBase<TKey, TEntity> where TEntity : IHasKeyEntity<TKey>
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
            table[CreateKey()] = entity;

            DbContext.Context.Commit();
        }

        public void Delete(TKey id)
        {
            if(!(id is Guid))
            {
                throw new ArgumentException(" argument:id must be type of Guid");
            }

            GetTable().Delete(id);

            DbContext.Context.Commit();
        }

        public TEntity FindById(TKey id)
        {
            var pair = GetTable().FirstOrDefault(pr => pr.Key.Equals(id));
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
        private ITable<TKey, TEntity> GetTable()
        {
            return DbContext.Context.OpenXTable<TKey, TEntity>(typeof(TEntity).Name);
        }

        public abstract TKey CreateKey();
    }
}
