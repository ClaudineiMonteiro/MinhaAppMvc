using Microsoft.AspNetCore.Mvc;
using Vm.Business.Interfaces;

namespace Vm.App.Controllers
{
	public abstract class BaseController : Controller
	{
		private readonly INotifier _notifier;

		protected BaseController(INotifier notifier)
		{
			_notifier = notifier;
		}

		protected bool OperacaoValida()
		{
			return !_notifier.HaveNotification();
		}
	}
}
