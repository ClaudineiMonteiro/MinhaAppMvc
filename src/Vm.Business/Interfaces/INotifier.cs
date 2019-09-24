using System.Collections.Generic;
using Vm.Business.Notifications;

namespace Vm.Business.Interfaces
{
	public interface INotifier
	{
		bool HaveNotification();
		List<Notification> GetNotifications();
		void Handle(Notification notification);
	}
}
