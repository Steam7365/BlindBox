using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace BindBox.Models.ModelConfig
{
    public class UserInfoConfig : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("userinfo", schema: "ao");
            builder.HasKey(x => x.UserInfoId);
            builder.Property(x => x.UserName).HasMaxLength(20);
            builder.Property(x => x.UserGender).HasMaxLength(2).HasColumnType("char");
            builder.Property(x => x.UserNumber).HasMaxLength(20);
            builder.Property(x => x.UserPwd).HasMaxLength(20);
            builder.Property(x => x.UserPhone).HasMaxLength(11);
            builder.Property(x => x.HeadPortrait).HasMaxLength(200);
        }
    }
}
