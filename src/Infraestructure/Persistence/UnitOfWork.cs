using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain._Common;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Infraestructure.Persistence
{
    public class UnitOfWork : IAsyncUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private Hashtable _repositories;

        public UnitOfWork(
            ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CommitAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(TEntity)), _applicationDbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }

        #region Implement Disposable pattern 

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
                _applicationDbContext.Dispose();

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}
