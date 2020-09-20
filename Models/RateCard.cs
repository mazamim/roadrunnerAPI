using System.Collections.Generic;

namespace roadrunnerapi.Models
{
    public class RateCard
    {
        public int Id { get; set; }
        public string Sor { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public double Rate { get; set; }
        public string Category { get; set; }
        public string Remarks { get; set; }
       
        public virtual Client Client { get; set; }
        public int ClientId { get; set; }
        public virtual ICollection<RateCardTicket> RateTicket { get; set; }
        
    }
}