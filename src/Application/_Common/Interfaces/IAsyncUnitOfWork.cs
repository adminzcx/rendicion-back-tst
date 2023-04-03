

using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Domain._Common;

namespace Prome.Viaticos.Server.Application.Common.Interfaces
{

    using System;
    using System.Threading.Tasks;

    public interface IAsyncUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        Task CommitAsync();
    }
}
