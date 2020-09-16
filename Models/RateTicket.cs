namespace roadrunnerapi.Models
{
    public class RateTicket
    {
    public int Id { get; set; }

    public virtual RateCard RateCard { get; set; }
    public int TicketId { get; set; }
    public virtual Ticket Ticket { get; set; }
    }
}