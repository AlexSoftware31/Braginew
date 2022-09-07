using Bragi.DataLayer.ViewModels.Jwt;
using NetCoreUtilities.Models;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Interfaces.Jwt
{
    public interface IJwtService
    {
        RequestResult<JwtViewModel> CreateJwt(string clientIp);
        Task<RequestResult<JwtViewModel>> CreateInternalJwt(JwtAuth user);
    }
}