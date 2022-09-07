using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NetCoreUtilities.Models;
using NetCoreUtilities.Services;

namespace Bragi.BussinessLayer.Services.Core
{
    public class BaseService<TEntity, TDbContext, TViewModel> :
        Repository<TEntity, TDbContext, TViewModel>,
        IBaseInterface<TEntity, TViewModel>
        where TEntity : class
        where TDbContext : DbContext
        where TViewModel : class
    {
        private readonly IMapper _mapper;
        private readonly TDbContext _context;
        public BaseService(TDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public virtual async Task<RequestResult<TViewModel>> CreateAsync(TEntity entity)
        {
            return await base.CreateAsync(entity);
        }

        public async Task<RequestResult<List<TViewModel>>> CreateRange(List<TEntity> range)
        {
            var result = RequestResult<List<TViewModel>>.Failed();
            try
            {
                IDbContextTransaction transaction = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
                var set = _context.Set<TEntity>();
                await set.AddRangeAsync(range);
                var saveResult = await _context.SaveChangesAsync();

                if (saveResult > 0)
                {
                    await transaction.CommitAsync();
                    var mapped = _mapper.Map<List<TViewModel>>(range);
                    result.SetSucceeded(mapped);
                }
                else
                {
                    await transaction.RollbackAsync();
                }

                return result;
            }
            catch (Exception e)
            {
                result.AddError(e.Message);
                return result;
            }
        }

        public virtual async Task<RequestResult<TViewModel>> EditAsync(TEntity entity)
        {
            return await base.EditAsync(entity);
        }

        public virtual async Task<RequestResult> DeleteAsync(int id)
        {
            try
            {
                await DeleteByIdAsync(id);
                return await CommitAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<DataCollection<TViewModel>> GetPagedList(int page = 1, int take = 20)
        {

            var list = await GetPagedAsync(page, take, x => x.OrderByDescending(u => u.GetType().GetProperty("CreationDate")));
            return _mapper.Map<DataCollection<TViewModel>>(list); ;
        }

        public virtual async Task<IEnumerable<TViewModel>> GetAll(bool includeAll = false)
        {
            var list = await GetAllAsync();
            var mappedList = _mapper.Map<IEnumerable<TViewModel>>(list);
            return mappedList;
        }

        public virtual async Task<TViewModel> GetBy(Expression<Func<TEntity, bool>> predicate, bool includeAll = false)
        {
            var model = await GetAsync(predicate, includeAll);
            return _mapper.Map<TViewModel>(model);
        }

        public virtual async Task<TViewModel> GetByIdAsync(int id)
        {
            var entity = await GetEntityByIdAsync(id);
            return _mapper.Map<TViewModel>(entity);
        }
    }
}