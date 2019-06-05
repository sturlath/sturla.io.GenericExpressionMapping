using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServiceLayer
{
	public abstract class GenericService<Dto, Entity> : IGenericService<Dto> where Dto : BaseDto where Entity : BaseEntity
	{
		public readonly IGenericRepository<Entity> repository;
		private readonly IMapper mapper;

		public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<Dto> GetByIdAsync(int id, params Expression<Func<Dto, object>>[] includes )
		{
			try
			{
				// dto includes mapped to my entity includes
				var entityIncludes = mapper.Map<Expression<Func<Entity, object>>[]>(includes);

				var result = await repository.GetByIdAsync(id, entityIncludes).ConfigureAwait(false);

				return mapper.Map<Dto>(result);
			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}
