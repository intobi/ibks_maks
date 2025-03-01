namespace Support.Application.Common.Models.Replies;

public class ReplyResponse
{
    public int ReplyId { get; set; }
    
    public long TicketId { get; set; }

    public string? Reply { get; set; }

    public DateTime ReplyDate { get; set; }
}