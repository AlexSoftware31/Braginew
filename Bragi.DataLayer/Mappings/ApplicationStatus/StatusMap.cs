using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bragi.DataLayer.Models.ApplicationStatus;
using Bragi.DataLayer.ViewModels.ApplicationStatus;

namespace Bragi.DataLayer.Mappings.ApplicationStatus
{
    public class StatusMap: Profile
    {
        public StatusMap()
        {
            CreateMap<Status, StatusViewModel>();
        }
    }
}
