using ProgramApp.Domain.Entities;

namespace ProgramApp.Application.DTOs;

public class UpdateAppResponseDTO
{
    public Guid Id { get; set; }
    public Guid ApplicationFormId { get; set; }
    public List<PersonalInfo> PersonalInfos { get; set; } = [];
    public List<Answer> Answers { get; set; } = [];
}