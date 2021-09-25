using AutoMapper;
using ordermanger_dotnet.Entities;
using ordermanger_dotnet.Models;

namespace ordermanger_dotnet.Helpers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<User, UserModel>();
			CreateMap<RegisterModel, User>();
			CreateMap<UpdateUserModel, User>();
		}
	}
}
