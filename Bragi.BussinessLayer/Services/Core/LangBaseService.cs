using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.ViewModels.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Services.Core
{
    public class LangBaseService<TModel, TDbContext, TViewModel> : BaseService<TModel, TDbContext, TViewModel>, ILangBaseService<TModel, TViewModel>
        where TViewModel : class, ILanguageViewModel
        where TModel : class
    where TDbContext : DbContext
    {
        private readonly IMapper _mapper;
        public LangBaseService(TDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public List<TViewModel> MapLanguagePropperty(List<TViewModel> viewModelList, LanguageEnum language)
        {
            viewModelList.ForEach(item =>
            {
                item.Text = item.GetType().GetProperty(language.ToString())?.GetValue(item, null)?.ToString();
            });
            return viewModelList;
        }

        public async Task<RequestResult<List<TViewModel>>> GetMultilanguage(LanguageEnum lang)
        {
            var reqResult = RequestResult<List<TViewModel>>.Failed();
            var list = await GetQueryable()
                .ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            if (list.Any())
            {
                list = MapLanguagePropperty(list, lang);
                reqResult.SetSucceeded(list);
                return reqResult;
            }
            return reqResult;
        }

    }
}
