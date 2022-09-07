using Bragi.BussinessLayer.Interfaces.ETickets;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.HttpSys;
using System;

namespace Bragi.Web.Areas.Identity.Pages.Account
{
    [Authorize(Policy = "Airlines")]
    public class ScanQrModel : PageModel
    {

        private readonly IEticketsService _eticketsService;

        public ScanQrModel(IEticketsService eticketsService)
        {
            _eticketsService = eticketsService;
        }

        [BindProperty]
        public MigratoryInfoAirlineViewModel MigratoryInfoAirlineViewModel { get; set; }

        public bool HasError { get; set; }

        public async Task OnGet(string qrCode)
        {
            if (!string.IsNullOrEmpty(qrCode))
            {
                var reqResult = await _eticketsService.GetMigratoryInfoToAirlinesCheckin(qrCode);
                if (reqResult.IsSuccessfulWithNoErrors)
                {
                    MigratoryInfoAirlineViewModel = reqResult.Payload;
                }
                HasError = true;
            }
        }
    }
}
