using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vm.App.Extensions;

namespace Vm.App.ViewModels
{
	public class ProductViewModel
	{
		[Key]
		public Guid Id { get; set; }

		[DisplayName("Fornecedor")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		public Guid ProviderId { get; set; }

		[DisplayName("Nome")]
		[Required(ErrorMessage ="O Campo {0} é Obrigatório")]
		[StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Name { get; set; }

		[DisplayName("Descrição")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		[StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Decription { get; set; }

		[DisplayName("Imagem do Produto")]
		public IFormFile ImageUpload { get; set; }
		public string Image { get; set; }

		[CurrencyAttribute]
		[DisplayName("Valor")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		public decimal Value { get; set; }

		[ScaffoldColumn(false)]
		public DateTime DateRegister { get; set; }

		[DisplayName("Ativo?")]
		public bool Active { get; set; }

		public ProviderViewModel Provider { get; set; }
		public IEnumerable<ProviderViewModel> Providers { get; set; }
	}
}
