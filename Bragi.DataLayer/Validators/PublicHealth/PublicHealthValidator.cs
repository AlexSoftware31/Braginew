using Bragi.DataLayer.Constants;
using Bragi.DataLayer.Utils;
using FluentValidation;
using System;
using System.Linq;
using Bragi.DataLayer.ViewModels.PublicHealths;

namespace Bragi.DataLayer.Validators.PublicHealth
{
    public class PublicHealthValidator : AbstractValidator<PublicHealthViewModel>
    {
        public PublicHealthValidator()
        {
            RuleFor(x => x.QuestionResponse)
                .NotEmpty()
                .Must(x => x.Any(q => q.BoolResponse));

            When(x => x.QuestionResponse.Any(q => !q.QuestionId.Equals(6) && q.BoolResponse), () =>
            {
                RuleFor(x => x.SymptomsDate)
                    .NotEmpty()
                    .LessThan(DateTime.Now);
            });

            When(x => x.MigratoryInformation.BirthDate.GetAge() >= 18, () =>
            {
                RuleFor(x => x.PhoneNumber)
                    .MaximumLength(15)
                    .NotEmpty();
                // .Matches(RegexConstants.PhoneNumber);
            });

            RuleFor(x => x.SpecificSymptoms)
                .Matches(RegexConstants.Names);

        }
    }
}