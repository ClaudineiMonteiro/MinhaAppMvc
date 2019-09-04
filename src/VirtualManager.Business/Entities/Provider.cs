using System.Collections.Generic;

namespace VirtualManager.Business.Entities
{
	public class Provider : Entity
	{
		public string Name { get; set; }
		public string Document { get; set; }
		public TypeProvider TypeProvider { get; set; }
		public Address Address { get; set; }

		/* EF Relations */
		public IEnumerable<Product> Products { get; set; }

	}
}