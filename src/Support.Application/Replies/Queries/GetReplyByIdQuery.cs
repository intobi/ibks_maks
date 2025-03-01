using MediatR;
using Support.Application.Common.Models.Replies;
using Support.Application.Errors;

namespace Support.Application.Replies.Queries;

public class GetReplyByIdQuery(int replyId) : IRequest<Result<InternalError, ReplyResponse>>
{
    public int ReplyId { get; } = replyId;
}