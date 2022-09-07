using AutoMapper;
using Bragi.BussinessLayer.Interfaces.PublicHealths;
using Bragi.DataLayer.Validators.PublicHealth;
using Bragi.DataLayer.ViewModels.PublicHealths;
using System;

namespace Bragi.BussinessLayer.Services.PublicHealths
{
    public class PublicHealthValidatorService: IPublicHealthValidatorService
    {
        private readonly IMapper _mapper;

        public PublicHealthValidatorService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool IsPublicHealthViewModelValid(PublicHealthViewModel publicHealthViewModel)
        {
            try
            {
                var validator = new PublicHealthValidator();
                var validatorResult = validator.Validate(publicHealthViewModel);
                return validatorResult.IsValid;
            }
            catch 
            {

                return false;
            }
        }
    }
}