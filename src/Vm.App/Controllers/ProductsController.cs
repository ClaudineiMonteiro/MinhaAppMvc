using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Vm.App.Extensions;
using Vm.App.ViewModels;
using Vm.Business.Interfaces;
using Vm.Business.Models;

namespace Vm.App.Controllers
{
	[Authorize]
	public class ProductsController : BaseController
	{
		private readonly IProductRepository _productRepository;
		private readonly IProviderRepository _providerRepository;
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductsController(IProductRepository productRepository,
			IProviderRepository providerRepository,
			IMapper mapper,
			IProductService productService,
			INotifier notifier): base(notifier)
		{
			_productRepository = productRepository;
			_providerRepository = providerRepository;
			_mapper = mapper;
			_productService = productService;
		}

		[AllowAnonymous]
		[Route("lista-de-produtos")]
		public async Task<IActionResult> Index()
		{
			return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductProvider()));
		}

		[AllowAnonymous]
		[Route("dados-do-produto/{id:guid}")]
		public async Task<IActionResult> Details(Guid id)
		{
			var productViewModel = await GetProductById(id);

			if (productViewModel == null) return NotFound();

			return View(productViewModel);
		}

		[ClaimsAuthorize("Produto", "Adicionar")]
		[Route("novo-produto")]
		public async Task<IActionResult> Create()
		{
			var productViewModel = await FillProviders(new ProductViewModel());
			return View(productViewModel);
		}

		[ClaimsAuthorize("Produto", "Adicionar")]
		[Route("novo-produto")]
		[HttpPost]
		public async Task<IActionResult> Create(ProductViewModel productViewModel)
		{
			productViewModel = await FillProviders(productViewModel);
			if (!ModelState.IsValid) return View(productViewModel);

			var imgPrefix = $"{Guid.NewGuid()}_";
			if (!await UploadFile(productViewModel.ImageUpload, imgPrefix))
			{
				return View(productViewModel);
			}

			productViewModel.Image = $"{imgPrefix}{productViewModel.ImageUpload.FileName}";

			await _productService.Add(_mapper.Map<Product>(productViewModel));

			if (!OperacaoValida()) return View(productViewModel);

			return View(nameof(Index));
		}

		[ClaimsAuthorize("Produto", "Editar")]
		[Route("editar-produto/{id:guid}")]
		public async Task<IActionResult> Edit(Guid id)
		{
			
			var productViewModel = await GetProductById(id);

			if (productViewModel == null) return NotFound();

			return View(productViewModel);
		}

		[ClaimsAuthorize("Produto", "Editar")]
		[Route("editar-produto/{id:guid}")]
		[HttpPost]
		public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
		{
			if (id != productViewModel.Id) return NotFound();

			var productUpdated = await GetProductById(id);
			productViewModel.Provider = productUpdated.Provider;
			productViewModel.Image = productUpdated.Image;
			if (!ModelState.IsValid) return View(productViewModel);

			if (productViewModel.ImageUpload != null)
			{
				var imgPrefix = $"{Guid.NewGuid()}_";
				if (!await UploadFile(productViewModel.ImageUpload, imgPrefix))
				{
					return View(productViewModel);
				}
				productUpdated.Image = $"{imgPrefix}{productViewModel.ImageUpload.FileName}";
			}

			productUpdated.Name = productViewModel.Name;
			productUpdated.Decription = productViewModel.Decription;
			productUpdated.Value = productViewModel.Value;
			productUpdated.Active = productViewModel.Active;

			await _productService.Update(_mapper.Map<Product>(productUpdated));

			if (!OperacaoValida()) return View(productViewModel);

			return RedirectToAction(nameof(Index));
		}

		[ClaimsAuthorize("Produto", "Excluir")]
		[Route("excluir-produto/{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var product = await (GetProductById(id));

			if (product == null) return NotFound();

			return View(product);
		}

		[ClaimsAuthorize("Produto", "Excluir")]
		[Route("excluir-produto/{id:guid}")]
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var product = GetProductById(id);
			if (product == null) return NotFound();

			await _productService.Remove(id);

			if (!OperacaoValida()) return View(product);

			TempData["Sucesso"] = "Produto excluido com sucesso!";

			return RedirectToAction(nameof(Index));
		}

		private async Task<ProductViewModel> GetProductById(Guid id)
		{
			var product = _mapper.Map<ProductViewModel>(await _productRepository.GetProductProviderById(id));
			product.Providers = _mapper.Map< IEnumerable<ProviderViewModel>>(await _providerRepository.GetAll());
			return product;
		}

		private async Task<ProductViewModel> FillProviders(ProductViewModel product)
		{
			product.Providers = _mapper.Map<IEnumerable<ProviderViewModel>>(await _providerRepository.GetAll());
			return product;
		}

		private async Task<bool> UploadFile(IFormFile imageUpload, string imgPrefix)
		{
			if (imageUpload.Length <= 0) return false;

			var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", $"{imgPrefix}{imageUpload.FileName}");

			if (System.IO.File.Exists(path))
			{
				ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
				return false;
			}

			using (var stream = new FileStream(path, FileMode.Create))
			{
				await imageUpload.CopyToAsync(stream);
			}
			return true;
		}
	}
}
