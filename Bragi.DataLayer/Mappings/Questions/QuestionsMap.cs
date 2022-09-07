using AutoMapper;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.ViewModels.Questions;

namespace Bragi.DataLayer.Mappings.Questions
{
    public class QuestionsMap : Profile
    {
        public QuestionsMap()
        {
            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<QuestionResponse, QuestionResponseViewModel>().ReverseMap();
            CreateMap<QuestionType, QuestionTypeViewModel>().ReverseMap();
        }
    }
}