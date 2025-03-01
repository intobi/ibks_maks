using AutoMapper;
using MediatR;
using Support.Application.Common.Interfaces;
using Support.Application.Common.Models.Replies;
using Support.Application.Errors;
using Support.Application.Replies.Commands;
using Support.Domain.Entities;

namespace Support.Application.Replies.Handlers;

public class UpdateReplyHandler(
    IRepositoryBase<TicketReply> repository,
    IRepositoryBase<Ticket> ticketRepository,
    IMapper mapper)
    : IRequestHandler<UpdateReplyCommand, Result<InternalError, ReplyResponse>>
{
    public async Task<Result<InternalError, ReplyResponse>> Handle(UpdateReplyCommand request, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.FindByIdAsync(request.ReplyRequest.TicketId);
        if (ticket is null)
            return new Result<InternalError, ReplyResponse>(new NotFoundError(request.ReplyRequest.TicketId));
        
        request.ReplyRequest.ReplyDate ??= DateTime.Now;

        var reply = mapper.Map<TicketReply>(request.ReplyRequest);

        var result = await repository.UpdateAsync(reply);

        return new Result<InternalError, ReplyResponse>(mapper.Map<ReplyResponse>(result));
    }
}