using Program.Domain.Entities;

namespace Program.Application.DTOs;

public class UpdateAppResponseDTO
{
    public Guid Id { get; set; }
    public Domain.Entities.Program Program { get; set; } = new();
    public List<PersonalInfo> PersonalInfos { get; set; } = [];
    public List<Answer> Answers { get; set; } = [];
}