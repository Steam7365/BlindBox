using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace BindBox.Models.ModelConfig
{
    public class BoxCommodityConfig : IEntityTypeConfiguration<BoxCommodity>
    {
        public void Configure(EntityTypeBuilder<BoxCommodity> builder)
        {
            builder.ToTable("box_commodity", schema: "ro");
            builder.HasKey(x=>x.BoxCommodityId);
            builder.Property(x => x.CommodityName).HasMaxLength(20);
            builder.Property(x => x.CoverPhoto).HasMaxLength(200);
            builder.Property(x => x.Desc).HasMaxLength(400);
            builder.Property(x => x.Price).HasColumnType("money");
            builder.HasOne<BoxFolder>(x => x.BoxFolder).WithMany(x=>x.BoxCommodities);
        }
    }
}
