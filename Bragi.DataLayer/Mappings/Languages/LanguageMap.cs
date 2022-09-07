using AutoMapper;
using Bragi.DataLayer.Models.Languages;
using Bragi.DataLayer.ViewModels.Languages;

namespace Bragi.DataLayer.Mappings.Languages
{
    public class LanguageMap:Profile
    {
        public LanguageMap()
        {
            CreateMap<Language,LanguageViewModel>();
        }
    }
}