

namespace Clean.Architecture.Infrastructure.Data.Config;
public class RewardDefinitionConfiguration : IEntityTypeConfiguration<RewardDefinition>
{
    public void Configure(EntityTypeBuilder<RewardDefinition> builder)
    {
        builder.HasOne(builder => builder.RewardType).WithMany().IsRequired();
        builder.HasOne(r => r.RewardChainDefinition);
    }
}