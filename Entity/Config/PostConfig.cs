using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Config
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.RateCount).HasDefaultValue(1);
            builder.Property(x => x.TotalRate).HasDefaultValue(1);
        }
    }
}