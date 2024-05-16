using AutoMapper;
using Program.Application.DTOs;
using Program.Application.Interfaces;
using Program.Domain.Entities;
using Program.Domain.Interfaces;

namespace Program.Application.Services;

public class ApplicationFormService(IApplicationFormRepository repo, IMapper mapper) : IApplicationFormService
{
    public async Task<AppResponse<bool>> CreateAppForm(CreateAppFormDTO dto)
    {
        try
        {
            var form = mapper.Map<ApplicationForm>(dto);
            await repo.Create(form);
            var res = await repo.SaveChangesAsync();
            return new AppResponse<bool> { Result = true, IsSuccess = true };
        }
        catch (Exception e)
        {
            return new AppResponse<bool> { 
                Result = false, IsSuccess = false, 
                Error = e.Message, 
                StatusCode = System.Net.HttpStatusCode.InternalServerError 
            };
        }
    }

    public async Task<AppResponse<bool>> DeleteAppForm(Guid Id)
    {
        try
        {
            await repo.Delete(Id);
            var res = await repo.SaveChangesAsync();
            return new AppResponse<bool> { Result = true, IsSuccess = true };
        }
        catch (Exception e)
        {
            return new AppResponse<bool>
            {
                Result = false,
                IsSuccess = false,
                Error = e.Message,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<AppResponse<IEnumerable<ApplicationForm>>> GetAllForms()
    {
        try
        {
            var res = await repo.GetAll();
            return new AppResponse<IEnumerable<ApplicationForm>> { Result = res, IsSuccess = true };
        }
        catch (Exception e)
        {
            return new AppResponse<IEnumerable<ApplicationForm>>
            {
                Result = null,
                IsSuccess = false,
                Error = e.Message,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<AppResponse<bool>> UpdateAppForm(Guid Id, UpdateAppFormDTO dto)
    {
        try
        {

            var form = mapper.Map<ApplicationForm>(dto);
            await repo.Update(Id, form);
            var res = await repo.SaveChangesAsync();
            return new AppResponse<bool> { Result = true, IsSuccess = true };
        }
        catch (Exception e)
        {
            return new AppResponse<bool>
            {
                Result = false,
                IsSuccess = false,
                Error = e.Message,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
