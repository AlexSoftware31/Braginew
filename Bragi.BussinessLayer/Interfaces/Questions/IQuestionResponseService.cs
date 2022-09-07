using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.ViewModels.Questions;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.Questions
{
    public interface IQuestionResponseService : IRepository<QuestionResponse, QuestionResponseViewModel>, IBaseInterface<QuestionResponse, QuestionResponseViewModel>
    {
    }
}
