using System;
using System.Collections.Generic;

namespace Support.Domain.Entities;

public partial class TicketReply
{
    public int ReplyId { get; set; }

    public long TId { get; set; }

    public string? Reply { get; set; }

    public DateTime ReplyDate { get; set; }
}
