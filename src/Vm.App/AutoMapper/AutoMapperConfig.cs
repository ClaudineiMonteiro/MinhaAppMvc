using AutoMapper;
using Vm.App.ViewModels;
using Vm.Business.Models;

namespace Vm.App.AutoMapper
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<Provider, ProviderViewModel>().ReverseMap();
			CreateMap<Address, AddressViewModel>().ReverseMap();
			CreateMap<Product, ProductViewModel>().ReverseMap();
		}
	}
}
