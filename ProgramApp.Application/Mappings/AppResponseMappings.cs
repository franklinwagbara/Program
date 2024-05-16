using AutoMapper;
using ProgramApp.Application.DTOs;
using ProgramApp.Domain.Entities;

namespace ProgramApp.Application.Mappings;

public class AppResponseMappings: Profile
{
    public AppResponseMappings()
    {
        CreateMap<CreateAppResponseDTO, ApplicationResponse>().ReverseMap();
        CreateMap<UpdateAppResponseDTO, ApplicationResponse>().ReverseMap();
        CreateMap<CreatePersonalInfoResDTO, PersonalInfoAnswer>().ReverseMap();
        CreateMap<CreateAnswerResDTO, Answer>().ReverseMap();
    }
}
