using AutoMapper;
using MediatR;
using Support.Application.Common.Interfaces;
using Support.Application.Common.Models.Tickets;
using Support.Application.Errors;
using Support.Application.Tickets.Queries;
using Support.Domain.Entities;

namespace Support.Application.Tickets.Handlers;

public class GetTicketByIdHandler(IRepositoryBase<Ticket> repository, IMapper mapper) : IRequestHandler<GetTicketByIdQuery, Result<InternalError, TicketResponse>>
{
    public async Task<Result<InternalError, TicketResponse>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await repository.FindByIdAsync(request.TicketId);

        return ticket is null ? new NotFoundError(request.TicketId) : (Result<InternalError, TicketResponse>)mapper.Map<TicketResponse>(ticket);
    }
}