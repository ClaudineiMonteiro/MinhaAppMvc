using System;

namespace VirtualManager.Business.Entities
{
	public class Address : Entity
	{
		public Guid ProviderId { get; set; }
		public string PublicPlace { get; set; }
		public string Number { get; set; }
		public string Complement { get; set; }
		public string Condado { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }

		/* EF Relations */
		public Provider Provider { get; set; }
	}
}
