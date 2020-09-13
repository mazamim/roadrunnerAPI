

namespace roadrunnerapi.DTO.RateCard
{
    public class ReadRateCardDTO
    {
        public int Id { get; set; }
        public string Sor { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public double Rate { get; set; }
        public string Category { get; set; }
        public string Remarks { get; set; }
       
        public string ClientName { get; set; }
    }
}