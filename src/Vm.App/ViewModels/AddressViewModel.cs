using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vm.App.ViewModels
{
	public class AddressViewModel
	{
		[Key]
		public Guid Id { get; set; }
		[DisplayName("Logradouro")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		[StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string PublicPlace { get; set; }
		[DisplayName("Número")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		[StringLength(10, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
		public string Number { get; set; }
		[DisplayName("Complemento")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		[StringLength(20, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
		public string Complement { get; set; }
		[DisplayName("Cep")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		[StringLength(8, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
		public string ZipCode { get; set; }
		[DisplayName("Bairro")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		[StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string District { get; set; }
		[DisplayName("Cidade")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		[StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string City { get; set; }
		[DisplayName("Estado")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		[StringLength(2, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
		public string State { get; set; }

		[HiddenInput]
		public Guid ProviderId { get; set; }
	}
}
