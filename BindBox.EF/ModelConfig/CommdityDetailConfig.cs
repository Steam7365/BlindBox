using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace BindBox.Models.ModelConfig
{
    public class CommdityDetailConfig : IEntityTypeConfiguration<CommdityDetail>
    {
        public void Configure(EntityTypeBuilder<CommdityDetail> builder)
        {
            builder.ToTable("box_commodity_detail", schema: "ro");
            builder.HasKey(x => x.CommdityDetailId);
            builder.Property(x => x.ComminfoName).HasMaxLength(20);
            builder.Property(x => x.ComminfoSpec).HasMaxLength(10);
            builder.Property(x => x.ComminfoPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.OfficiaPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.ComminfoImg).HasMaxLength(200);
            builder.HasOne<Grade>(x => x.Grade).WithMany(x => x.CommdityDetails);
            builder.HasMany<BoxCommodity>(x=>x.BoxCommodities).WithMany(x => x.CommdityDetails).UsingEntity(x=>x.ToTable("box_connect",schema:"ro"));
            builder.HasQueryFilter(x => x.IsDelete == false);
            //不配置到数据库的字段
            builder.Ignore(x => x.FKGradeId);
        }
    }
}
