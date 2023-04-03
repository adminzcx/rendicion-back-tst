
using Prome.Viaticos.Server.Application._Common.Interfaces;

namespace Prome.Viaticos.Server.Infraestructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Prome.Viaticos.Server.Application.Common.Interfaces;
    using Prome.Viaticos.Server.Domain._Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class Repository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext
                .Set<T>()
                .FindAsync(id);
        }

        public async Task<T> GetByIdWithIncludesAsync(long id, ICollection<Expression<Func<T, object>>> includes)
        {
            var dbSet = _dbContext.Set<T>();
            AddIncludes(dbSet, includes);

            return await dbSet.FindAsync(id);
        }

        public async Task<T> GetByIdWithIncludesAsync(long id, ICollection<string> includeStrings)
        {
            var dbSet = _dbContext.Set<T>();
            AddIncludes(dbSet, includeStrings);

            return await dbSet.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> SingleOrDefaultAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).SingleOrDefaultAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        private void AddIncludes(DbSet<T> dbSet, ICollection<Expression<Func<T, object>>> includes)
        {
            foreach (var include in includes)
            {
                dbSet.Include(include);
            }
        }

        private void AddIncludes(DbSet<T> dbSet, ICollection<string> IncludeStrings)
        {
            foreach (var include in IncludeStrings)
            {
                dbSet.Include(include);
            }
        }
    }
}
