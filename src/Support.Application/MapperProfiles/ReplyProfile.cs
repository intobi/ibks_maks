using AutoMapper;
using Support.Application.Common.Models.Replies;
using Support.Domain.Entities;

namespace Support.Application.MapperProfiles;

public class ReplyProfile : Profile
{
    public ReplyProfile()
    {
        CreateMap<TicketReply, ReplyResponse>()
            .ForMember(x => x.ReplyId, opt => opt.MapFrom(q => q.ReplyId))
            .ForMember(x => x.TicketId, opt => opt.MapFrom(q => q.TId))
            .ForMember(x => x.Reply, opt => opt.MapFrom(q => q.Reply))
            .ForMember(x => x.ReplyDate, opt => opt.MapFrom(q => q.ReplyDate));
        
        CreateMap<AddReplyRequest, TicketReply>()
            .ForMember(x => x.TId, opt => opt.MapFrom(q => q.TicketId))
            .ForMember(x => x.Reply, opt => opt.MapFrom(q => q.Reply))
            .ForMember(x => x.ReplyDate, opt => opt.MapFrom(q => q.ReplyDate));

        CreateMap<UpdateReplyRequest, TicketReply>()
            .ForMember(x => x.ReplyId, opt => opt.MapFrom(q => q.ReplyId))
            .ForMember(x => x.TId, opt => opt.MapFrom(q => q.TicketId))
            .ForMember(x => x.Reply, opt => opt.MapFrom(q => q.Reply))
            .ForMember(x => x.ReplyDate, opt => opt.MapFrom(q => q.ReplyDate));

    }
}