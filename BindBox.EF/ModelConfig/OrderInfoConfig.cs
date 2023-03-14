using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace BindBox.Models.ModelConfig
{
    public class OrderInfoConfig : IEntityTypeConfiguration<OrderInfo>
    {
        public void Configure(EntityTypeBuilder<OrderInfo> builder)
        {
            builder.ToTable("orderinfo", schema: "ao");
            builder.HasKey(x=>x.OrderInfoId);
            builder.HasIndex(x=>x.Order).IsUnique();
            builder.Property(x => x.OrderState).HasMaxLength(20);
            builder.Property(x => x.TotalPrice).HasColumnType("money");
            builder.Property(x => x.ActualPrice).HasColumnType("money");
            builder.Property(x => x.Freight).HasColumnType("money");
            builder.Property(x => x.Channel).HasMaxLength(10);
            builder.Property(x => x.CreateTime).HasColumnType("datetime");
            builder.Property(x => x.PaymentTime).HasColumnType("datetime");
            builder.Property(x => x.DeliverTime).HasColumnType("datetime");

            builder.HasOne(x => x.AddressInfo).WithMany();
            builder.HasOne(x => x.Draw).WithMany();
        }
    }
}
