using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BindBox.Models.Model.ModelConfig
{
    public class CommdityDetailConfig : IEntityTypeConfiguration<CommdityDetail>
    {
        public void Configure(EntityTypeBuilder<CommdityDetail> builder)
        {
            builder.ToTable("box_commodity_detail", schema: "ro");
            builder.HasKey(x => x.CommdityDetailId);
            builder.Property(x => x.ComminfoName).HasMaxLength(20);
            builder.Property(x => x.ComminfoSpec).HasMaxLength(10);
            builder.Property(x => x.ComminfoPrice).HasColumnType("money");
            builder.Property(x => x.OfficiaPrice).HasColumnType("money");
            builder.Property(x => x.ComminfoImg).HasColumnType("Image");
            builder.HasOne<Grade>(x => x.Grade).WithMany(x => x.CommdityDetails);
            builder.HasMany<BoxCommodity>(x=>x.BoxCommodities).WithMany(x => x.CommdityDetails).UsingEntity(x=>x.ToTable("box_connect",schema:"ro"));
        }
    }
}
