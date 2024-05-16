using Microsoft.EntityFrameworkCore;
using ProgramApp.Domain.Entities;
using ProgramApp.Domain.Interfaces;

namespace ProgramApp.Persistence.Repositories;

public class ApplicationFormRepository(AppDbContext context) : Repository<ApplicationForm>(context), IApplicationFormRepository;
