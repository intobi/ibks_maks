using AutoMapper;
using Support.Application.Common.Models.Tickets;
using Support.Domain.Entities;

namespace Support.Application.MapperProfiles;

public class TicketProfile : Profile
{
    public TicketProfile()
    {
        CreateMap<Ticket, TicketResponse>().ForMember(x => x.Id, opt => opt.MapFrom(q => q.Id))
            .ForMember(x => x.ApplicationId, opt => opt.MapFrom(q => q.ApplicationId))
            .ForMember(x => x.InstalledEnvironmentId, opt => opt.MapFrom(q => q.InstalledEnvironmentId))
            .ForMember(x => x.PriorityId, opt => opt.MapFrom(q => q.PriorityId))
            .ForMember(x => x.StatusId, opt => opt.MapFrom(q => q.StatusId))
            .ForMember(x => x.TicketTypeId, opt => opt.MapFrom(q => q.TicketTypeId))
            .ForMember(x => x.UserOID, opt => opt.MapFrom(q => q.UserOID))
            .ForMember(x => x.Title, opt => opt.MapFrom(q => q.Title))
            .ForMember(x => x.Description, opt => opt.MapFrom(q => q.Description))
            .ForMember(x => x.Url, opt => opt.MapFrom(q => q.Url))
            .ForMember(x => x.StackTrace, opt => opt.MapFrom(q => q.StackTrace))
            .ForMember(x => x.Device, opt => opt.MapFrom(q => q.Device))
            .ForMember(x => x.Browser, opt => opt.MapFrom(q => q.Browser))
            .ForMember(x => x.Resolution, opt => opt.MapFrom(q => q.Resolution))
            .ForMember(x => x.ApplicationName, opt => opt.MapFrom(q => q.ApplicationName))
            .ForMember(x => x.UserId, opt => opt.MapFrom(q => q.UserId))
            .ForMember(x => x.Date, opt => opt.MapFrom(q => q.Date))
            .ForMember(x => x.Deleted, opt => opt.MapFrom(q => q.Deleted))
            .ForMember(x => x.LastModified, opt => opt.MapFrom(q => q.LastModified))
            .ForMember(x => x.CreatedByOID, opt => opt.MapFrom(q => q.CreatedByOID));
    }
}