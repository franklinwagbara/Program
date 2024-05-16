using ProgramApp.Domain.Entities;
using ProgramApp.Domain.Enums;

namespace ProgramApp.Application.DTOs;

public class CreateAppFormDTO
{
    public CreateProgramDTO Program { get; set; } = new();
    public List<CreatePersonalInfoDTO> PersonalInfos { get; set; } = [];
    public List<CreateQuestionDTO> QuestionInfos { get; set; } = [];
}

public class CreateProgramDTO
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class CreatePersonalInfoDTO
{
    public string Name { get; set; } = string.Empty;
    public PersonalInfoType Type { get; set; } = PersonalInfoType.STRING;
    public bool IsRequired { get; set; } = false;
    public bool IsInternal { get; set; } = false;
    public bool IsHidden { get; set; } = false;
}

public class CreateQuestionDTO
{
    public QuestionType Type { get; set; } = QuestionType.Paragraph;
    public string Value { get; set; } = string.Empty;
    public List<string> Options { get; set; } = [];
}