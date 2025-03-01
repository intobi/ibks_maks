using MediatR;
using Support.Application.Common.Models.Tickets;
using Support.Application.Errors;

namespace Support.Application.Tickets.Commands;

public class UpdateTicketCommand(UpdateTicketRequest ticketRequest) : IRequest<Result<InternalError, TicketResponse>>
{
    public UpdateTicketRequest TicketRequest { get; } = ticketRequest ?? throw new ArgumentNullException(nameof(ticketRequest));
}