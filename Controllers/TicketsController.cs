using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tickets.Api.Data;
using Tickets.Api.Models;

namespace Tickets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly TicketsDbContext _dbContext;

        public TicketsController(TicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTickets([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
        {
            var totalItems = await _dbContext.Tickets.CountAsync();
            var Tickets = _dbContext.Tickets.Skip((pageNumber - 1) * pageSize)  
                                                        .Take(pageSize)                      
                                                        .ToList();
            var response = new PagedResponse<Ticket>(Tickets, totalItems, pageNumber, pageSize);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddNewTicket([FromBody]AddTicketsDto request)
        {
            Ticket newTicket = new Ticket()
            {
                Description = request.description,
                Date = DateTime.Now.ToString("MMMM-dd-yyyy"),
                Status = request.status
            };

            _dbContext.Tickets.Add(newTicket);
            _dbContext.SaveChanges();
            return Ok(newTicket);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteTicket(int id)
        {
            var ticket = _dbContext.Tickets.Where(t => t.TicketId == id).FirstOrDefault();

            if (ticket is not null)
            {
                _dbContext.Remove(ticket);
                _dbContext.SaveChanges();
                return Ok(ticket);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPut]
        public IActionResult UpdateTicket([FromBody]UpdateTicketDto tDto)
        {
            var ticket = _dbContext.Tickets.Where(t => t.TicketId == tDto.Id).FirstOrDefault();


            if (ticket is not null)
            {
                ticket.Description = tDto.description;
                ticket.Status = tDto.status;
                ticket.Date = tDto.date.ToString("MMMM-dd-yyyy");
                _dbContext.SaveChanges();
                return Ok(ticket);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
