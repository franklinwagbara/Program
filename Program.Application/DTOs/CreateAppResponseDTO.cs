using Program.Domain.Entities;
using Program.Domain.Enums;

namespace Program.Application.DTOs;

public class CreateAppResponseDTO
{
    public Guid ProgramId { get; set; }
    public List<CreatePersonalInfoResDTO> PersonalInfos { get; set; } = [];
    public List<CreateAnswerResDTO> Answers { get; set; } = [];
}

public class CreatePersonalInfoResDTO
{
    public Guid PersonalInfoId { get; set; }
    public string Response { get; set; } = string.Empty;
}

public class CreateAnswerResDTO
{
    public Guid QuestionId { get; set; }
    public string Response { get; set; } = string.Empty;
}