using Program.Application.DTOs;
using Program.Domain.Entities;

namespace Program.Application.Interfaces;

public interface IApplicationFormService
{
    Task<AppResponse<bool>> CreateAppForm(CreateAppFormDTO dto);
    Task<AppResponse<bool>> UpdateAppForm(Guid programId, UpdateAppFormDTO dto);
    Task<AppResponse<bool>> DeleteAppForm(Guid programId);
    Task<AppResponse<IEnumerable<ApplicationForm>>> GetAllForms();
}
