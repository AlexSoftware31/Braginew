using Bragi.DataLayer.Constants;
using Bragi.DataLayer.ViewModels.Customs;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Bragi.DataLayer.Validators.Customs
{
    public class CustomsInformationWiewModelValidator : AbstractValidator<CustomsInformationWiewModel>
    {
        private readonly IStringLocalizer<SharedResource> _localizer;
        public CustomsInformationWiewModelValidator(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
            
            //RuleFor(x => x.Ammount)
            //    .NotEmpty().WithMessage(_localizer["Required"]);

            //RuleFor(x => x.CurrencyId)
            //    .NotNull().WithMessage(_localizer["Required"]);

            //RuleFor(x => x.DeclaredOriginValue)
            //    .NotEmpty().WithMessage(_localizer["Required"]);

            //RuleFor(x => x.SenderName)
            //    .NotEmpty().WithMessage(_localizer["Required"])
            //    .Matches(RegexConstants.Names).WithMessage(_localizer["Val.NoSpecial"]);

            //RuleFor(x => x.SenderLastName)
            //    .NotEmpty().WithMessage(_localizer["Required"])
            //    .Matches(RegexConstants.Names).WithMessage(_localizer["Val.NoSpecial"]);

            //RuleFor(x => x.ReceiverName)
            //    .NotEmpty().WithMessage(_localizer["Required"])
            //    .Matches(RegexConstants.Names).WithMessage(_localizer["Val.NoSpecial"]);

            //RuleFor(x => x.ReceiverLastName)
            //    .NotEmpty().WithMessage(_localizer["Required"])
            //    .Matches(RegexConstants.Names).WithMessage(_localizer["Val.NoSpecial"]);

            //RuleFor(x => x.RelationShip)
            //    .NotEmpty().WithMessage(_localizer["Required"])
            //    .Matches(RegexConstants.Names).WithMessage(_localizer["Val.NoSpecial"]);

            //RuleFor(x => x.WorthDestiny)
            //    .NotEmpty().WithMessage(_localizer["Required"])
            //    .Matches(RegexConstants.Names).WithMessage(_localizer["Val.NoSpecial"]);

            //RuleFor(x => x.ValueOfMerchandise)
            //    .NotEmpty().WithMessage(_localizer["Required"]);

            //RuleFor(x => x.CurrencyMerchandiseId)
            //    .NotNull().WithMessage(_localizer["Required"]);

            //RuleFor(x => x.DeclaredMerchs)
            //    .NotNull().WithMessage(_localizer["Required"]);

        }
    }
}