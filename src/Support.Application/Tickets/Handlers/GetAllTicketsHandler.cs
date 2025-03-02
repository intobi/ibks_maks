using AutoMapper;
using MediatR;
using Support.Application.Common.Interfaces;
using Support.Application.Common.Models.Tickets;
using Support.Application.Errors;
using Support.Application.Tickets.Queries;
using Support.Domain.Entities;

namespace Support.Application.Tickets.Handlers;

public class GetAllTicketsHandler(IRepositoryBase<Ticket> repository, IMapper mapper) : IRequestHandler<GetAllTicketsQuery, Result<InternalError, List<TicketResponse>>>
{
    public async Task<Result<InternalError, List<TicketResponse>>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var tickets = await repository.GetAllAsync(request.Page, request.PageSize);

        return mapper.Map<List<TicketResponse>>(tickets);
    }
}