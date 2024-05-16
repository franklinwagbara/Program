namespace Program.Domain.Entities;

public class ApplicationForm
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Program Program { get; set; } = new();
    public List<PersonalInfo> PersonalInfos { get; set; } = [];
    public List<Question> QuestionInfos { get; set; } = [];
}
