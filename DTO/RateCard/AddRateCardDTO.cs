namespace roadrunnerapi.DTO.RateCard
{
    public class AddRateCardDTO
    {
        public string Sor { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public double Rate { get; set; }
        public string Category { get; set; }
        public string Remarks { get; set; }
       
       public int ClientId { get; set; }
    }
}