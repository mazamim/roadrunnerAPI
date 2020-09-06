using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using roadrunnerapi.DTO.Customers;
using roadrunnerapi.Services.CustomerService;

namespace roadrunnerapi.Controllers
{   
    
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController:ControllerBase
    {
        
        private readonly IcustomerService _apiService;
        private readonly IMapper _mapper;
        public CustomerController(IcustomerService apiService,IMapper mapper)
        {
              _apiService= apiService;
            _mapper = mapper;
        }
                [HttpGet("GetAll")]
          public async Task <ActionResult <IEnumerable<ReadCustomerDTO>>> GetAll()
        {
	            var list = await _apiService.GetAllCustomer();
	            return Ok(_mapper.Map<IEnumerable<ReadCustomerDTO>>(list));
        } 
    }
}