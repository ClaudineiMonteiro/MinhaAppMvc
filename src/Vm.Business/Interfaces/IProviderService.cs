using System;
using System.Threading.Tasks;
using Vm.Business.Models;

namespace Vm.Business.Interfaces
{
	public interface IProviderService: IDisposable
	{
		Task Add(Provider provider);
		Task Update(Provider provide);
		Task Remove(Guid id);

		Task UpdateAddress(Address address);
	}
}
