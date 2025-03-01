using MediatR;
using Support.Application.Common.Models.Tickets;
using Support.Application.Errors;

namespace Support.Application.Tickets.Queries;

public class GetTicketByIdQuery(long ticketId) : IRequest<Result<InternalError, TicketResponse>>
{
    public long TicketId { get; } = ticketId;
}