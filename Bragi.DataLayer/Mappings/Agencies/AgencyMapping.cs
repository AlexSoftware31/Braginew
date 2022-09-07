using AutoMapper;
using Bragi.DataLayer.Models.Agencies;
using Bragi.DataLayer.ViewModels.Agencys;

namespace Bragi.DataLayer.Mappings.Agencies
{
    public class AgencyMapping:Profile 
    {
        public AgencyMapping()
        {
            CreateMap<Agency, AgencyViewModel>();
        }
    }
}