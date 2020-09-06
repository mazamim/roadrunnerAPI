using System;

namespace roadrunnerapi.DTO.Customers
{
    public class UpdateCustomerDTO
    {
        
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string Emailadd { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
         public DateTime Updated { get; set; }
        public UpdateCustomerDTO()
        {
            Updated = DateTime.Now;
        }
    }
}