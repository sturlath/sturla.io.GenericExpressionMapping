using System.Collections.Generic;

namespace Core.Models
{
	public class CompanyDto : BaseDto
	{
		public string Name { get; set; }

		public List<EmployeeDto> Employees { get; set; }
		public List<CarDto> Cars { get; set; }
	}
}
