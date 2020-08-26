
using AutoMapper;
using roadrunnerapi.DTO;
using roadrunnerapi.Models;

namespace roadrunnerapi.Helpers
{
    public class AutoMapperProfiles: Profile
    {
               public AutoMapperProfiles()
        {
        CreateMap<User, UserForListDTO>();
        //  .ForMember(dest => dest.PhotoUrl, opt => {
        //             opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
        //         })

            // .ForMember(dest => dest.Age, opt => opt.MapFrom(src => 
            // src.DateOfBirth.CalculateAge())); // age
            
             CreateMap<User, UserForDetailedDTO>();
            // .ForMember(dest => dest.PhotoUrl, opt => 
            // opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))

            // .ForMember(dest => dest.Age, opt => opt.MapFrom(src => 
            // src.DateOfBirth.CalculateAge())); // age

            // CreateMap<Photo, PhotosForDetailedDTO>();
            // CreateMap<UserForUpdateDto, User>();
            //   CreateMap<Photo, PhotoForReturnDto>();
            //   CreateMap<PhotoForCreationDto, Photo>();
                CreateMap<UserforRegisterDTO, User>();
        }

    }
    }
