using Bragi.DataLayer.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Interfaces.Core
{
    public interface ILangBaseService<TModel, TViewModel> where TModel : class where TViewModel : class
    {
        List<TViewModel> MapLanguagePropperty(List<TViewModel> viewModelList, LanguageEnum language);
        Task<RequestResult<List<TViewModel>>> GetMultilanguage(LanguageEnum lang);
        
    }
}