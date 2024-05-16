using Program.Domain.Entities;

namespace Program.Domain.Interfaces;

public interface IApplicationFormRepository: IRepository<ApplicationForm>
{
    Task<ApplicationForm> GetByProgramId(Guid ProgramId);
}
