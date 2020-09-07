
using AutoMapper;
using roadrunnerapi.DTO;
using roadrunnerapi.DTO.Clients;
using roadrunnerapi.DTO.Customers;
using roadrunnerapi.DTO.Employee;
using roadrunnerapi.Models;

namespace roadrunnerapi.Helpers
{
    public class AutoMapperProfiles: Profile
    {
               public AutoMapperProfiles()
        {
        CreateMap<User, UserForListDTO>();

            
             CreateMap<User, UserForDetailedDTO>();
   

                CreateMap<UserforRegisterDTO, User>();
                CreateMap<Employee, ReadEmployeeDTO>();
                   CreateMap<EmployeeDocument, ReturnallDocumentsDTO>();
        
                  CreateMap<Attendance, ReadAttendanceDTO>();
                  CreateMap<AddAttendaceDTO, Attendance>();
                     CreateMap<UpdateAttendanceDTO, Attendance>();

                CreateMap<AddEmployeeDTO, Employee>();
                CreateMap<UpdateEmployeeDTO, Employee>();
              CreateMap<EmployeeDocument, DocumentsToRetuen>();
            CreateMap<DocumentForCreationDto, EmployeeDocument>();

            //customer
              CreateMap<Customer, ReadCustomerDTO>();
              CreateMap<AddCustomerDTO, Customer>();
              CreateMap<UpdateCustomerDTO, Customer>();

                  //client
              CreateMap<Client, ReadClientDTO>();
              CreateMap<AddClientDTO, Client>();
              CreateMap<UpdateClientDTO, Client>();
        }

    }
    }
