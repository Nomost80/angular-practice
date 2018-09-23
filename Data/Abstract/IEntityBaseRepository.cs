using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Model;

namespace Data.Abstract
{
	public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
	{
		int Count();
		IEnumerable<T> GetAll();
		IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
		IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
		T GetSingle(int id);
		T GetSingle(Expression<Func<T, bool>> predicate);
		T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		void DeleteWhere(Expression<Func<T, bool>> predicate);
		void Commit();
	}
}