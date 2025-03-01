namespace Support.Application.Common.Models.Tickets;

public class UpdateTicketRequest : AddTicketRequest
{
    public long? Id { get; set; }
    public bool Deleted { get; set; }
}