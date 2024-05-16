using ProgramApp.Application.DTOs;
using ProgramApp.Domain.Entities;

namespace ProgramApp.Application.Interfaces;

public interface IApplicationFormService
{
    Task<AppResponse<bool>> CreateAppForm(CreateAppFormDTO dto);
    Task<AppResponse<bool>> UpdateAppForm(Guid programId, UpdateAppFormDTO dto);
    Task<AppResponse<bool>> DeleteAppForm(Guid programId);
    Task<AppResponse<IEnumerable<ApplicationForm>>> GetAllForms();
}
