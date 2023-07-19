using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyMonolith.Notifications.Application.DataTransferObjects;
using MyMonolith.Notifications.Domain.Entities;
using MyMonolith.Notifications.Domain.Events;

namespace MyMonolith.Notifications.Api.Controllers
{
    [ApiController]
    [Route("[module]/[controller]")]
    internal class NotificationController : Controller
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public NotificationController(ILogger<NotificationController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost(Name = "SendNotification")]
        public async Task<IActionResult> Post([FromBody] NotificationDto notificationDto)
        {
            var notificationSentEvent = new NotificationSentEvent(_mapper.Map<Notification>(notificationDto));
            await _mediator.Publish(notificationSentEvent).ConfigureAwait(false);
            _logger.LogInformation("Notification Sent Success!");
            return Ok("Notification Sent Success!");
        }
    }
}