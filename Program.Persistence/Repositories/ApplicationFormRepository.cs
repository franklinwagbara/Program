using Program.Domain.Entities;
using Program.Domain.Interfaces;

namespace Program.Persistence.Repositories;

public class ApplicationFormRepository(AppDbContext context) : Repository<ApplicationForm>(context), IApplicationFormRepository;
