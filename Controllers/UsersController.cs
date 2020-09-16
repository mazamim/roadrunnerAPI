using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using roadrunnerapi.Data;
using roadrunnerapi.DTO;
using roadrunnerapi.DTO.RateCard;
using roadrunnerapi.Models;

namespace roadrunnerapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
    {

    private readonly IDRepositary _repo;
    private readonly IMapper _mapper;

        public UsersController(IDRepositary repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        [HttpGet("{Id}", Name = "GetUser" )]
        public async Task<IActionResult> GetUser(int id){

            var user= await _repo.GetUser(id);
            var userToReturn = _mapper.Map<UserForDetailedDTO>(user);
            return Ok(userToReturn);

        }

 
        
    }
}