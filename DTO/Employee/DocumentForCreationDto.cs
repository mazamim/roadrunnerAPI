using System;
using Microsoft.AspNetCore.Http;

namespace roadrunnerapi.DTO.Employee
{
    public class DocumentForCreationDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }

      

        public DocumentForCreationDto()
        {
            DateAdded = DateTime.Now;
        }
    }
}