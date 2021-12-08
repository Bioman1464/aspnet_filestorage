using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OOPASU.Api.Data
{
    public class LessonEntityTypeConfiguration: IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("timezone('utc', now())");
        }
    }
}