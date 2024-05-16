using Program.Application.DTOs;

namespace Program.Application.Interfaces;

public interface IApplicationResponseService
{
    Task<AppResponse<bool>> CreateAppResponse(CreateAppResponseDTO dto);
    Task<AppResponse<bool>> UpdateAppResponse(Guid Id, UpdateAppResponseDTO dto);
    Task<AppResponse<bool>> DeleteAppResponse(Guid programId);
}
