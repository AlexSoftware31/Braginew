using AutoMapper;
using Bragi.DataLayer.Models.Users;
using Bragi.DataLayer.ViewModels.Users;

namespace Bragi.DataLayer.Mappings.Users
{
    public class UsersMap : Profile
    {
        public UsersMap()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
