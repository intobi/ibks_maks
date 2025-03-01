using AutoMapper;
using MediatR;
using Support.Application.Common.Interfaces;
using Support.Application.Common.Models.Replies;
using Support.Application.Errors;
using Support.Application.Replies.Queries;
using Support.Domain.Entities;

namespace Support.Application.Replies.Handlers;

public class GetReplyByIdHandler(IRepositoryBase<TicketReply> repository, IMapper mapper) : IRequestHandler<GetReplyByIdQuery, Result<InternalError, ReplyResponse>>
{
    public async Task<Result<InternalError, ReplyResponse>> Handle(GetReplyByIdQuery request, CancellationToken cancellationToken)
    {
        var reply = await repository.FindByIdAsync(request.ReplyId);

        return reply is null ? new NotFoundError(request.ReplyId) : (Result<InternalError, ReplyResponse>)mapper.Map<ReplyResponse>(reply);

    }
}