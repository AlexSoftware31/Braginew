using Bragi.DataLayer.Resources;
using Microsoft.Extensions.Localization;

namespace Bragi.DataLayer
{
    public interface IAppResource
    {
        string GetResource(string key);
    }
    public class SharedResources : IAppResource
    {
        private IStringLocalizer<SharedResource> _localizer;
        
        public SharedResources(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
            
        }
        public string GetResource(string key)
        {
            var a= _localizer[key];
            return a;
        }
    }
}
