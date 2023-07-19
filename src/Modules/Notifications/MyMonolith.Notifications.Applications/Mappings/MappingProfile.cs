using AutoMapper;
using MyMonolith.Notifications.Application.DataTransferObjects;
using MyMonolith.Notifications.Domain.Entities;

namespace MyMonolith.Notifications.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NotificationDto, Notification>();
            CreateMap<Notification, NotificationDto>();

            //CreateMap<TokenResponse, Token>()
            //    .ConstructUsing(x => new Token(
            //        x.AccessToken,
            //        x.TokenType,
            //        x.ExpiresIn));

            // Multiple Map
            //CreateMap<(object a, object b, object c), NotificationDto>()
            //    .ConstructUsing(n => new NotificationDto()
            //    {
            //        Message = n.a.ToString()
            //    }); ; ;
        }
    }
}
