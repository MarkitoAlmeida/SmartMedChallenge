using SmartMedChallenge.Domain.Notifications;
using System.Collections.Generic;

namespace SmartMedChallenge.Application.Interfaces
{
    public interface INotificator
    {
        void Handle(Notification notification);
        List<Notification> GetNotifications();
        bool HasNotification();
    }
}
