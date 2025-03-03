using AutoMapper;
using FluentValidation;
using MediatR;
using Support.Application.Common.Interfaces;
using Support.Application.Common.Models.Tickets;
using Support.Application.Errors;
using Support.Application.Tickets.Commands;
using Support.Domain.Entities;

namespace Support.Application.Tickets.Handlers;

public class CreateTicketHandler(
    IRepositoryBase<Ticket> repository,
    IRepositoryBase<User> usersRepository,
    IRepositoryBase<InstalledEnvironment> installedEnvironmentRepository,
    IRepositoryBase<Status> statusesRepository,
    IRepositoryBase<Priority> prioritiesRepository,
    IRepositoryBase<TicketType> ticketTypesRepository,
    IMapper mapper)
    : IRequestHandler<CreateTicketCommand, Result<InternalError, TicketResponse>>
{
    public async Task<Result<InternalError, TicketResponse>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        // Working with users are not of concern in task requirements.
        // So here I will get random user from Users table

        var users = await usersRepository.FindByConditionAsync(x => x.OID != "1");
        request.TicketRequest.UserOID = users.FirstOrDefault()?.OID;
        request.TicketRequest.CreatedByOID = users.FirstOrDefault()?.OID;
        
        var installedEnvironment = await installedEnvironmentRepository.FindByIdAsync(request.TicketRequest.InstalledEnvironmentId);
        if (installedEnvironment is null)
            return new Result<InternalError, TicketResponse>(new NotFoundError(request.TicketRequest.InstalledEnvironmentId));
        
        var status = await statusesRepository.FindByIdAsync(request.TicketRequest.StatusId);
        if (status is null)
            return new Result<InternalError, TicketResponse>(new NotFoundError(request.TicketRequest.StatusId));
        
        var priority = await prioritiesRepository.FindByIdAsync(request.TicketRequest.PriorityId);
        if (priority is null)
            return new Result<InternalError, TicketResponse>(new NotFoundError(request.TicketRequest.PriorityId));
        
        var ticketType = await ticketTypesRepository.FindByIdAsync(request.TicketRequest.TicketTypeId);
        if (ticketType is null)
            return new Result<InternalError, TicketResponse>(new NotFoundError(request.TicketRequest.TicketTypeId));
        
        request.TicketRequest.Date ??= DateTime.Now;
        request.TicketRequest.LastModified ??= DateTime.Now;

        var ticket = mapper.Map<Ticket>(request.TicketRequest);

        var result = await repository.AddAsync(ticket);

        return new Result<InternalError, TicketResponse>(mapper.Map<TicketResponse>(result));
    }
}