using MediatR;
using Support.Application.Common.Models.Replies;
using Support.Application.Errors;

namespace Support.Application.Replies.Commands;

public class CreateReplyCommand(AddReplyRequest replyRequest) : IRequest<Result<InternalError, ReplyResponse>>
{
    public AddReplyRequest ReplyRequest { get; } = replyRequest ?? throw new ArgumentNullException(nameof(replyRequest));
}