using Bragi.DataLayer.Models.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Questions
{
    public class QuestionsConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasOne(x => x.Agency);
            builder.HasMany(x => x.QuestionResponse).WithOne(x => x.Question).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}