using Program.Domain.Enums;

namespace Program.Domain.Entities;

public class Question
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public QuestionType Type { get; set; } = QuestionType.Paragraph;
    public string Value { get; set; } = string.Empty;
    public List<string> Options { get; set; } = [];
}
