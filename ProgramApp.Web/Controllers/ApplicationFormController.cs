using Microsoft.AspNetCore.Mvc;
using ProgramApp.Application.DTOs;
using ProgramApp.Application.Interfaces;
using ProgramApp.Web.Extensions;

namespace Program.Web.Controllers
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
