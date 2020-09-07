using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using roadrunnerapi.DTO.Clients;
using roadrunnerapi.Models;
using roadrunnerapi.Services.ClientService;

namespace roadrunnerapi.Controllers
{

  // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClientController:ControllerBase
    {
        
        private readonly IClientService _apiService;
        private readonly IMapper _mapper;
        public ClientController(IClientService apiService,IMapper mapper)
        {
              _apiService= apiService;
            _mapper = mapper;
        }

            [HttpGet("GetAll")]
          public async Task <ActionResult <IEnumerable<ReadClientDTO>>> GetAll()
        {
	            var list = await _apiService.GetAllClients();
	            return Ok(_mapper.Map<IEnumerable<ReadClientDTO>>(list));
        } 

            [HttpGet("{id}",Name="GetClientById")]
        public async Task <ActionResult<ReadClientDTO>> GetClientById(int id)
        {
            var item = await _apiService.GetClientByID(id);
            if(item !=null )
            {
                    return Ok(_mapper.Map<ReadClientDTO>(item));
            }
            return NotFound();
        }

               [HttpPost]
        public ActionResult<ReadClientDTO> AddClient(AddClientDTO client)
        {
                var Model= _mapper.Map<Client>(client);
               _apiService.CreateClient(Model);
                _apiService.SaveChanges();

                var ToReturnModel = _mapper.Map<ReadClientDTO>(Model);

                return CreatedAtRoute(nameof(GetClientById),new {id = ToReturnModel.Id },ToReturnModel);
        }

         [HttpPut("{id}")]
         public async Task <ActionResult> UpdateClient(int id, UpdateClientDTO updatedto)
         {
                var modelFromRepo =await _apiService.GetClientByID(id);

                if(modelFromRepo ==null)
                {
                    return NotFound();

                }
                _mapper.Map(updatedto,modelFromRepo);
           
               _apiService.UpdateClient(modelFromRepo);
                 _apiService.SaveChanges();
                 return NoContent();

         }
    }
}