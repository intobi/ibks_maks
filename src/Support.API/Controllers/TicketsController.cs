﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Support.API.Helpers;
using Support.Application.Common.Models.Tickets;
using Support.Application.Tickets.Commands;
using Support.Application.Tickets.Queries;

namespace Support.API.Controllers;

[ApiController]
[Route("/api/v1/tickets")]
public class TicketsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTickets([FromQuery] int page, int pageSize)
    {
        var query = new GetAllTicketsQuery(page, pageSize);

        var tickets = await mediator.Send(query);

        return ResponseHelper.HandleResponse(tickets);
    }
    
    [HttpGet("{ticketId:long}")]
    public async Task<IActionResult> GetTicketById(long ticketId)
    {
        var query = new GetTicketByIdQuery(ticketId);

        var ticket = await mediator.Send(query);

        return ResponseHelper.HandleResponse(ticket);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] AddTicketRequest ticket)
    {
        var command = new CreateTicketCommand(ticket);
        
        var createdTicket = await mediator.Send(command);

        return ResponseHelper.HandleResponse(createdTicket);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTicket([FromBody] UpdateTicketRequest ticket)
    {
        var command = new UpdateTicketCommand(ticket);
        
        var updatedTicket = await mediator.Send(command);

        return ResponseHelper.HandleResponse(updatedTicket);
    }
}