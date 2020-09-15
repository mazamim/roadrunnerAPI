using System;
using Microsoft.AspNetCore.Http;

namespace roadrunnerapi.DTO.Tickets
{
    public class TicketPicForCreationDto
    {
               public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }

      

        public TicketPicForCreationDto()
        {
            DateAdded = DateTime.Now;
        }
    }
}