using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vm.Business.Interfaces;
using Vm.Business.Models;
using Vm.Data.Context;

namespace Vm.Data.Repository
{
	public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
	{
		public ProviderRepository(MinhaAppMvcDbContext context) : base(context) {}

		public async Task<Provider> GetProviderAddress(Guid id)
		{
			return await Db.Providers
				.AsNoTracking()
				.Include(a => a.Address)
				.FirstOrDefaultAsync(p => p.Id.Equals(id));
		}

		public async Task<Provider> GetProviderProductAddress(Guid id)
		{
			return await Db.Providers.AsNoTracking().Include(p => p.Products)
				.Include(a => a.Address)
				.FirstOrDefaultAsync(p => p.Id.Equals(id));
		}
	}
}
