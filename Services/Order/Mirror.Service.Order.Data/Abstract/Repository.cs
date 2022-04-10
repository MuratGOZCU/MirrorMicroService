using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Mirror.Service.Order.Core.Abstract;
using Mirror.Service.Order.Data.Context;

namespace Mirror.Service.Order.Data.Abstract
{
	public abstract class Repository<T> : IRepository<T>  where T : BaseEntity
    {
        protected DbContext _context;
        protected DbSet<T> DbSet { get; }

        public Repository(MirrorDbContext context)
		{
            _context = context;
            DbSet = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return DbSet;
        }


        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await DbSet.Where(expression).ToListAsync();
        }

        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

      
    }
}

