using MediatR;
using Microsoft.Extensions.Logging;
using MyMonolith.Notifications.Application.Interfaces;
using MyMonolith.Notifications.Domain.Events;

namespace MyMonolith.Notifications.Application.Handlers
{
    internal class NotificationSentEventHandler : INotificationHandler<NotificationSentEvent>
    {
        private readonly ILogger<NotificationSentEventHandler> _logger;
        private readonly INotificationRepository _notificationRepository;

        public NotificationSentEventHandler(ILogger<NotificationSentEventHandler> logger, INotificationRepository notificationRepository)
        {
            _logger = logger;
            _notificationRepository = notificationRepository;
        }

        public Task Handle(NotificationSentEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Event: {DomainEvent}", notification.GetType().Name);

            _notificationRepository.AddAsync(notification.Notification, cancellationToken);

            return Task.CompletedTask;
        }
    }
}
