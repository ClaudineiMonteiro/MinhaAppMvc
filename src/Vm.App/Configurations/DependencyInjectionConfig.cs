using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Vm.App.Extensions;
using Vm.Business.Interfaces;
using Vm.Business.Notifications;
using Vm.Business.Services;
using Vm.Data.Context;
using Vm.Data.Repository;

namespace Vm.App.Configurations
{
	public static class DependencyInjectionConfig
	{
		public static IServiceCollection ResolveDependencies(this IServiceCollection services)
		{
			services.AddScoped<MinhaAppMvcDbContext>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProviderRepository, ProviderRepository>();
			services.AddScoped<IAddressRepository, AddressRepository>();
			services.AddSingleton<IValidationAttributeAdapterProvider, CurrencyValidationAttributeAdapterProvider>();

			services.AddScoped<INotifier, Notifier>();
			services.AddScoped<IProviderService, ProviderService>();
			services.AddScoped<IProductService, ProductService>();

			return services;
		}
	}
}
