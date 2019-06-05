using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IGenericService<T>
	{
		Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
	}
}
