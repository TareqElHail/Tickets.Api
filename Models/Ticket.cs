using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tickets.Api.Models
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TicketId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
    }
}
