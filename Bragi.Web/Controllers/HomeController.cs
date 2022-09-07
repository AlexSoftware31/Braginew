using Bragi.DataLayer.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Bragi.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
         
        }

        public  IActionResult Index()
        {
            var cookie = Request.Cookies["Language"];
            if (string.IsNullOrEmpty(cookie))
            {
                SetCulture("es-ES");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SetCulture(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture?? "es-ES")),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
            var lang = ClassUtils.DefineCookieEnum(culture?? "es-ES");
            Response.Cookies.Append("Language", lang.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
            Response.Cookies.Append("Iso2Lang", culture, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture="es-ES", string returnUrl="")
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            var lang = ClassUtils.DefineCookieEnum(culture);
            Response.Cookies.Append("Language", lang.ToString(), new CookieOptions{Expires = DateTimeOffset.UtcNow.AddDays(1) });
            Response.Cookies.Append("Iso2Lang", culture, new CookieOptions{Expires = DateTimeOffset.UtcNow.AddDays(1) });
            return Redirect(returnUrl);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
