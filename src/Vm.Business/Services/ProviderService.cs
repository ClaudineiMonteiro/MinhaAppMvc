using System;
using System.Threading.Tasks;
using Vm.Business.Interfaces;
using Vm.Business.Models;

namespace Vm.Business.Services
{
	public class ProviderService : BaseService, IProviderService
	{
		private readonly IProviderRepository _providerRepository;
		private readonly IAddressRepository _addressRepository;

		public ProviderService(IProviderRepository providerRepository,
			IAddressRepository addressRepository,
			INotifier notifier): base(notifier)
		{
			_providerRepository = providerRepository;
			_addressRepository = addressRepository;
		}

		public Task Add(Provider provider)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public Task Remove(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task Update(Provider provide)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAddress(Address address)
		{
			throw new NotImplementedException();
		}
	}
}
