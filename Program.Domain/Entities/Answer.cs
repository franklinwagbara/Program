namespace Program.Domain.Entities;

public class Answer
{
    public Guid QuestionId { get; set; }
    public string Response { get; set; } = string.Empty;
}
