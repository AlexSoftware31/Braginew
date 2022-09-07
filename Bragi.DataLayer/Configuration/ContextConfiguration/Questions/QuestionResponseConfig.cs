using Bragi.DataLayer.Models.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Questions
{
    public class QuestionResponseConfig : IEntityTypeConfiguration<QuestionResponse>
    {
        public void Configure(EntityTypeBuilder<QuestionResponse> builder)
        {
            builder.Property(x => x.TextReponse).HasMaxLength(1000);
            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}