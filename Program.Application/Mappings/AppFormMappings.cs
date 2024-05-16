using AutoMapper;
using Program.Application.DTOs;
using Program.Domain.Entities;

namespace Program.Application.Mappings;

public class AppFormMappings : Profile
{
    public AppFormMappings()
    {
        CreateMap<CreateAppFormDTO, ApplicationForm>().ReverseMap();
        CreateMap<UpdateAppFormDTO, ApplicationForm>().ReverseMap();
        CreateMap<CreateProgramDTO, Domain.Entities.Program>().ReverseMap();
        CreateMap<CreateQuestionDTO, Question>().ReverseMap();
        CreateMap<CreatePersonalInfoDTO, PersonalInfo>().ReverseMap(); 
    }
}
