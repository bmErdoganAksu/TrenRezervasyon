using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration;

public class VagonConfiguration : BaseEntityConfiguration<Vagon>
{
    public override void Configure(EntityTypeBuilder<Vagon> builder)
    {
        builder.HasOne<Train>().WithMany().HasForeignKey(s => s.TrainId);
        base.Configure(builder);
    }
}