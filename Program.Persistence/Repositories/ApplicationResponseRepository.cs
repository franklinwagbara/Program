using Program.Domain.Entities;
using Program.Domain.Interfaces;

namespace Program.Persistence.Repositories;

public class ApplicationResponseRepository(AppDbContext context) : Repository<ApplicationResponse>(context), IApplicationResponseRepository;
