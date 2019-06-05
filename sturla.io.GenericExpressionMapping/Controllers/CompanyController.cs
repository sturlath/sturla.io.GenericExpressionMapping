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
			// First just get by id (just to show that getting value works)
			var companyDto1 = await service.GetByIdAsync(1).ConfigureAwait(false);

			if (companyDto1.Employees.Count == 0)
			{
				// Just to show that we never get Employees except if we include them.
				// I want to be able to include the connected (seeded) Employees here!
			}

			// Get all the connected Employees and Cars
			var companyDto2 = await service.GetByIdAsync(1, x => x.Employees, x => x.Cars ).ConfigureAwait(false);

			if (companyDto2.Employees.Count == 0)
			{
				throw new NotImplementedException("No employees included even though we seeded two of them. I want this to work!");
			}

			return companyDto2;
		}
	}
}
