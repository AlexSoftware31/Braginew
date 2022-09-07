using Bragi.DataLayer.Constants;
using Bragi.DataLayer.ViewModels.Customs;
using FluentValidation;

namespace Bragi.DataLayer.Validators.Customs
{
    public class CustomsInformationWiewModelValidatorNoMsg:AbstractValidator<CustomsInformationWiewModel>
    {
        public CustomsInformationWiewModelValidatorNoMsg()
        {
            When(x => x.ExceedsMoneyLimit, () =>
            {
                RuleFor(x => x.Ammount)
                    .NotEmpty()
                    .GreaterThan(0);

                RuleFor(x => x.CurrencyId)
                    .NotNull();

                RuleFor(x => x.DeclaredOriginValue)
                    .NotEmpty();
            });

            When(x => x.ExceedsMoneyLimit && !x.IsValuesOwner, () =>
            {
                RuleFor(x => x.SenderName)
                    .NotEmpty()
                    .Matches(RegexConstants.Names);

                RuleFor(x => x.SenderLastName)
                    .NotEmpty()
                    .Matches(RegexConstants.Names);

                RuleFor(x => x.ReceiverName)
                    .NotEmpty()
                    .Matches(RegexConstants.Names);

                RuleFor(x => x.ReceiverLastName)
                    .NotEmpty()
                    .Matches(RegexConstants.Names);

                RuleFor(x => x.RelationShip)
                    .NotEmpty()
                    .Matches(RegexConstants.Names);

                RuleFor(x => x.WorthDestiny)
                    .NotEmpty()
                    .Matches(RegexConstants.Names);
            });

        }
    }
}