﻿using System;
using System.Threading.Tasks;
using Vm.Business.Interfaces;
using Vm.Business.Models;
using Vm.Business.Models.Validations;

namespace Vm.Business.Services
{
	public class ProductService : BaseService, IProductService
	{
		private readonly IProductRepository _productRepository;
		public ProductService(IProductRepository productRepository,
			INotifier notifier): base(notifier)
		{
			_productRepository = productRepository;
		}
		public async Task Add(Product product)
		{
			if (!PerformValidation(new ProductValidation(), product)) return;

			await _productRepository.Add(product);
		}

		public async Task Update(Product product)
		{
			if (!PerformValidation(new ProductValidation(), product)) return;

			await _productRepository.Update(product);
		}

		public async Task Remove(Guid id)
		{
			await _productRepository.Remove(id);
		}

		public void Dispose()
		{
			_productRepository?.Dispose();
		}
	}
}
