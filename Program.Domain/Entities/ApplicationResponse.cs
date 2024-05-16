﻿namespace Program.Domain.Entities;

public class ApplicationResponse
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Program Program { get; set; } = new();
    public List<PersonalInfo> PersonalInfos { get; set; } = [];
    public List<Answer> Answers { get; set; } = [];
}
