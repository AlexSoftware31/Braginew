using Bragi.DataLayer.ViewModels.PublicHealths;

namespace Bragi.BussinessLayer.Interfaces.PublicHealths
{
    public interface IPublicHealthValidatorService
    {
        bool IsPublicHealthViewModelValid(PublicHealthViewModel publicHealthViewModel);
    }
}