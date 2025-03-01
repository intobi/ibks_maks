namespace Support.Application.Common.Models.Tickets;

public class TicketResponse
{
    public long Id { get; set; }
    
    public int ApplicationId { get; set; }
    
    public int InstalledEnvironmentId { get; set; }
    public int PriorityId { get; set; }
    public int StatusId { get; set; }
    public int TicketTypeId { get; set; }
    public string? UserOID { get; set; }
    
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? StackTrace { get; set; }
    public string? Device { get; set; }
    public string? Browser { get; set; }
    public string? Resolution { get; set; }
    
    public string? ApplicationName { get; set; }

    public int? UserId { get; set; }
    public DateTime Date { get; set; }
    public bool? Deleted { get; set; }
    public DateTime LastModified { get; set; }
    public string? CreatedByOID { get; set; }
}