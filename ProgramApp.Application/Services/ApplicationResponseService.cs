using AutoMapper;
using ProgramApp.Application.DTOs;
using ProgramApp.Application.Exceptions;
using ProgramApp.Application.Interfaces;
using ProgramApp.Domain.Entities;
using ProgramApp.Domain.Interfaces;

namespace ProgramApp.Application.Services;

public class ApplicationResponseService(
    IApplicationResponseRepository resRepo, 
    IApplicationFormRepository formRepo,
    IMapper mapper) : IApplicationResponseService
{
    public async Task<AppResponse<bool>> CreateAppResponse(CreateAppResponseDTO dto)
    {
        try
        {
            var form = await formRepo.GetById(dto.ApplicationFormId)
                ?? throw new NotFoundException($"A Form with Id {dto.ApplicationFormId} was not found!");

            var isPIValid = ValidatePersonalInfoRes(dto.PersonalInfos, form.PersonalInfos);
            var isAnswersValid = ValidateAnswers(dto.Answers, form.QuestionInfos);

            if (!isPIValid && !isAnswersValid) 
                throw new Exception("Something went wrong when validating answers");

            var response = mapper.Map<ApplicationResponse>(dto);
            await resRepo.Create(response);
            var res = await resRepo.SaveChangesAsync();
            return new AppResponse<bool> { Result = true, IsSuccess = true };
        }
        catch (Exception e)
        {
            return new AppResponse<bool>
            {
                Result = false,
                IsSuccess = false,
                Error = e.Message,
                Message = e.Message,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }

    private bool ValidateAnswers(List<CreateAnswerResDTO>? answers, List<Question>? questions)
    {
        if (answers == null || answers.Count == 0) return true;
        if (answers != null && answers.Count > 0 && (questions == null || questions.Count == 0))
            throw new Exception("No questions was specified!");

        var personalInfoDic = questions.ToDictionary(x => x.Id);

        foreach (var answer in answers)
        {
            if (!personalInfoDic.ContainsKey(answer.QuestionId))
                throw new NotFoundException($"The Question with Id={answer.QuestionId} was not found in the application form!");
        }
        return true;
    }

    private bool ValidatePersonalInfoRes(List<CreatePersonalInfoResDTO>? personalInfosRes, List<PersonalInfo>? personalInfos)
    {
        if (personalInfos == null || personalInfos.Count == 0)
            throw new ArgumentNullException("Personal Info can not be null or empty!");

        if (personalInfosRes == null && personalInfos != null)
            throw new ArgumentNullException("Personal info must have a value!");

        var personalInfoDic = personalInfos!.ToDictionary(x => x.Id);

        //Just simplifying the use case here. 
        //With enough time, we should check that mandatory personal infos are provided
        if (personalInfosRes == null) return true;

        foreach (var pi in personalInfosRes)
        {
            if (!personalInfoDic.ContainsKey(pi.PersonalInfoId))
                throw new NotFoundException($"The Personal Info with Id={pi.PersonalInfoId} was not found in the application form!");
        }
        return true;
    }

    public Task<AppResponse<bool>> DeleteAppResponse(Guid programId)
    {
        throw new NotImplementedException();
    }

    public async Task<AppResponse<bool>> UpdateAppResponse(Guid Id, UpdateAppResponseDTO dto)
    {
        try
        {
            var form = await resRepo.GetById(Id)
                ?? throw new NotFoundException($"A program with Id {Id} was not found!");

            var response = mapper.Map<ApplicationResponse>(dto);
            await resRepo.Update(Id, response);
            var res = await resRepo.SaveChangesAsync();
            return new AppResponse<bool> { Result = true, IsSuccess = true };
        }
        catch (Exception e)
        {
            return new AppResponse<bool>
            {
                Result = false,
                IsSuccess = false,
                Error = e.Message,
                Message = e.Message,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<AppResponse<IEnumerable<ApplicationResponse>>> GetAllAnswers()
    {
        try
        {
            var res = await resRepo.GetAll();
            return new AppResponse<IEnumerable<ApplicationResponse>> { Result = res, IsSuccess = true };
        }
        catch (Exception e)
        {
            return new AppResponse<IEnumerable<ApplicationResponse>>
            {
                Result = null,
                IsSuccess = false,
                Error = e.Message,
                Message = e.Message,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
