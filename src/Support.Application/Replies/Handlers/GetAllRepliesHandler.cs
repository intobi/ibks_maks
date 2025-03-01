using AutoMapper;
using MediatR;
using Support.Application.Common.Interfaces;
using Support.Application.Common.Models.Replies;
using Support.Application.Errors;
using Support.Application.Replies.Queries;
using Support.Domain.Entities;

namespace Support.Application.Replies.Handlers;

public class GetAllRepliesHandler(IRepositoryBase<TicketReply> repository, IMapper mapper) : IRequestHandler<GetAllRepliesQuery, Result<InternalError, List<ReplyResponse>>>
{
    public async Task<Result<InternalError, List<ReplyResponse>>> Handle(GetAllRepliesQuery request, CancellationToken cancellationToken)
    {
        var replies = await repository.GetAllAsync();

        return mapper.Map<List<ReplyResponse>>(replies);
    }
}