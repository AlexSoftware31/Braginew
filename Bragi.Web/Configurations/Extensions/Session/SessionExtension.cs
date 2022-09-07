using Microsoft.AspNetCore.Http;
using NetCoreUtilities.Extensions;

namespace Bragi.Web.Configurations.Extensions.Session
{
    public static class SessionExtension
    {
        public static void SetJsonSessionObj<T>(this HttpContext _,string constantKey, T objToSave) => _.Session.SetString(constantKey, objToSave.ToJson());
        public static object GetSessionJson(this HttpContext _, string constantKey) => _.Session.GetString(constantKey);
    }
}
