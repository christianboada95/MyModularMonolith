using MyMonolith.Notifications.Domain.Common;
using MyMonolith.Notifications.Domain.Entities;

namespace MyMonolith.Notifications.Domain.Events
{
    public class NotificationSentEvent : EventBase
    {
        public Notification Notification { get; private set; }

        public NotificationSentEvent(Notification notification)
        {
            EventName = nameof(NotificationSentEvent); //this.GetType().Name;
            Notification = notification;
        }
    }
}
