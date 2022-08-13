using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration;

public class TrainConfiguration : BaseEntityConfiguration<Train>
{
    public override void Configure(EntityTypeBuilder<Train> builder)
    {
        base.Configure(builder);
        builder.HasMany(x => x.Vagons).WithOne().HasForeignKey(s=>s.Id);
    }
}
