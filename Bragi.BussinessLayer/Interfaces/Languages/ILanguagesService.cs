using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Languages;
using Bragi.DataLayer.ViewModels.Languages;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.Languages
{
    public interface ILanguagesService : IRepository<Language,LanguageViewModel>, IBaseInterface<Language, LanguageViewModel>
    {
         
    }
}