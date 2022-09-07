using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bragi.DataLayer.Models.ETickets;
using Bragi.DataLayer.ViewModels.ETickets;

namespace Bragi.DataLayer.Mappings.Etickets
{
    public class EticketMap : Profile
    {
        public EticketMap()
        {
            CreateMap<Eticket, EticketViewModel>();
        }
    }
}
