using HeaviSoft.Documentor.Domain.Base;
using HeaviSoft.Documentor.Domain.Repository.Interface;
using System;

namespace HeaviSoft.Documentor.Domain.Repository
{
    public class UnitOfWork : IDisposable
    {
        private STSdbContext _context = new STSdbContext();

        private IUserRepository _userRepository;

        #region Repostitory 

        /// <summary>
        /// UserRepository
        /// </summary>
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        #endregion

        /// <summary>
        /// 保存数据
        /// </summary>
        public void SaveChange()
        {
            _context.Context.Commit();
        }

       

        #region Dispose
        private bool _disposed;
        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
