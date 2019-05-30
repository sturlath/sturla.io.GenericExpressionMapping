using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLayer
{
	public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
	{
		private readonly DbContext dbContext;

		public GenericRepository(DbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<TEntity> GetByIdAsync(int id, Expression<Func<TEntity, object>>[] includes = null)
		{
			try
			{
				if(includes == null)
				{
					return dbContext.Set<TEntity>().Find(id);
				}

				// First attempt (https://deviq.com/specification-pattern/)
				// fetch a Queryable that includes all expression-based includes
				var queryableResultWithIncludes = includes
					.Aggregate(dbContext.Set<TEntity>().AsQueryable(),
						(current, include) => current.Include(include));

				// return the result of the query using the specification's criteria expression
				var test = queryableResultWithIncludes.AsEnumerable();
				
				// Here we get "Code supposed to be unreachable"
				var test2 = test.ToList();

				// Second attempts
				if (includes.Length > 0)
				{
					IQueryable<TEntity> set = includes
					  .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
						(dbContext.Set<TEntity>(), (current, expression) => current.Include(expression));

					// Here we also get "Code supposed to be unreachable"
					return await set.SingleOrDefaultAsync(s => s.Id == id).ConfigureAwait(false);
				}

				return dbContext.Set<TEntity>().Find(id);
			}
			catch (Exception ex)
			{
				//"Code supposed to be unreachable"
				throw;
			}
		}
	}
}
