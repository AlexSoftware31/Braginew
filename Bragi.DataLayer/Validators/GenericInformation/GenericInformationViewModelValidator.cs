using System.Data;
using Bragi.DataLayer.ViewModels.GenericInformations;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Bragi.DataLayer.Validators.GenericInformation
{

    public class GenericInformationViewModelValidator : AbstractValidator<GenericInformationViewModel>
    {
        private readonly IStringLocalizer<Bragi.DataLayer.SharedResource> _localizer;
        public GenericInformationViewModelValidator(IStringLocalizer<Bragi.DataLayer.SharedResource> localizer)
        {
            _localizer = localizer;
            RuleFor(x => x.PermanentResidenceAdress)
                .NotEmpty()
                .WithMessage(x => _localizer["Required"])
                .Length(4, 100)
                .WithMessage(x => _localizer["GI.Val.PermAddr"]);

            RuleFor(x => x.CountryResidence)
                .NotEmpty()
                .WithMessage(x => _localizer["Required"]);

            RuleFor(x => x.CityId)
                .NotEmpty()
                .WithMessage(x => _localizer["Required"]);
        }
    }
}
