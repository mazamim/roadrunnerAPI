using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using roadrunnerapi.DTO.Customers;
using roadrunnerapi.Models;
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
             if(list !=null )
            {
                    return Ok(_mapper.Map<IEnumerable<ReadCustomerDTO>>(list));

            }
                return NotFound();
	            
        } 

            [HttpGet("{id}",Name="GetCustomerById")]
        public async Task <ActionResult<ReadCustomerDTO>> GetCustomerById(int id)
        {
            var item = await _apiService.GetCustomerByID(id);
            if(item !=null )
            {
                    return Ok(_mapper.Map<ReadCustomerDTO>(item));
            }
            return NotFound();
        }

               [HttpPost]
        public ActionResult<ReadCustomerDTO> AddCustomer(AddCustomerDTO customer)
        {
                var Model= _mapper.Map<Customer>(customer);
               _apiService.CreateCustomer(Model);
                _apiService.SaveChanges();

                var ToReturnModel = _mapper.Map<ReadCustomerDTO>(Model);

                return CreatedAtRoute(nameof(GetCustomerById),new {id = ToReturnModel.Id },ToReturnModel);
        }

         [HttpPut("{id}")]
         public async Task <ActionResult> UpdateCustomer(int id, UpdateCustomerDTO updatedto)
         {
                var modelFromRepo =await _apiService.GetCustomerByID(id);

                if(modelFromRepo ==null)
                {
                    return NotFound();

                }
                _mapper.Map(updatedto,modelFromRepo);
           
               _apiService.UpdateCustomer(modelFromRepo);
                 _apiService.SaveChanges();
                 return NoContent();

         }
    }
}