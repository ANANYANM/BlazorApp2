using BlazorApp2.Models;
namespace BlazorApp2.Services
{
    public class TicketService
    {
        private  List<Ticket> tickets = new List<Ticket>();

        public List<Ticket> GetTickets()
        {
            return tickets;
        }

        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
        }
    }
}



