using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vm.App.ViewModels
{
	public class ProductViewModel
	{
		[Key]
		public Guid Id { get; set; }
		[DisplayName("Nome")]
		[Required(ErrorMessage ="O Campo {0} é Obrigatório")]
		[StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Name { get; set; }
		[DisplayName("Descrição")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		[StringLength(200, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Decription { get; set; }
		public IFormFile ImageUpload { get; set; }
		public string Image { get; set; }
		[DisplayName("Valor")]
		[Required(ErrorMessage = "O Campo {0} é Obrigatório")]
		public decimal Value { get; set; }
		[ScaffoldColumn(false)]
		public DateTime DateRegister { get; set; }
		[DisplayName("Ativo?")]
		public bool Active { get; set; }
		public ProviderViewModel Provider { get; set; }
	}
}
