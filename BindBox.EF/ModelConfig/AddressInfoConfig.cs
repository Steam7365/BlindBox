using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BindBox.Models.ModelConfig
{
    public class AddressInfoConfig : IEntityTypeConfiguration<AddressInfo>
    {
        public void Configure(EntityTypeBuilder<AddressInfo> builder)
        {
            builder.ToTable("addressinfo", schema: "ao");
            builder.HasKey(x => x.AddressInfoId);
            builder.Property(x => x.Province).HasMaxLength(20);
            builder.Property(x => x.City).HasMaxLength(20);
            builder.Property(x => x.Area).HasMaxLength(20);
            builder.Property(x => x.AddressDetails).HasMaxLength(200);
            builder.Property(x => x.Name).HasMaxLength(21);
            builder.Property(x => x.Phone).HasMaxLength(11);
            builder.Property(x => x.Phone2).HasMaxLength(11);
            builder.HasOne<UserInfo>(x => x.UserInfo).WithMany(x => x.AddressInfos);
        }
    }
}
