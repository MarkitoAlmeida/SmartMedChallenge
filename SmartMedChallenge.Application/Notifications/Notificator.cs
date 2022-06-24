﻿using SmartMedChallenge.Application.Interfaces;
using SmartMedChallenge.Domain.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace SmartMedChallenge.Application.Notifications
{
    public class Notificator : INotificator
    {
        private List<Notification> _notifications;

        public Notificator() =>
            _notifications = new List<Notification>();

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
