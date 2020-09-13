using System.Collections.Generic;

namespace roadrunnerapi.Models
{
    public class EmployeeTicket
    {
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    public int TicketId { get; set; }
    public virtual Ticket Ticket { get; set; }
    }
}