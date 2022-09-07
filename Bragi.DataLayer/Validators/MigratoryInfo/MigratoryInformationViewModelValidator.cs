using Bragi.DataLayer.Constants;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace Bragi.DataLayer.Validators.MigratoryInfo
{
    public class MigratoryInformationViewModelValidator : AbstractValidator<MigratoryInformationViewModel>
    {
        private readonly IStringLocalizer<Bragi.DataLayer.SharedResource> _localizer;
        public MigratoryInformationViewModelValidator(IStringLocalizer<Bragi.DataLayer.SharedResource> localizer)
        {
            _localizer = localizer;
            RuleFor(x => x.Names)
                .NotEmpty()
                .WithMessage(x => _localizer["Required"])
                .Length(1, 140)
                .Matches(RegexConstants.Names).WithMessage(_localizer["Val.NoSpecial"]);


            RuleFor(x => x.LastNames).NotEmpty()
                .WithMessage(x => _localizer["Required"])
                .Matches(RegexConstants.Names).WithMessage(_localizer["Val.NoSpecial"]);

            RuleFor(x => x.Nationality).NotEmpty().WithMessage(_localizer["Required"]).MaximumLength(3);
            RuleFor(x => x.BirthPlace).NotEmpty().WithMessage(_localizer["Required"]).MaximumLength(3);

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage(_localizer["Required"])
                .LessThanOrEqualTo(x => DateTime.Now)
                .WithMessage(x => _localizer["MI.Val.BirthDate"]);

            RuleFor(x => x.PassportNumber).NotNull()
                .WithMessage(x => _localizer["Required"])
                .Matches(RegexConstants.Passport).WithMessage(x => _localizer["Val.NoSpecial"])
                .Length(5, 11)
                .WithMessage(x => _localizer["MI.Val.Passport"]);

            RuleFor(x => x.PassportConfirmation).NotNull()
                .WithMessage(x => _localizer["Required"])
                .Matches(RegexConstants.Passport).WithMessage(x => _localizer["Val.NoSpecial"])
                .Length(5, 11)
                .WithMessage(x => _localizer["MI.Val.Passport"])
                .Equal(x => x.PassportNumber).WithMessage(_localizer["IsNotEquals"]);

            RuleFor(x => x.OcupationId)
                .NotEmpty()
                .WithMessage(x => _localizer["Required"]);

            RuleFor(x => x.MaritalStatusId)
                .NotEmpty()
                .WithMessage(x => _localizer["Required"]);

            RuleFor(x => x.ResidenceNumber)
                .NotEmpty().When(x => x.IsResident)
                .WithMessage(x => _localizer["Required"])
                .MaximumLength(12)
                .WithMessage(x => _localizer["Mig.Val.MaxDocument"]);

            RuleFor(x => x.HotelId)
                .NotEmpty()
            .When(x => x.WillStayAtResort && (x.IsPrincipal || !x.IsPrincipal && !x.HasCommonHotel))
            .WithMessage(x => _localizer["Required"]);

            RuleFor(x => x.GeoCode)
            .NotEmpty()
            .Unless(x => x.WillStayAtResort || x.HasCommonAddress)
            .WithMessage(x => _localizer["Required"]);

            RuleFor(x => x.Street)
                .NotEmpty().Unless(x => x.WillStayAtResort || (!x.IsPrincipal && x.HasCommonAddress))
                .WithMessage(x => _localizer["Required"])
                .MaximumLength(250);

            RuleFor(x => x.FlightMotiveId)
            .NotEmpty()
            .WithMessage(x => _localizer["Required"]);

            RuleFor(x => x.EmbarkationPortNavId)
            .NotEmpty().When(x => x.IsPrincipal)
            .WithMessage(x => _localizer["Required"]);

            RuleFor(x => x.DisembarkationPortNavId)
           .NotEmpty().When(x => x.IsPrincipal)
           .WithMessage(x => _localizer["Required"]);

            RuleFor(x => x.OriginPortNavId)
           .NotEmpty().When(x => x.IsArrival && x.StopOverInCountries && x.IsPrincipal)
           .WithMessage(x => _localizer["Required"]);
            
            RuleFor(x => x.OriginFlightNumber)
                .NotEmpty().When(x => x.IsArrival && x.StopOverInCountries && x.IsPrincipal)
                .WithMessage(x => _localizer["Required"])
                .MaximumLength(10);

            RuleFor(x => x.OriginFlightDate)
                .NotNull().When(x => x.IsArrival && x.StopOverInCountries && x.IsPrincipal)
                .WithMessage(_localizer["Required"]);

            RuleFor(x => x.EmbarcationFlightNumber)
                .NotEmpty().When(x => x.IsPrincipal)
                .WithMessage(x => _localizer["Required"])
                .MaximumLength(10);

            RuleFor(x => x.DisembarkationPort)
                .NotEmpty()
                .WithMessage(x => _localizer["Required"])
                .When(x => x.DisembarkationPortNavId == 0);

            RuleFor(x => x.EmbarkationPort)
                .NotEmpty()
                .WithMessage(x => _localizer["Required"])
                .When(x => x.EmbarkationPortNavId == 0);

            RuleFor(x => x.ConfirmationNumber)
                .Matches(RegexConstants.Passport).WithMessage(_localizer["Val.NoSpecial"])
                .MaximumLength(6).WithMessage($"{_localizer["Val.MaxLengthExceeded"]} (6)");

            RuleFor(x => x.Email)
                .MaximumLength(35)
                .WithMessage(x => _localizer["isInvalid"]);

            RuleFor(x => x.DaysOfStaying)
                .NotNull()
                .WithMessage(x => _localizer["Required"])
                .When(x => x.Nationality != "DOM" || !x.IsResident)
                .InclusiveBetween(1, 120)
                .WithMessage(x => _localizer["MaxDays"]);

            RuleFor(x => x.DocumentIdNumber)
                .Matches(RegexConstants.Cedula)
                .WithMessage(_localizer["Val.IncorrectIdFormat"]);

            RuleFor(x => x.Gender)
                .NotEmpty()
                .WithMessage(_localizer["Required"]);

            RuleFor(x => x.AirlineId)
                .NotEmpty().When(x => x.IsPrincipal)
                .WithMessage(_localizer["Required"]);

            RuleFor(x => x.EmbarcationDate)
                .NotNull().When(x => x.IsPrincipal)
                .WithMessage(_localizer["Required"]);
        }
    }
}
