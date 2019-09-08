using System;
using System.Threading.Tasks;
using Vm.Business.Models;

namespace Vm.Business.Interfaces
{
	public interface IProviderRepository : IRepository<Provider>
	{
		Task<Provider> GetProviderAddress(Guid id);
		Task<Provider> GetProviderProductAddress(Guid id);
	}
}
