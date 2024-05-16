namespace ProgramApp.Domain.Entities;

public class ApplicationResponse
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<PersonalInfoAnswer> PersonalInfos { get; set; } = [];
    public List<Answer> Answers { get; set; } = [];
}
