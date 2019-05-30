using AutoMapper;
using Core.Entities;
using Core.Models;

namespace Core.Mappers
{
	public class CompanyProfile : Profile
	{
		public CompanyProfile()
		{
			AllowNullDestinationValues = true;

			CreateMap<Company, CompanyDto>(MemberList.Destination).ReverseMap()
				.ForMember(x => x.Timestamp, opt => opt.Ignore())
				.ForMember(x => x.CreatedDate, opt => opt.Ignore())
				.ForMember(x => x.ModifiedDate, opt => opt.Ignore())
				.ForMember(x => x.CreatedBy, opt => opt.Ignore())
				.ForMember(x => x.ModifiedBy, opt => opt.Ignore());//.DisableCtorValidation();

			CreateMap<Car, CarDto>(MemberList.Destination).ReverseMap()
				.ForMember(x => x.Timestamp, opt => opt.Ignore())
				.ForMember(x => x.CreatedDate, opt => opt.Ignore())
				.ForMember(x => x.ModifiedDate, opt => opt.Ignore())
				.ForMember(x => x.CreatedBy, opt => opt.Ignore())
				.ForMember(x => x.ModifiedBy, opt => opt.Ignore());//.DisableCtorValidation();

			CreateMap<Employee, EmployeeDto>(MemberList.Destination).ReverseMap()
				.ForMember(x => x.Timestamp, opt => opt.Ignore())
				.ForMember(x => x.CreatedDate, opt => opt.Ignore())
				.ForMember(x => x.ModifiedDate, opt => opt.Ignore())
				.ForMember(x => x.CreatedBy, opt => opt.Ignore())
				.ForMember(x => x.ModifiedBy, opt => opt.Ignore());//.DisableCtorValidation();
		}
	}
}
