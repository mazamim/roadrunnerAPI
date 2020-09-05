using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using roadrunnerapi.DTO.Employee;
using roadrunnerapi.Helpers;
using roadrunnerapi.Models;
using roadrunnerapi.Services.EmployeeService;

namespace roadrunnerapi.Controllers
{
    
    [Route("employees/{empId}/documets")]
    [ApiController]
    public class DocumentsController: ControllerBase
    {
            private readonly IMapper _mapper;
            private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
            private Cloudinary _cloudinary;
            private readonly IEmployeeService _employeeService;

        public DocumentsController(IMapper mapper,IEmployeeService employeeService,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
             _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
        _employeeService = employeeService;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

               [HttpPost]
        public IActionResult AddPhotoForUser(int empId,
            [FromForm]DocumentForCreationDto documentForCreationDto)
        {


            // if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //     return Unauthorized();

            var empFromService = _employeeService.GetEmployeeByID(empId);

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
           // documentForCreationDto.EmployeeId = empId; 
            var photo = _mapper.Map<EmployeeDocument>(documentForCreationDto);

            if (!empFromService.EmployeeDocument.Any(u => u.IsMain))
                photo.IsMain = true;

            empFromService.EmployeeDocument.Add(photo);
          // _employeeService.AddDocuments(photo);

            if ( _employeeService.SaveChanges())
            {
                var photoToReturn =_mapper.Map<DocumentsToRetuen>(photo);
               // return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoToReturn);
            
           return Ok();
            
            }

            return BadRequest("Could not add the photo");
        }

            [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromservice= await _employeeService.GetPhoto(id);

            var photo = _mapper.Map<DocumentsToRetuen>(photoFromservice);

            return Ok(photo);
        }


        [HttpGet("test/{id}")]
        public async  Task <ActionResult <IEnumerable<ReturnallDocumentsDTO>>> Getalldoc(int id)
        {
            
                var documents = await _employeeService.GetAllDocuments(id);
	       
               return Ok(_mapper.Map<IEnumerable<ReturnallDocumentsDTO>>(documents));

        }

             [HttpGet("main/{id}")]
        public ActionResult <ReturnallDocumentsDTO> Getmaindoc(int id)
        {
            
                var documents = _employeeService.GetMain(id);
	       
               return Ok(_mapper.Map<ReturnallDocumentsDTO>(documents));

        }



    }

       
}