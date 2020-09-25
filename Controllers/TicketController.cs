using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using roadrunnerapi.DTO.Employee;
using roadrunnerapi.DTO.Tickets;
using roadrunnerapi.Models;
using roadrunnerapi.Services.TicketService;

namespace roadrunnerapi.Controllers
{
         // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TicketController:ControllerBase
    {
        
        
        private readonly ITicketService _apiService;
        private readonly IMapper _mapper;
        public TicketController(ITicketService ticketservice,IMapper mapper)
        {
            _apiService = ticketservice;
            _mapper = mapper;
            
        }

        [HttpGet("GetAll")]
          public async Task <ActionResult <IEnumerable<ReadTicketDTO>>> GetAll()
        {
	            var list = await _apiService.GetAllTicket();
             if(list !=null )
            {
                    return Ok(_mapper.Map<IEnumerable<ReadTicketDTO>>(list));

            }
                return NotFound();
	            
        } 

 

                   [HttpGet("emp/{id}")]
          public async Task <ActionResult <IEnumerable<ListTEmp>>> GeTtemp(int id)
        {
	            var list = await _apiService.GetAllEmpTicket(id);
             if(list !=null )
            {
                    return Ok(_mapper.Map<IEnumerable<ListTEmp>>(list));

            }
                return NotFound();
	            
        } 

               [HttpGet("{id}",Name="GetSingleTicketBYID")]
        public async Task <ActionResult <ReadTicketDTO>> GetSingleTicketBYID(int id)
        {
            var item =await  _apiService.GetSingleTicketbyID(id);
            if(item !=null )
            {
                    return Ok(_mapper.Map<ReadTicketDTO>(item));
            }
            return NotFound();
        }


             [HttpPost]
        public ActionResult AddbulkTcket(List<AddTicketDTO> tickets)
        {
            List<Ticket> models = new List<Ticket>();
                foreach(var item in tickets)  {
                models.Add(_mapper.Map<Ticket>(item));
            
                }

                
               
               _apiService.CreatebulkRecord(models);
                _apiService.SaveChanges();

          

                return Ok(200);
        }


                 [HttpPut("{id}")]
         public async Task<ActionResult> UpdateTicket(int id, UpdateTicketDTO updatedto)
         {
                var modelFromRepo =await _apiService.GetSingleTicketbyID(id);

                if(modelFromRepo ==null)
                {
                    return NotFound();

                }
                _mapper.Map(updatedto,modelFromRepo);
           
                _apiService.UpdateTicket(modelFromRepo);
                 _apiService.SaveChanges();
                 return NoContent();

         }

     
    }
}