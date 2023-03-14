using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace BindBox.Models.ModelConfig
{
    public class LoginConfig : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("login", schema: "ro");
            builder.HasKey(x => x.LoginId);
            builder.Property(x => x.LoginName).HasMaxLength(20);
            builder.Property(x => x.Password).HasMaxLength(20);

            builder.HasOne<Staff>(x => x.Staff).WithMany(x => x.Logins);
        }
    }
}
