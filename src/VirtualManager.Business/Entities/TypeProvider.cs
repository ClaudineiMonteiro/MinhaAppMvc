using System.ComponentModel;

namespace VirtualManager.Business.Entities
{
	public enum TypeProvider
	{
		[Description("Física")]
		Physicist = 1,
		[Description("Juridica")]
		Business
	}
}