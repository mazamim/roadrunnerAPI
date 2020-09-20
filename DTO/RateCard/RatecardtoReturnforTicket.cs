namespace roadrunnerapi.DTO.RateCard
{
    public class RatecardtoReturnforTicket
    {
        
    public int Id { get; set; }
    public int TicketId { get; set; }
    public  int RateCardID { get; set; }

    public  string RateCardName { get; set; }

      public double Rate { get; set; }
      public int Qty { get; set; }

    }
}