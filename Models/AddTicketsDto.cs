using System.ComponentModel.DataAnnotations;

namespace Tickets.Api.Models
{
    public class AddTicketsDto
    {
        public string description { get; set; }
        [AllowedValues(["O","C"])]
        public string status { get; set; }
    }
}
