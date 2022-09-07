using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Questions;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.ViewModels.Questions;

namespace Bragi.BussinessLayer.Services.Questions
{
    public class QuestionResponseService : BaseService<QuestionResponse, ProyectDbContext, QuestionResponseViewModel>, IQuestionResponseService
    {
        public QuestionResponseService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
