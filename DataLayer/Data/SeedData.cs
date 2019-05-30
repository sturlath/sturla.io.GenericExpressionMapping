using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Data
{
	public static class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
			{
				SeedDB(context);
			}
		}

		private static void SeedDB(ApplicationDbContext context)
		{
			if (context.Companies.Any())
			{
				return;   // DB has been seeded
			}

			context.Companies.AddRange(
				new Company()
				{
					Name = "Best Inc",
					Employees = new List<Employee>() { new Employee() { Name = "John", Age = 30 }, new Employee() { Name = "Sue", Age = 25 } },
					Cars = new List<Car>() { new Car() { Type = "Scoda", Color = "Gray" }, new Car() { Type = "Volvo", Color = "Red" } }
				},
				new Company()
				{
					Name = "Last Inc",
					Employees = new List<Employee>() { new Employee() { Name = "Bill", Age = 45 }, new Employee() { Name = "Chill", Age = 55 } },
					Cars = new List<Car>() { new Car() { Type = "WW Golf", Color = "Blue" }, new Car() { Type = "Trapant", Color = "Orange" } }
				}
			); ;

			context.SaveChanges();
		}
	}
}
