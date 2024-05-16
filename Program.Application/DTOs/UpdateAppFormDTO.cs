using Program.Domain.Entities;

namespace Program.Application.DTOs;

public class UpdateAppFormDTO
{
    public Guid Id { get; set; }
    public Domain.Entities.Program Program { get; set; } = new();
    public List<PersonalInfo> PersonalInfos { get; set; } = [];
    public List<Question> QuestionInfos { get; set; } = [];
}
