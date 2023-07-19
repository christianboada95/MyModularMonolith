using Microsoft.EntityFrameworkCore;
using MyMonolith.Notifications.Application.Interfaces;
using MyMonolith.Notifications.Domain.Entities;
using MyMonolith.Notifications.Infrastructure.Common;
using MyMonolith.Notifications.Infrastructure.Data;

namespace MyMonolith.Notifications.Infrastructure.Repositories
{
    internal class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        private readonly AppDbContext _appDbContext;
        public NotificationRepository(AppDbContext dbContext)
            : base(dbContext) => _appDbContext = dbContext;

        public Task<int> GetTotalNotifications()
        {
            return _appDbContext.Products.CountAsync();
        }
    }
}
