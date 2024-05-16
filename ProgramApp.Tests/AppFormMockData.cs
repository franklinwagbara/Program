using ProgramApp.Domain.Entities;

namespace ProgramApp.Tests;

public class AppFormMockData
{
    public static ApplicationForm Get()
    {
        return new ApplicationForm()
            {
                Id = Guid.NewGuid(),
                Program = new ApplicationProgram
                {
                    Id = Guid.NewGuid(),
                    Title = "Test",
                    Description = "Test",
                },
                PersonalInfos = [
                    new PersonalInfo{
                        Id = Guid.NewGuid(),
                        Name = "Test",
                    }
                ],
                QuestionInfos =
                [
                    new Question
                    {
                        Id = Guid.NewGuid(),
                        Value = "Test"
                    }
                ]
            };
    }
}
