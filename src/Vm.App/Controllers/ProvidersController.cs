using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vm.App.Extensions;
using Vm.App.ViewModels;
using Vm.Business.Interfaces;
using Vm.Business.Models;

namespace Vm.App.Controllers
{
	[Authorize]
	public class ProvidersController : BaseController
	{
		private readonly IProviderRepository _providerRepository;
		private readonly IProviderService _providerService;
		private readonly IMapper _mapper;

		public ProvidersController(IProviderRepository providerRepository,
			IMapper mapper,
			IProviderService providerService,
			INotifier notifier): base(notifier)
		{
			_providerRepository = providerRepository;
			_mapper = mapper;
			_providerService = providerService;
		}

		[AllowAnonymous]
		[Route("lista-de-fornecedores")]
		public async Task<IActionResult> Index()
		{
			return View(_mapper.Map<IEnumerable<ProviderViewModel>>(await _providerRepository.GetAll()));
		}

		[AllowAnonymous]
		[Route("dados-do-fornecedor/{id:guid}")]
		public async Task<IActionResult> Details(Guid id)
		{
			var providerViewModel = await GetProviderAddress(id);

			if (providerViewModel == null)
			{
				return NotFound();
			}

			return View(providerViewModel);
		}

		[ClaimsAuthorize("Fornecedor", "Adicionar")]
		[Route("novo-fornecedor")]
		public IActionResult Create()
		{
			return View();
		}

		[ClaimsAuthorize("Fornecedor", "Adicionar")]
		[Route("novo-fornecedor")]
		[HttpPost]
		public async Task<IActionResult> Create(ProviderViewModel providerViewModel)
		{
			if (!ModelState.IsValid) return View(providerViewModel);

			var provider = _mapper.Map<Provider>(providerViewModel);

			await _providerService.Add(provider);

			if (!OperacaoValida()) return View(providerViewModel);

			return RedirectToAction(nameof(Index));
		}

		[ClaimsAuthorize("Fornecedor", "Editar")]
		[Route("editar-fornecedor/{id:guid}")]
		public async Task<IActionResult> Edit(Guid id)
		{
			var providerViewModel = await GetProviderProductsAddress(id);

			if (providerViewModel == null)
			{
				return NotFound();
			}
			return View(providerViewModel);
		}

		[ClaimsAuthorize("Fornecedor", "Editar")]
		[Route("editar-fornecedor/{id:guid}")]
		[HttpPost]
		public async Task<IActionResult> Edit(Guid id, ProviderViewModel providerViewModel)
		{
			if (id != providerViewModel.Id) return NotFound();

			if (!ModelState.IsValid) return View(providerViewModel);

			var provider = _mapper.Map<Provider>(providerViewModel);

			await _providerService.Update(provider);

			if (!OperacaoValida()) return View(await GetProviderProductsAddress(id));

			return RedirectToAction(nameof(Index));
		}

		[ClaimsAuthorize("Fornecedor", "Excluir")]
		[Route("excluir-fornecedor/{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var providerViewModel = await GetProviderAddress(id);

			if (providerViewModel == null) return NotFound();

			return View(providerViewModel);
		}

		[ClaimsAuthorize("Fornecedor", "Excluir")]
		[Route("excluir-fornecedor/{id:guid}")]
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var provider = await GetProviderAddress(id);

			if (provider == null) return NotFound();

			await _providerService.Remove(id);

			if (!OperacaoValida()) return View(provider);

			return RedirectToAction(nameof(Index));
		}

		private async Task<ProviderViewModel> GetProviderAddress(Guid id)
		{
			return _mapper.Map<ProviderViewModel>(await _providerRepository.GetProviderAddress(id));
		}

		private async Task<ProviderViewModel> GetProviderProductsAddress(Guid id)
		{
			return _mapper.Map<ProviderViewModel>(await _providerRepository.GetProviderProductAddress(id));
		}
	}
}
