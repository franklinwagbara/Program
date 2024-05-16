using ProgramApp.Application.DTOs;
using ProgramApp.Domain.Entities;

namespace ProgramApp.Application.Interfaces;

public interface IApplicationResponseService
{
    Task<AppResponse<bool>> CreateAppResponse(CreateAppResponseDTO dto);
    Task<AppResponse<bool>> UpdateAppResponse(Guid Id, UpdateAppResponseDTO dto);
    Task<AppResponse<bool>> DeleteAppResponse(Guid programId);
    Task<AppResponse<IEnumerable<ApplicationResponse>>> GetAllAnswers();
}
