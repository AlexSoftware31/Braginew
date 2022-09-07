using Bragi.BussinessLayer.Interfaces.Jwt;
using Bragi.DataLayer.Configuration.OptionsModel;
using Bragi.DataLayer.Models.Users;
using Bragi.DataLayer.ViewModels.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetCoreUtilities.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Services.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly JwtConfig _options;
        private readonly UserManager<User> _userManager;

        public JwtService(IOptions<JwtConfig> options, UserManager<User> userManager)
        {
            _options = options.Value;
            _userManager = userManager;
        }


        public  RequestResult<JwtViewModel> CreateJwt(string clientIp)
        {
            var reqResult = RequestResult<JwtViewModel>.Failed();
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var claims = new ClaimsIdentity(
                    new[]
                    {
                    new Claim(ClaimTypes.Name, clientIp)
                    }
                );
                //var jwt = new JwtSecurityToken(issuer: _options.ValidIssuer, audience: _options.ValidAudience,
                //    claims: claims, signingCredentials: creds);
                var descriptor = new SecurityTokenDescriptor()
                {
                    Audience = _options.ValidAudience,
                    Issuer = _options.ValidIssuer,
                    IssuedAt = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddMinutes(_options.ExpirationMinutes),//TODO change this to more minutes,
                    Subject = claims,
                    SigningCredentials = creds
                };
                var handler = new JwtSecurityTokenHandler();
                var token = handler.CreateJwtSecurityToken(descriptor);
                var result = new JwtViewModel
                {
                    BearerToken = handler.WriteToken(token),
                    Expiration = descriptor.Expires.Value
                };
                return reqResult.SetSucceeded(result);
            }
            catch (Exception e)
            {
                return reqResult.AddError(e.Message);
            }
        }

        public async Task<RequestResult<JwtViewModel>> CreateInternalJwt(JwtAuth user)
        {
            var reqResult = RequestResult<JwtViewModel>.Failed();
            try
            {
                var userinfo = await _userManager.FindByNameAsync(user.User);

                if (userinfo == null)return reqResult;

                var isVerified =_userManager.PasswordHasher.VerifyHashedPassword(userinfo, userinfo.PasswordHash, user.Password);


                if (isVerified == PasswordVerificationResult.Failed) return  reqResult;

                var isInroles = await _userManager.IsInRoleAsync(userinfo, "Poster");
                if (!isInroles) return reqResult;
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var claims = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Role, "Poster")
                    }
                );
                var descriptor = new SecurityTokenDescriptor()
                {
                    Audience = _options.ValidAudience,
                    Issuer = _options.ValidIssuer,
                    IssuedAt = DateTime.UtcNow,
                    Subject = claims,
                    SigningCredentials = creds
                };
                var handler = new JwtSecurityTokenHandler();
                var token = handler.CreateJwtSecurityToken(descriptor);
                var result = new JwtViewModel
                {
                    BearerToken = handler.WriteToken(token)
                };
                return reqResult.SetSucceeded(result);
            }
            catch (Exception e)
            {
                return reqResult.AddError(e.Message);
            }
        }
    }
}
