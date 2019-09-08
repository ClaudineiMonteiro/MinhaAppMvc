using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vm.Business.Interfaces;
using Vm.Business.Models;
using Vm.Data.Context;

namespace Vm.Data.Repository
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(MinhaAppMvcDbContext context) : base(context) {}
		public async Task<IEnumerable<Product>> GetProductByProvider(Guid ProviderId)
		{
			return await Search(p => p.ProviderId.Equals(ProviderId));
		}

		public async Task<IEnumerable<Product>> GetProductProvider()
		{
			return await Db.Products.AsNoTracking().Include(p => p.Provider).OrderBy(p => p.Name).ToListAsync();
		}

		public async Task<Product> GetProductProviderById(Guid id)
		{
			return await Db.Products.AsNoTracking().Include(p => p.Provider).FirstOrDefaultAsync(p => p.Id.Equals(id));
		}
	}
}
