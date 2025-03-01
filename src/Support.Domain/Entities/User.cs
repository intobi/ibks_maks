using System;
using System.Collections.Generic;

namespace Support.Domain.Entities;

public partial class User
{
    public string OID { get; set; } = null!;

    public string? DisplayName { get; set; }

    public string? Email { get; set; }

    public string? FullName { get; set; }

    public DateTime? LastScannedUtc { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
