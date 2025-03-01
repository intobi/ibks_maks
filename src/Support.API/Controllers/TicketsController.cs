using MediatR;
using Microsoft.AspNetCore.Mvc;
using Support.API.Helpers;
using Support.Application.Tickets.Queries;

namespace Support.API.Controllers;

[ApiController]
[Route("/api/v1/tickets")]
public class TicketsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTickets()
    {
        var query = new GetAllTicketsQuery();

        var tickets = await mediator.Send(query);

        return ResponseHelper.HandleResponse(tickets);
    }
}