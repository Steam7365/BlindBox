using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace BindBox.Models.ModelConfig
{
    public class BoxFolderConfig : IEntityTypeConfiguration<BoxFolder>
    {
        public void Configure(EntityTypeBuilder<BoxFolder> builder)
        {
            builder.ToTable("box_folder", schema: "ro");
            builder.HasKey(x => x.BoxFolderId);
            builder.Property(x => x.BoxFolderName).HasMaxLength(20);
        }
    }
}
