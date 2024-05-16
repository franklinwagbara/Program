using ProgramApp.Domain.Entities;

namespace ProgramApp.Application.DTOs;

public class UpdateAppFormDTO
{
    public Guid Id { get; set; }
    public Domain.Entities.ApplicationProgram Program { get; set; } = new();
    public List<PersonalInfo> PersonalInfos { get; set; } = [];
    public List<Question> QuestionInfos { get; set; } = [];
}
