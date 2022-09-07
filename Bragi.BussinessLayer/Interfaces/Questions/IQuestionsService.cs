using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.ViewModels.Questions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreUtilities.Interfaces;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Interfaces.Questions
{
    public interface IQuestionsService : IRepository<Question, QuestionViewModel>, IBaseInterface<Question, QuestionViewModel>, ILangBaseService<Question, QuestionViewModel>
    {
        Task<RequestResult<List<QuestionViewModel>>> GetByTypeAndAgency(QuestionsTypeEnum type, AgenciesEnum agency,LanguageEnum lang);
    }
}
