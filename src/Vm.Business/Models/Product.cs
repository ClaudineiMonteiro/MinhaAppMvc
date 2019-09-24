using System;

namespace Vm.Business.Models
{
	public class Product : Entity
	{
		public Guid ProviderId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public decimal Value { get; set; }

		/* EF - Relations*/
		public Provider Provider { get; set; }
	}
}
