using ProgramApp.Domain.Entities;
using ProgramApp.Domain.Interfaces;

namespace ProgramApp.Persistence.Repositories;

public class ApplicationResponseRepository(AppDbContext context) : Repository<ApplicationResponse>(context), IApplicationResponseRepository;
