
using AutoMapper;
using roadrunnerapi.DTO;
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
        

                CreateMap<AddEmployeeDTO, Employee>();
                CreateMap<UpdateEmployeeDTO, Employee>();
              CreateMap<EmployeeDocument, DocumentsToRetuen>();
            CreateMap<DocumentForCreationDto, EmployeeDocument>();
        }

    }
    }
