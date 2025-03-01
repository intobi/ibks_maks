using MediatR;
using Support.Application.Common.Models.Tickets;
using Support.Application.Errors;

namespace Support.Application.Tickets.Queries;

public class GetAllTicketsQuery : IRequest<Result<InternalError, List<TicketResponse>>>
{
    
}