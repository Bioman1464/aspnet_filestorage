using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OOPASU.Api.Data
{
    public class TodoEntityTypeConfiguration: IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder
                .Property(item => item.Id)
                .IsRequired();
        }
    }
}