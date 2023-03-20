using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySelfieApp.Context.Models;

namespace MySelfieApp.Context.Config.Entities
{
    public class ProfileConfiguration : EntityMappingConfiguration<Profile>
    {
        public override void Map(EntityTypeBuilder<Profile> entity)
        {
            //Guard.Against.Null(entity, nameof(entity));

            entity.HasKey(e => e.Id)
            .IsClustered(false);

            entity.ToTable("BillOfLadingBundle", "blout");

            entity.Property(e => e.Name)
                .HasMaxLength(100);
        }
    }
}
