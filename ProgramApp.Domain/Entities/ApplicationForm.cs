namespace ProgramApp.Domain.Entities;

public class ApplicationForm
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public ApplicationProgram Program { get; set; } = new();
    public List<PersonalInfo> PersonalInfos { get; set; } = [];
    public List<Question> QuestionInfos { get; set; } = [];
}
