
using AutoMapper;
using roadrunnerapi.DTO;
using roadrunnerapi.DTO.Clients;
using roadrunnerapi.DTO.Customers;
using roadrunnerapi.DTO.Employee;
using roadrunnerapi.DTO.RateCard;
using roadrunnerapi.DTO.Tickets;
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
                 CreateMap<Employee, ReadEmployeeforTicketDTO>();
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

                          //ratecard
              CreateMap<RateCard, ReadRateCardDTO>()
              .ForMember(d => d.ClientName, o => o.MapFrom(s => s.Client.ClientName));
              CreateMap<AddRateCardDTO, RateCard>();
      
                CreateMap<AddRateCardtoTicketDTO, RateCardTicket>();

                CreateMap<RateCardTicket, AddRateCardtoTicketDTO>()
               .ForMember(d => d.RateCardId, o => o.MapFrom(s => s.RateCard.Id));
              CreateMap<RateCardTicket, RatecardtoReturnforTicket>()
              .ForMember(d => d.RateCardID, o => o.MapFrom(s => s.RateCard.Id))
              .ForMember(d => d.Rate, o => o.MapFrom(s => s.RateCard.Rate))
              .ForMember(d => d.RateCardName, o => o.MapFrom(s => s.RateCard.Sor));
                
                  CreateMap<AddRatestoTicketDto, RateCardTicket>();
// .BeforeMap((s,d)=>{

//   s.RateCardID=d.RateCard.Id;
// });
           
            
              //CreateMap<UpdateClientDTO, Client>();

                 //Ticket
              CreateMap<Ticket, ReadTicketDTO>()
              .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Customer.CustomerName))
              .ForMember(d => d.ClientName, o => o.MapFrom(s => s.Client.ClientName));
            CreateMap<TicketDocumet, TicketToRetuen>();
            CreateMap<TicketPicForCreationDto, TicketDocumet>();
              CreateMap<TicketDocumet, ReturnallTicketDocumentsDTO>();
             CreateMap<UpdateTicketDTO, Ticket>();
              
         
              
          CreateMap<EmployeeTicket, ListTEmp>()
          .ForMember(d => d.Employee, o => o.MapFrom(s => s.Employee.EmployeeName))
          .ForMember(d => d.Address, o => o.MapFrom(s => s.Ticket.Address));
          CreateMap<AddTicketDTO, Ticket>();

          //  CreateMap<EmployeeTicket, ListTEmp>();
        }

    }
    }
