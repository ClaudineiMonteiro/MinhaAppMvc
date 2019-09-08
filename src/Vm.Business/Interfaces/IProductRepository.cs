using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vm.Business.Models;

namespace Vm.Business.Interfaces
{
	public interface IProductRepository : IRepository<Product>
	{
		Task<IEnumerable<Product>> GetProductByProvider(Guid ProviderId);
		Task<IEnumerable<Product>> GetProductProvider();
		Task<Product> GetProductProviderById(Guid id);
	}
}
