using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.Models.PublicHealths;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.PublicHealths
{
    public class PublicHealthConfig : IEntityTypeConfiguration<PublicHealth>
    {
        public void Configure(EntityTypeBuilder<PublicHealth> builder)
        {
            builder.Property(x => x.SpecificSymptoms).HasMaxLength(400);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
            builder.HasOne(x => x.Application).WithMany(x => x.PublicHealths).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.MigratoryInformation).WithOne(x => x.PublicHealth).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.QuestionResponse).WithOne(x=> x.PublicHealth).OnDelete(DeleteBehavior.NoAction);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
