using NetCoreUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Interfaces.Core
{
    public interface IBaseInterface<TEntity, TViewModel> where TEntity : class where TViewModel : class
    {
        Task<RequestResult<TViewModel>> CreateAsync(TEntity entity);
        Task<RequestResult<List<TViewModel>>> CreateRange(List<TEntity> range);
        Task<RequestResult<TViewModel>> EditAsync(TEntity entity);
        Task<RequestResult> DeleteAsync(int id);
        Task<DataCollection<TViewModel>> GetPagedList(int page = 1, int take = 20);
        Task<IEnumerable<TViewModel>> GetAll(bool includeAll = false);
        Task<TViewModel> GetBy(Expression<Func<TEntity, bool>> predicate, bool includeAll = false);
        Task<TViewModel> GetByIdAsync(int id);
    }

}
