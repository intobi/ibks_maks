using MediatR;
using Microsoft.AspNetCore.Mvc;
using Support.API.Helpers;
using Support.Application.Common.Models.Replies;
using Support.Application.Replies.Commands;
using Support.Application.Replies.Queries;

namespace Support.API.Controllers;

[ApiController]
[Route("/api/v1/replies")]
public class RepliesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllReplies([FromQuery] int page, int pageSize, string ticketId)
    {
        var query = new GetAllRepliesQuery(page, pageSize, ticketId);

        var replies = await mediator.Send(query);

        return ResponseHelper.HandleResponse(replies);
    }
    
    [HttpGet("{replyId:int}")]
    public async Task<IActionResult> GetReplyById(int replyId)
    {
        var query = new GetReplyByIdQuery(replyId);
    
        var reply = await mediator.Send(query);
    
        return ResponseHelper.HandleResponse(reply);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateReply([FromBody] AddReplyRequest reply)
    {
        var command = new CreateReplyCommand(reply);
        
        var createdReply = await mediator.Send(command);
    
        return ResponseHelper.HandleResponse(createdReply);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateReply([FromBody] UpdateReplyRequest reply)
    {
        var command = new UpdateReplyCommand(reply);
        
        var updatedReply = await mediator.Send(command);
    
        return ResponseHelper.HandleResponse(updatedReply);
    }
}