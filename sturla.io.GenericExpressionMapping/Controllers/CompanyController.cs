using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace sturla.io.GenericExpressionMapping.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService service;

		public CompanyController(ICompanyService service)
		{
			this.service = service;
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public async Task<CompanyDto> GetAsync(int id)
		{
			// First just get by id
			var companyDto1 = await service.GetByIdAsync(1).ConfigureAwait(false);

			if (companyDto1.Employees.Count == 0)
			{
				// No employees included even though we seeded two of them.
			}

			Expression<Func<CompanyDto, object>>[] includes = { x => x.Employees, x => x.Cars };

			var companyDto2 = await service.GetByIdAsync(1, includes).ConfigureAwait(false);

			if (companyDto2.Employees.Count == 0)
			{
				// No employees included even though we seeded two of them.
			}
			return companyDto2;
		}
	}
}
