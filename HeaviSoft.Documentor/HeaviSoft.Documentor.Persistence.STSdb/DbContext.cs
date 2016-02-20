using HeaviSoft.Documentor.Persistence.Repository;
using STSdb4.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Persistence.STSdb
{
    public abstract class DbContext : Context
    {
        /// <summary>
        /// STSdb上下文
        /// </summary>
        public IStorageEngine Context { get; protected set; }

        #region Dispose
        private bool _disposed;

        /// <summary>
        /// 释放资源，可重写
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
