using System.Threading.Tasks;
using Bragi.BussinessLayer.Interfaces.Questions;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.Utils;
using Bragi.DataLayer.ViewModels.Questions;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bragi.Web.Controllers.Api.Questions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class QuestionsController : ReadableController<IQuestionsService,Question,QuestionViewModel>
    {

        private readonly IQuestionsService _service;
        public QuestionsController(IQuestionsService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("{type}/{agency}")]
        public async Task<IActionResult> GetList(QuestionsTypeEnum type,AgenciesEnum agency)
        {
            var culture = Request.Cookies["Language"];
            var lang = ClassUtils.GetLangEnum(culture);
            var result =
                await _service.GetByTypeAndAgency(type, agency, lang);
            if (result.IsSuccessfulWithNoErrors) return Ok(result.Payload);
            return NoContent();
        }
    }
}