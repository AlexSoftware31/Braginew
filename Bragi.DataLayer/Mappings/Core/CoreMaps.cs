using AutoMapper;
using NetCoreUtilities.Models;
using System;

namespace Bragi.DataLayer.Mappings.Core
{
    public class CoreMaps : Profile
    {
        public CoreMaps()
        {
            CreateMap<int?, int>().ConvertUsing(c => c.HasValue ? c.Value : 0);
            // CreateMap<int, int?>().ConvertUsing(c => c > 0 ? c : (int?) null);

            CreateMap<bool, int>().ConvertUsing(c => c ? 1 : 0);
            CreateMap<bool, int?>().ConvertUsing(c => c ? 1 : 0);

            CreateMap<long?, long>().ConvertUsing(c => c ?? 0L);

            CreateMap<float?, float>().ConvertUsing(c => c ?? 0.0F);

            CreateMap<double?, double>().ConvertUsing(c => c ?? 0.0);

            CreateMap<decimal?, decimal>().ConvertUsing(c => c ?? 0M);
            // CreateMap<decimal, decimal?>().ConvertUsing(c => c > 0 ? c : (decimal?) null);

            CreateMap<DateTime?, DateTime>().ConvertUsing(c => c ?? DateTime.MinValue);

            CreateMap<string, string>().ConvertUsing(c => !string.IsNullOrWhiteSpace(c) ? c.Trim() : c);

            CreateMap(typeof(DataCollection<>), typeof(DataCollection<>));
        }
    }
}