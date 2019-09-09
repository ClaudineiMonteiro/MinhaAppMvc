using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vm.App.ViewModels
{
	public class ProviderViewModel
	{
		[Key ]
		public Guid Id { get; set; }
		[DisplayName("Nome")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		[StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Name { get; set; }
		[DisplayName("Documento")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		[StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
		public string Document { get; set; }
		[DisplayName("Tipo")]
		public int SupplierType { get; set; }
		public AddressViewModel Address { get; set; }
		[DisplayName("Ativo?")]
		public bool Active { get; set; }
		public IEnumerable<ProductViewModel> Products { get; set; }
	}
}
