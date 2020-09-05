using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using roadrunnerapi.DTO.Employee;
using roadrunnerapi.Models;
using roadrunnerapi.Services.EmployeeService;

namespace roadrunnerapi.Controllers
{  
   // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController: ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService,IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

      

        [HttpGet("GetAll")]
          public async Task <ActionResult <IEnumerable<ReadEmployeeDTO>>> GetAllEmlployees()
        {
	            var emplist = await _employeeService.GetAllEmployee();
	            return Ok(_mapper.Map<IEnumerable<ReadEmployeeDTO>>(emplist));
        } 

        [HttpGet("{id}",Name="GetEmployeeById")]
        public ActionResult <ReadEmployeeDTO> GetEmployeeById(int id)
        {
            var item = _employeeService.GetEmployeeByID(id);
            if(item !=null )
            {
                    return Ok(_mapper.Map<ReadEmployeeDTO>(item));
            }
            return NotFound();
        }


        [HttpPost]
        public ActionResult<ReadEmployeeDTO> AddEmployee(AddEmployeeDTO employee)
        {
                var Model= _mapper.Map<Employee>(employee);
               _employeeService.CreateEmployee(Model);
                _employeeService.SaveChanges();

                var ToReturnModel = _mapper.Map<ReadEmployeeDTO>(Model);

                return CreatedAtRoute(nameof(GetEmployeeById),new {id = ToReturnModel.Id },ToReturnModel);
        }

         [HttpPut("{id}")]
         public ActionResult UpdateEmployee(int id, UpdateEmployeeDTO updatedto)
         {
                var modelFromRepo = _employeeService.GetEmployeeByID(id);

                if(modelFromRepo ==null)
                {
                    return NotFound();

                }
                _mapper.Map(updatedto,modelFromRepo);
           
                _employeeService.UpdateEployee(modelFromRepo);
                 _employeeService.SaveChanges();
                 return NoContent();

         }


        [HttpPost("attendance")]
        public ActionResult<ReadAttendanceDTO> AddPunchIn(AddAttendaceDTO atd)
        {
                var Model= _mapper.Map<Attendance>(atd);
               _employeeService.SaveAttendance(Model);
                _employeeService.SaveChanges();

                var ToReturnModel = _mapper.Map<ReadAttendanceDTO>(Model);

                return ToReturnModel;
        }

            [HttpPut("attendance/{id}")]
         public ActionResult AddPunchOut(int id, UpdateAttendanceDTO updatedto)
         {
                var modelFromRepo = _employeeService.GetAttendanceByID(id);

                if(modelFromRepo ==null)
                {
                    return NotFound();

                }
                _mapper.Map(updatedto,modelFromRepo);
           
                _employeeService.UpdateAttendance(modelFromRepo);
                 _employeeService.SaveChanges();
                 return NoContent();

         }

    }


}