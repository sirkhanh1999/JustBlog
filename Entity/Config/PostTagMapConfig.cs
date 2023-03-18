using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Config
{
    public class PostTagMapConfig : IEntityTypeConfiguration<PostTagMap>
    {
        public void Configure(EntityTypeBuilder<PostTagMap> builder)
        {
            builder.ToTable("PostTagMap");
            builder.HasKey(x => new { x.PostId, x.TagId });
            builder.Property(x => x.PostId).IsRequired();
            builder.Property(x => x.TagId).IsRequired();
            builder.HasOne(x => x.Post).WithMany(x => x.PostTagMaps).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.Tag).WithMany(x => x.PostTagMaps).HasForeignKey(x => x.TagId);
        }
    }
}