namespace Support.Application.Common.Models.Replies;

public class AddReplyRequest
{
    public long TicketId { get; set; }

    public string? Reply { get; set; }

    public DateTime? ReplyDate { get; set; }
}