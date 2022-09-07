using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.Web.Controllers.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Bragi.Web.Controllers.Core
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class ReadableController<TIService, TEntity, TViewModel> : ControllerBase, IReadable
        where TEntity : class
        where TViewModel : class
        where TIService : IBaseInterface<TEntity, TViewModel>
    {
        private readonly TIService _service;
        public ReadableController(TIService service)
        {
            _service = service;
        }
        [HttpGet]
        public virtual async Task<IActionResult> GetList()
            => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var reqResult = await _service.GetByIdAsync(id);
            if (reqResult != null) return Ok(reqResult);
            return NoContent();
        }
    }
}