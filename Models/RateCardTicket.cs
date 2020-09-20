namespace roadrunnerapi.Models
{
    public class RateCardTicket
    {
    public int Id { get; set; }

  public int RateCardId { get; set; }
  public virtual RateCard RateCard { get; set; }
    public int TicketId { get; set; }
     public virtual Ticket Ticket { get; set; }
     public int Qty { get; set; }
   
    }
}