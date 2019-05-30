using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
	public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
	{
		public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
