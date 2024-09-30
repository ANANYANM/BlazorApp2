using BlazorApp2.Models;
namespace BlazorApp2.Services
{
    public class TicketService
    {

        private readonly List<Ticket> tickets = new List<Ticket>();

        public List<Ticket> GetTickets()
        {
           return tickets;
        }

        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
        }
        public void UpdateTicket(Ticket updatedTicket)
        {
            // Find the ticket with the same TicketId
            var ticket = tickets.FirstOrDefault(t => t.TicketId == updatedTicket.TicketId);

            if (ticket != null)
            {
                // Update the fields of the existing ticket with the updated ticket details
                ticket.Title = updatedTicket.Title;
                ticket.CustomerName = updatedTicket.CustomerName;
                ticket.Issue = updatedTicket.Issue;
                ticket.CompanyName = updatedTicket.CompanyName;
                ticket.IssueCategory = updatedTicket.IssueCategory;
                ticket.Description = updatedTicket.Description;
                ticket.Status = updatedTicket.Status;
                ticket.AssignTo = updatedTicket.AssignTo;
            }
        }
    }
}