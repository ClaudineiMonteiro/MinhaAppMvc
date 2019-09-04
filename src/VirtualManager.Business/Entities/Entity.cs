using System;

namespace VirtualManager.Business.Entities
{
	public abstract class Entity
	{
		#region Properties
		public Guid Id { get; set; }
		public DateTime DateRegister { get; set; }
		public DateTime? LastUpdatedDate { get; set; }
		public bool Active { get; set; }
		#endregion

		#region Builders
		protected Entity()
		{
			Id = Guid.NewGuid();
		} 
		#endregion
	}
}
