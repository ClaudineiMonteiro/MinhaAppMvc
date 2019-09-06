using System.Collections.Generic;

namespace Vm.Business.Models
{
	public class Provider : Entity
	{
		public string Name { get; set; }
		public string Document { get; set; }
		public SupplierType SupplierType { get; set; }
		public Address Address { get; set; }

		/* EF - Relations*/
		public IEnumerable<Product> Products { get; set; }
	}
}