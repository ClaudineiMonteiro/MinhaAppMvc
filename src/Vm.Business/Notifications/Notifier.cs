using System.Collections.Generic;
using System.Linq;
using Vm.Business.Interfaces;

namespace Vm.Business.Notifications
{
	public class Notifier : INotifier
	{
		private List<Notifier> _notifications;

		public Notifier()
		{
			_notifications = new List<Notifier>();
		}

		public List<Notifier> GetNotifications()
		{
			return _notifications;
		}

		public void Handle(Notifier notifier)
		{
			_notifications.Add(notifier);
		}

		public void Handle(Notification notification)
		{
			throw new System.NotImplementedException();
		}

		public bool HaveNotification()
		{
			return _notifications.Any();
		}

		List<Notification> INotifier.GetNotifications()
		{
			throw new System.NotImplementedException();
		}
	}
}
