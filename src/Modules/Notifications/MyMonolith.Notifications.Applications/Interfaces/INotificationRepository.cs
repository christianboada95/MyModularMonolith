using MyMonolith.Notifications.Domain.Contracts;
using MyMonolith.Notifications.Domain.Entities;

namespace MyMonolith.Notifications.Application.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<int> GetTotalNotifications();
    }
}
