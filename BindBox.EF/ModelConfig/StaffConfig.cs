using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace BindBox.Models.ModelConfig
{
    public class StaffConfig : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("staff", schema: "ro");
            builder.HasKey(x => x.StaffId);
            builder.Property(x => x.StaffName).HasMaxLength(20);
            builder.Property(x => x.StaffWages).HasColumnType("money");
            builder.Property(x => x.StaffGender).HasColumnType("char").HasMaxLength(2);
            builder.Property(x => x.StaffPhone).HasMaxLength(11);
            builder.Property(x => x.StaffCode).HasMaxLength(18);
            builder.Property(x => x.StaffEntryTime).HasColumnType("date").HasDefaultValueSql("getdate()");
            builder.Property(x => x.StaffPosition).HasMaxLength(20);
            builder.Property(x => x.StaffState).HasMaxLength(20);
            builder.Property(x => x.Image).HasMaxLength(200);
            builder.Property(x => x.Province).HasMaxLength(20);
            builder.Property(x => x.City).HasMaxLength(20);
            builder.Property(x => x.Area).HasMaxLength(20);
            builder.Property(x => x.Details).HasMaxLength(200);
            builder.HasQueryFilter(x => x.IsDelete == false);
        }
    }
}
