namespace BlazorApp2.Models
{ 

public class Ticket
{
    public int TicketId { get; set; }
    public string Title { get; set; }
    public string CustomerName { get; set; }
    public string Issue { get; set; }
    public string CompanyName { get; set; }
    public string IssueCategory { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Status { get; set; }
    public string AssignTo { get; set; }
}
}


