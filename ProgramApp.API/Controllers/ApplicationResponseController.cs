using Microsoft.AspNetCore.Mvc;
using ProgramApp.API.Extensions;
using ProgramApp.Application.DTOs;
using ProgramApp.Application.Interfaces;

namespace ProgramApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationResponseController(IApplicationResponseService resService) : Controller
    {
        private readonly IApplicationResponseService _resService = resService;

        [HttpPost("Submit")]
        public async Task<IActionResult> Submit([FromBody]CreateAppResponseDTO dto)
        {
            return (await _resService.CreateAppResponse(dto)).ToActionResult();
        }

        [HttpGet("GetAllFormAnswers")]
        public async Task<IActionResult> GetAllFormAnswers()
        {
            return (await _resService.GetAllAnswers()).ToActionResult();
        }
    }
}
