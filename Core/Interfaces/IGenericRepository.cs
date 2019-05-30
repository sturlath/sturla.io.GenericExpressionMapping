using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IGenericRepository<T>
	{
		Task<T> GetByIdAsync(int id,  Expression<Func<T, object>>[] includes = null);
	}
}
