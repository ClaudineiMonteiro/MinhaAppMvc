using System;
using System.Threading.Tasks;
using Vm.Business.Models;

namespace Vm.Business.Interfaces
{
	public interface IProductService: IDisposable
	{
		Task Add(Product product);
		Task Update(Product product);
		Task Remove(Guid id);
	}
}
