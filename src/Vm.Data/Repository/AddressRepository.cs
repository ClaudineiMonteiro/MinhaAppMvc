using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vm.Business.Interfaces;
using Vm.Business.Models;
using Vm.Data.Context;

namespace Vm.Data.Repository
{
	public class AddressRepository : BaseRepository<Address>, IAddressRepository
	{
		public AddressRepository(MinhaAppMvcDbContext context) : base(context) {}

		public async Task<Address> GetAddressByProvider(Guid ProviderId)
		{
			return await Db.Addresses
				.AsNoTracking()
				.FirstOrDefaultAsync(a => a.ProviderId.Equals(ProviderId));
		}
	}
}
