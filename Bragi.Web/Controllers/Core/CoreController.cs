using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Utils;
using Bragi.Web.Controllers.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NetCoreUtilities.Extensions;

namespace Bragi.Web.Controllers.Core
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public abstract class CoreController<TIService, TEntity, TViewModel> : ControllerBase, ICoreController<TEntity>
    where TEntity : class
    where TViewModel : class
    where TIService : IBaseInterface<TEntity, TViewModel>
    {
        private readonly TIService _service;
        public CoreController(TIService service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
            => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var reqResult = await _service.GetByIdAsync(id);
            if (reqResult != null) return Ok(reqResult);
            return NoContent();
        }


        [HttpPost]
        public virtual async Task<IActionResult> Create(TEntity entity)
        {
            var reqResult = await _service.CreateAsync(entity);
            if (reqResult.IsSuccessfulWithNoErrors)
            {
                return Ok(reqResult.Payload);
            }

            return BadRequest(reqResult.GetMessageErrorBody());
        }

        [HttpPut]
        public virtual async Task<IActionResult> Edit(TEntity entity)
        {
            var reqResult = await _service.EditAsync(entity);
            if (reqResult.IsSuccessfulWithNoErrors)
            {
                return Ok(reqResult.Payload);
            }

            return BadRequest(reqResult.GetMessageErrorBody());
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var reqResult = await _service.DeleteAsync(id);
            if (reqResult.IsSuccessfulWithNoErrors)
            {
                return Ok(reqResult);
            }
            return BadRequest(reqResult.GetMessageErrorBody());
        }

        public virtual LanguageEnum GetEnumFromCookies()
        {
            var culture = Request.Cookies["Language"];
            var langEnum = ClassUtils.GetLangEnum(culture);
            return langEnum;
        }
    }
}