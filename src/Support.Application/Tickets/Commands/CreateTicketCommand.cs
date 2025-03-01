using MediatR;
using Support.Application.Common.Models.Tickets;
using Support.Application.Errors;

namespace Support.Application.Tickets.Commands;

public class CreateTicketCommand(AddTicketRequest ticketRequest) : IRequest<Result<InternalError, TicketResponse>>
{
    public AddTicketRequest TicketRequest { get; } = ticketRequest ?? throw new ArgumentNullException(nameof(ticketRequest));
}