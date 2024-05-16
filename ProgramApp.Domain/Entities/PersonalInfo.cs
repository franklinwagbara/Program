using ProgramApp.Domain.Enums;

namespace ProgramApp.Domain.Entities;

public class PersonalInfo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public PersonalInfoType Type { get; set; } = PersonalInfoType.STRING;
    public bool IsRequired { get; set; } = false;
    public bool IsInternal { get; set; } = false;
    public bool IsHidden { get; set; } = false;
}
