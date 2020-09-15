using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using roadrunnerapi.DTO.Tickets;
using roadrunnerapi.Helpers;
using roadrunnerapi.Models;
using roadrunnerapi.Services.EmployeeService;
using roadrunnerapi.Services.TicketService;

namespace roadrunnerapi.Controllers
{

     [Route("ticket/{tktId}/documets")]
    [ApiController]
    public class TicketPicturesController: ControllerBase
    {
            private readonly IMapper _mapper;
            private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
            private Cloudinary _cloudinary;
            private readonly ITicketService _Service;

            public TicketPicturesController(IMapper mapper,ITicketService Service,
            IOptions<CloudinarySettings> cloudinaryConfig)
            {
                 _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
        _Service = Service;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
            }

                       [HttpPost]
        public async Task <IActionResult> AddPhotoForTicket(int tktId,
            [FromForm]TicketPicForCreationDto documentForCreationDto)
        {
            var tktFromService =await _Service.GetSingleTicketbyID(tktId);
            var file = documentForCreationDto.File;
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation()
                            .Width(500).Height(500).Crop("fill").Gravity("face")
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            documentForCreationDto.Url = uploadResult.Url.ToString();
            documentForCreationDto.PublicId = uploadResult.PublicId;
            var photo = _mapper.Map<TicketDocumet>(documentForCreationDto);

            if (!tktFromService.TicketDocument.Any(u => u.IsMain))
                photo.IsMain = true;

       
            tktFromService.TicketDocument.Add(photo);
    

            if ( _Service.SaveChanges())
            {
                var photoToReturn =_mapper.Map<TicketToRetuen>(photo);
               // return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoToReturn);
            
           return Ok();
            
            }

            return BadRequest("Could not add the photo");
        }

                [HttpGet("all/{id}")]
        public async  Task <ActionResult <IEnumerable<ReturnallTicketDocumentsDTO>>> Getallticketdoc(int id)
        {
            
                var documents = await _Service.GetAllTicketDocuments(id);
	       
               return Ok(_mapper.Map<IEnumerable<ReturnallTicketDocumentsDTO>>(documents));

        }
    }
}