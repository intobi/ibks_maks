using MediatR;
using Support.Application.Common.Models.Replies;
using Support.Application.Errors;

namespace Support.Application.Replies.Queries;

public class GetAllRepliesQuery : IRequest<Result<InternalError, List<ReplyResponse>>>
{ }