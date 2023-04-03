using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain._Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application._Common.Interfaces
{


    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id);

        Task<T> GetByIdWithIncludesAsync(long id, ICollection<Expression<Func<T, object>>> includes);

        Task<T> GetByIdWithIncludesAsync(long id, ICollection<string> includeStrings);

        Task<IReadOnlyCollection<T>> ListAllAsync();

        Task<IReadOnlyCollection<T>> ListAsync(ISpecification<T> spec);

        Task<T> SingleOrDefaultAsync(ISpecification<T> spec);

        Task<T> FirstOrDefaultAsync(ISpecification<T> spec);

        Task<T> AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<int> CountAsync(ISpecification<T> spec);

    }
}
