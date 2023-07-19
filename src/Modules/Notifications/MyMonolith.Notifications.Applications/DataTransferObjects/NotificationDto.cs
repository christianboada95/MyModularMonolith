using System.ComponentModel.DataAnnotations;

namespace MyMonolith.Notifications.Application.DataTransferObjects
{
    public record NotificationDto
    {
        [Required]
        public string? Recipient { get; set; }
        [Required]
        public string? Message { get; set; }
    }
}
