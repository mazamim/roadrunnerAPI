using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using roadrunnerapi.DTO.RateCard;
using roadrunnerapi.Models;
using roadrunnerapi.Services.RateCardService;

namespace roadrunnerapi.Controllers
{

   // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RateCardController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRateCardService _apiService;
        
        public RateCardController(IMapper mapper, IRateCardService ratecard )
        {
            _mapper = mapper;
            _apiService = ratecard;

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

        [HttpPost]
        public ActionResult AddbulkRateCard(List<AddRateCardDTO> tickets)
        {
            List<RateCard> models = new List<RateCard>();
                foreach(var item in tickets)  {
                models.Add(_mapper.Map<RateCard>(item));
            
                }
               _apiService.CreatebulkRecord(models);
                _apiService.SaveChanges();
                return Ok(200);
        }
    }
}