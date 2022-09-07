using Bragi.DataLayer.Constants;
using Bragi.DataLayer.ViewModels.PublicHealths;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Bragi.DataLayer.Validators.PublicHealth
{
    public class PublicHealthViewModelValidator:AbstractValidator<PublicHealthViewModel>
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public PublicHealthViewModelValidator(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;

            RuleFor(x => x.SpecificSymptoms)
                .NotEmpty().WithMessage(_localizer["Required"])
                .Matches(RegexConstants.Names).WithMessage(_localizer["Val.NoSpecial"]);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage(_localizer["Required"])
                //.Matches(RegexConstants.PhoneNumber)
                .WithMessage(_localizer["Val.IncorrectPhoneNumber"]);

            RuleFor(x => x.SymptomsDate)
                .NotEmpty().WithMessage(_localizer["Required"]);
        }
    }
}