using MediatR;

namespace MyMonolith.Notifications.Domain.Common
{
    public abstract class EventBase : INotification
    {
        public string Id { get; set; }
        public string Source { get; protected set; }
        public DateTime Timestamp { get; protected set; }

        public string EventName { get; protected set; } = string.Empty;
        public string EventTime { get; protected set; } = DateTime.UtcNow.ToString();
        public string EventVersion { get; protected set; }

        public EventBase()
        {
            Timestamp = DateTime.UtcNow;
            Source = "MyModularMonolithApi";
            EventVersion = "1.0";
            Id = Guid.NewGuid().ToString();
        }
    }
}
