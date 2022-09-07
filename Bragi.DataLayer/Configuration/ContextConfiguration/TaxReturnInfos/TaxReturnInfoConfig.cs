using Bragi.DataLayer.Models.TaxReturnInfos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.TaxReturnInfos
{
    public class TaxReturnInfoConfig : IEntityTypeConfiguration<TaxReturnInfo>
    {
        public void Configure(EntityTypeBuilder<TaxReturnInfo> builder)
        {
            builder.Property(x => x.Cedula).HasMaxLength(11);
            builder.Property(x => x.Telefono).HasMaxLength(10);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
