using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bragi.BussinessLayer.Interfaces.Questions;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.ViewModels.Questions;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authorization;

namespace Bragi.Web.Controllers.Api.QuestionsResponse
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class QuestionResponseController : CoreController<IQuestionResponseService, QuestionResponse, QuestionResponseViewModel>
    {
        public QuestionResponseController(IQuestionResponseService service) : base(service)
        {
        }
    }
}
