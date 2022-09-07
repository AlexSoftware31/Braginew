using Bragi.BussinessLayer.Interfaces.Applications;
using Microsoft.AspNetCore.Mvc;
using NetCoreUtilities.Extensions;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Bragi.DataLayer;

namespace Bragi.Web.Controllers.Core
{
    public class MvcCoreController : Controller
    {

        public void ShowNotification(string title, string message, string type)
        {
            TempData["swal"] = $"Swal.fire('{title}', '{message}', '{type.ToLower()}')";
        }


        protected async Task LogEvents<TIn, TOut>(TIn entity, TOut result)
        {
            using var file = new StreamWriter("\\\\172.16.10.60\\ImageserverDev\\Logs.json", append: true);
            await file.WriteAsync($"{HttpContext.Request.Path.ToJson()},");
            await file.WriteAsync($"{entity.ToJson()},");
            await file.WriteAsync($"{result.ToJson()},");
            await file.DisposeAsync();
        }

        protected async Task LogException(string exception)
        {
            using var file = new StreamWriter("\\\\172.16.10.60\\ImageserverDev\\Exceptions.json", append: true);

            if (!string.IsNullOrEmpty(exception))
            {
                await file.WriteAsync($"{HttpContext.Request.Path.ToJson()},");
                await file.WriteAsync($"{exception},");
            }
            await file.DisposeAsync();
        }

        public async Task<bool> CheckEmission(IApplicationsService service, string accessToken, int? applicationid)
        {
            var isEticketEmitted = await service.IsEticketEmited(accessToken, applicationid);

            if (isEticketEmitted.Payload)
            {
                return isEticketEmitted.Payload;
            }
            return isEticketEmitted.Payload;
        }
    }
}
