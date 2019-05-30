using Core.Entities;
using Core.Interfaces;
using Core.Models;

namespace ServiceLayer
{
	public class CompanyService : GenericService<CompanyDto,Company>, ICompanyService
	{
		public CompanyService(ICompanyRepository repository, AutoMapper.IMapper mapper) : base(repository, mapper)
		{
		}
	}
}
