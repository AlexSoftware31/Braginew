using Bragi.DataLayer.Configuration.OptionsModel;
using Bragi.DataLayer.ViewModels.Captcha;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.Captcha
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : ControllerBase
    {

        private readonly IOptions<CaptchaSecret> _captchaOptions;

        public CaptchaController(IOptions<CaptchaSecret> captchaOptions)
        {
            _captchaOptions = captchaOptions;
        }


        [HttpPost]
        public async Task<IActionResult> VerifyCaptcha(CaptchaViewModel captcha)
        {
            using var client = new HttpClient();
            var dict = new Dictionary<string, string>();
            dict.Add("secret", _captchaOptions.Value.Secret);
            dict.Add("response", captcha.Response);
            using var httpResponse = await client.PostAsync(new Uri(_captchaOptions.Value.ServerSideUrl), new FormUrlEncodedContent(dict));
            var str = await httpResponse.Content.ReadAsStringAsync();
            if (httpResponse.IsSuccessStatusCode)
            {
                var serializedResponse = JsonConvert.DeserializeObject<CaptchaResponseViewModel>(str);
                return Ok(serializedResponse);
            }
            return BadRequest(httpResponse.StatusCode);
        }
    }
}
