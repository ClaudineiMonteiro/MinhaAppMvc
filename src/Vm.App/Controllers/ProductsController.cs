﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vm.App.ViewModels;
using Vm.Business.Interfaces;
using Vm.Business.Models;

namespace Vm.App.Controllers
{
	public class ProductsController : BaseController
	{
		private readonly IProductRepository _productRepository;
		private readonly IProviderRepository _providerRepository;
		private readonly IMapper _mapper;

		public ProductsController(IProductRepository productRepository, IProviderRepository providerRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_providerRepository = providerRepository;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductProvider()));
		}

		public async Task<IActionResult> Details(Guid id)
		{
			var productViewModel = await GetProductById(id);

			if (productViewModel == null) return NotFound();

			return View(productViewModel);
		}

		public async Task<IActionResult> Create()
		{
			var productViewModel = await FillProviders(new ProductViewModel());
			return View(productViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductViewModel productViewModel)
		{
			productViewModel = await FillProviders(productViewModel);
			if (!ModelState.IsValid) return View(productViewModel);

			await _productRepository.Add(_mapper.Map<Product>(productViewModel));

			return View(productViewModel);
		}

		public async Task<IActionResult> Edit(Guid id)
		{
			
			var productViewModel = await GetProductById(id);

			if (productViewModel == null) return NotFound();

			return View(productViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
		{
			if (id != productViewModel.Id) return NotFound();

			if (!ModelState.IsValid) return View(productViewModel);

			await _productRepository.Update(_mapper.Map<Product>(productViewModel));

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			var product = await (GetProductById(id));

			if (product == null) return NotFound();

			return View(product);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var product = GetProductById(id);
			if (product == null) return NotFound();

			await _productRepository.Remove(id);

			return RedirectToAction(nameof(Index));
		}

		private async Task<ProductViewModel> GetProductById(Guid id)
		{
			var product = _mapper.Map<ProductViewModel>(await _productRepository.GetProductProviderById(id));
			product.Provider = _mapper.Map<ProviderViewModel>(await _providerRepository.GetAll());
			return product;
		}

		private async Task<ProductViewModel> FillProviders(ProductViewModel product)
		{
			product.Provider = _mapper.Map<ProviderViewModel>(await _providerRepository.GetAll());
			return product;
		}
	}
}
