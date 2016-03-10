using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Persistence.Repository
{
    public interface IRepositoryBase<TKey, TEntity> where TEntity : IHasKeyEntity<TKey>
    {
        /// <summary>
        /// 获取所有TEntity
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> Get();

        /// <summary>
        /// 获取单个IEntity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FindById(TKey id);

        /// <summary>
        /// 添加TEntity
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// 删除TEntity
        /// </summary>
        /// <param name="id"></param>
        void Delete(TKey id);

        /// <summary>
        /// 更新TEntity
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// 保存更新
        /// </summary>
        void Save();

        TKey CreateKey();
    }
}
