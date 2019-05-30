using System.Collections.Generic;

namespace Core.Entities
{
	public class Company : BaseEntity
	{
		public string Name { get; set; }

		public List<Employee> Employees { get; set; }

		public List<Car> Cars { get; set; }
	}
}
