using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BindBox.Models.Model.ModelConfig
{
    public class DescribeTypeConfig : IEntityTypeConfiguration<DescribeType>
    {
        public void Configure(EntityTypeBuilder<DescribeType> builder)
        {
            builder.ToTable("describetype", schema: "ro");
            builder.HasKey(x => x.DescribeTypeId);
            builder.Property(x => x.DescTitle).HasMaxLength(200);
            builder.Property(x => x.DescContent).HasMaxLength(200);

            builder.HasOne<CommdityDetail>(x => x.CommdityDetails).WithMany(x=>x.DescribeTypes);
        }
    }
}
