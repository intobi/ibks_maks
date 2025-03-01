using MediatR;
using Support.Application.Common.Models.Replies;
using Support.Application.Errors;

namespace Support.Application.Replies.Commands;

public class UpdateReplyCommand(UpdateReplyRequest replyRequest) : IRequest<Result<InternalError, ReplyResponse>>
{
    public UpdateReplyRequest ReplyRequest { get; } = replyRequest ?? throw new ArgumentNullException(nameof(replyRequest));
}