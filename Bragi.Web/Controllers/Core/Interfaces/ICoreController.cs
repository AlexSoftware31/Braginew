using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bragi.Web.Controllers.Core.Interfaces
{
    public interface ICoreController<TEntity> where TEntity : class
    {
        Task<IActionResult> Get();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(TEntity entity);
        Task<IActionResult> Edit(TEntity entity);
        Task<IActionResult> Delete(int id);
    }
}
