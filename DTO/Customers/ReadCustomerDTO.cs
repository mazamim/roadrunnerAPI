using System;

namespace roadrunnerapi.DTO.Customers
{
    public class ReadCustomerDTO
    {
           public int Id { get; set; }
         public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string Emailadd { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
         public DateTime Updated { get; set; }
    }
}