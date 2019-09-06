using System.ComponentModel;

namespace Vm.Business.Models
{
	public enum SupplierType
	{
		[Description("Pessoa Física")]
		PhysicalPerson = 1,
		[Description("Pessoa Jurídica")]
		LegalPerson
	}
}
