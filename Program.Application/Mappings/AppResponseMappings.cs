using AutoMapper;
using Program.Application.DTOs;
using Program.Domain.Entities;

namespace Program.Application.Mappings;

public  class AppResponseMappings: Profile
{
    public AppResponseMappings()
    {
        CreateMap<CreateAppResponseDTO, ApplicationResponse>().ReverseMap();
        CreateMap<UpdateAppResponseDTO, ApplicationResponse>().ReverseMap();
        CreateMap<CreatePersonalInfoResDTO, PersonalInfoAnswer>().ReverseMap();
        CreateMap<CreateAnswerResDTO, Answer>().ReverseMap();
    }
}
