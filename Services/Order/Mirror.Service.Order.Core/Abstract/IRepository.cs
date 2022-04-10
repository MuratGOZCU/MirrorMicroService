using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mirror.Service.Order.Core.Abstract
{
	public interface IRepository<T> where T : BaseEntity
	{
		IQueryable<T> Query();
		Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);


	}
}

