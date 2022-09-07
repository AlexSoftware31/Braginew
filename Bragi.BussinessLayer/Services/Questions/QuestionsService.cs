using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Questions;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.ViewModels.Questions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Services.Questions
{
    public class QuestionsService : LangBaseService<Question, ProyectDbContext, QuestionViewModel>, IQuestionsService
    {
        private readonly IMapper _mapper;
        public QuestionsService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<RequestResult<List<QuestionViewModel>>> GetByTypeAndAgency(QuestionsTypeEnum type, AgenciesEnum agency, LanguageEnum lang)
        {
            var reqResult = RequestResult<List<QuestionViewModel>>.Failed();
            var list = await GetList(x => x.AgencyId == (int)agency && x.QuestionTypeId == (int)type);
            if (list.Any())
            {
                var mapped = _mapper.Map<List<QuestionViewModel>>(list);
                mapped = MapLanguagePropperty(mapped, lang);
                reqResult.SetSucceeded(mapped);
                return reqResult;
            }
            return reqResult;
        }
    }
}
