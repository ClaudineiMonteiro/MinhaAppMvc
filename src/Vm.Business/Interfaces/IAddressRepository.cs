using System;
using System.Threading.Tasks;
using Vm.Business.Models;

namespace Vm.Business.Interfaces
{
	public interface IAddressRepository : IRepository<Address>
	{
		Task<Address> GetAddressByProvider(Guid ProviderId);
	}
}
