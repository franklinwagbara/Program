using AutoMapper;
using ProgramApp.Application.DTOs;
using ProgramApp.Domain.Entities;

namespace ProgramApp.Application.Mappings;

public class AppFormMappings : Profile
{
    public AppFormMappings()
    {
        CreateMap<CreateAppFormDTO, ApplicationForm>().ReverseMap();
        CreateMap<UpdateAppFormDTO, ApplicationForm>().ReverseMap();
        CreateMap<CreateProgramDTO, Domain.Entities.ApplicationProgram>().ReverseMap();
        CreateMap<CreateQuestionDTO, Question>().ReverseMap();
        CreateMap<CreatePersonalInfoDTO, PersonalInfo>().ReverseMap(); 
    }
}
