using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new()
    {
        private ApplicationDbContext _applicationDbContext;

	    public EntityBaseRepository(ApplicationDbContext applicationDbContext)
	    {
		    _applicationDbContext = applicationDbContext;
	    }
	    
	    public int Count()
	    {
		    return _applicationDbContext.Set<T>().Count();
	    }

	    public IEnumerable<T> GetAll()
	    {
		    return _applicationDbContext.Set<T>().AsEnumerable();
	    }

	    public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
	    {
		    IQueryable<T> query = _applicationDbContext.Set<T>();
		    query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		    return query.AsEnumerable();
	    }

	    public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
	    {
		    return _applicationDbContext.Set<T>().Where(predicate);
	    }

	    public T GetSingle(int id)
	    {
		    return _applicationDbContext.Set<T>().FirstOrDefault(x => x.Id == id);
	    }

	    public T GetSingle(Expression<Func<T, bool>> predicate)
	    {
		    return _applicationDbContext.Set<T>().FirstOrDefault(predicate);
	    }

	    public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
	    {
		    IQueryable<T> query = _applicationDbContext.Set<T>();
		    query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		    return query.Where(predicate).FirstOrDefault();
	    }

	    public void Add(T entity)
	    {
		    EntityEntry dbEntityEntry = _applicationDbContext.Entry<T>(entity);
		    _applicationDbContext.Set<T>().Add(entity);
	    }

	    public void Update(T entity)
	    {
		    EntityEntry dbEntityEntry = _applicationDbContext.Entry<T>(entity);
		    dbEntityEntry.State = EntityState.Modified;
	    }

	    public void Delete(T entity)
	    {
		    EntityEntry dbEntityEntry = _applicationDbContext.Entry<T>(entity);
		    dbEntityEntry.State = EntityState.Deleted;
	    }

	    public void DeleteWhere(Expression<Func<T, bool>> predicate)
	    {
		    IEnumerable<T> entities = _applicationDbContext.Set<T>().Where(predicate);
		    foreach(var entity in entities)
			    _applicationDbContext.Entry<T>(entity).State = EntityState.Deleted;
	    }

	    public void Commit()
	    {
		    _applicationDbContext.SaveChanges();
	    }
    }
}