﻿using MediatR;
using Support.Application.Common.Models.Replies;
using Support.Application.Errors;

namespace Support.Application.Replies.Queries;

public class GetAllRepliesQuery(int page, int pageSize, string ticketId) : IRequest<Result<InternalError, List<ReplyResponse>>>
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
    public string TicketId { get; set; } = ticketId;
}