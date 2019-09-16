using System;

namespace Vm.Business.Models
{
	public abstract class Entity
	{
		public Guid Id { get; set; }
		public bool Active { get; set; }

		protected Entity()
		{
			Id = Guid.NewGuid();
		}
	}
}
