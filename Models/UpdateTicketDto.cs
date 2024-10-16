namespace Tickets.Api.Models
{
    public class UpdateTicketDto
    {
        public int Id { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
    }
}
