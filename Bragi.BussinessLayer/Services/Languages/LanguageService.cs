using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Languages;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Languages;
using Bragi.DataLayer.ViewModels.Languages;

namespace Bragi.BussinessLayer.Services.Languages
{
    public class LanguageService : BaseService<Language, ProyectDbContext, LanguageViewModel>, ILanguagesService
    {
        public LanguageService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}