using MediatR;
using Support.Application.Common.Models.Tickets;
using Support.Application.Errors;

namespace Support.Application.Tickets.Queries;

public class GetAllTicketsQuery(int page, int pageSize) : IRequest<Result<InternalError, List<TicketResponse>>>
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
}