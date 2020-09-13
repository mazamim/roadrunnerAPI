using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using roadrunnerapi.DTO.RateCard;
using roadrunnerapi.Services.RateCardService;

namespace roadrunnerapi.Controllers
{
      // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RateCardController: ControllerBase
    {
        
        private readonly IRateCardService _apiService;
        private readonly IMapper _mapper;

        public RateCardController(IRateCardService ratecardservice,IMapper mapper)
        {
            _apiService = ratecardservice;
            _mapper = mapper;
        }

                     [HttpGet("GetAll")]
          public async Task <ActionResult <IEnumerable<ReadRateCardDTO>>> GetAll()
        {
	            var list = await _apiService.GetAllRateCard();
             if(list !=null )
            {
                    return Ok(_mapper.Map<IEnumerable<ReadRateCardDTO>>(list));

            }
                return NotFound();
	            
        } 
    }
}