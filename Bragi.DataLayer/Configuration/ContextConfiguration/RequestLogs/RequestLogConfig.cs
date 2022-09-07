using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.Models.RequestLogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.RequestLogs
{
    public class RequestLogConfig : IEntityTypeConfiguration<RequestLog>
    {
        public void Configure(EntityTypeBuilder<RequestLog> builder)
        {
            builder.Property(x => x.Method).HasMaxLength(15);
        }
    }
}
