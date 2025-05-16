using IdeaManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdeaManager.Data.Configurations
{
    public class IdeaConfiguration : IEntityTypeConfiguration<Idea>
    {
        public void Configure(EntityTypeBuilder<Idea> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(i => i.Description)
                   .HasMaxLength(500);

            builder.HasMany(i => i.Votes)
                   .WithOne(v => v.Idea)
                   .HasForeignKey(v => v.IdeaId);
        }
    }
}
