using BlazorApp2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlazorApp2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public TicketController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> Get()
        {
            TicketContext db = new TicketContext();
            return db.Tickets.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> Post(Ticket value)
        {
            TicketContext db = new TicketContext();
            db.Tickets.Add(value);
            db.SaveChanges();
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ticket>> Put(long id, Ticket updatedTicket)
        {
            using (TicketContext db = new TicketContext())
            {
                var existingTicket = await db.Tickets.FindAsync(id);

                if (existingTicket == null)
                {
                    return NotFound(); // Return 404 if the ticket with the given id is not found
                }

                // Update properties of the existing ticket with the values from the updated ticket
                existingTicket.Title = updatedTicket.Title;
                existingTicket.CustomerName = updatedTicket.CustomerName;
                existingTicket.Issue = updatedTicket.Issue;
                existingTicket.CompanyName = updatedTicket.CompanyName;
                existingTicket.IssueCategory = updatedTicket.IssueCategory;
                existingTicket.Description = updatedTicket.Description;
                existingTicket.Status = updatedTicket.Status;
                existingTicket.AssignTo = updatedTicket.AssignTo;

                await db.SaveChangesAsync(); // Save changes to the database

                return Ok(existingTicket); // Return the updated ticket
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            TicketContext db = new TicketContext();
            var ticket = db.Tickets.Find(id);

            if (ticket == null)
            {
                return NotFound();
            }

            db.Tickets.Remove(ticket);
            db.SaveChanges();

            return NoContent();
        }
    }
}
