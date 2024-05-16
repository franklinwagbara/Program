using Microsoft.AspNetCore.Mvc;
using ProgramApp.API.Extensions;
using ProgramApp.Application.DTOs;
using ProgramApp.Application.Interfaces;

namespace ProgramApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationFormController : Controller
    {
        private readonly IApplicationFormService _formService;
        public ApplicationFormController(IApplicationFormService formService) 
        {
            _formService = formService;
        }

        [HttpPost("CreateForm")]
        public async Task<IActionResult> CreateAppForm([FromBody]CreateAppFormDTO dto)
        {
            return (await _formService.CreateAppForm(dto)).ToActionResult();
        }

        [HttpGet("GetAllAppForms")]
        public async Task<IActionResult> GetAllAppForms()
        {
            return (await _formService.GetAllForms()).ToActionResult();
        }
    }
}
