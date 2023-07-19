using MyMonolith.Notifications.Domain.Common;

namespace MyMonolith.Notifications.Domain.Entities
{
    public class Notification : EntityBase
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
    }
}
