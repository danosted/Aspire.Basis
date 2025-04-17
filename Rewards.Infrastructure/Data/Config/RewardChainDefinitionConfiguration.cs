

namespace Clean.Architecture.Infrastructure.Data.Config;
public class RewardChainDefinitionConfiguration : IEntityTypeConfiguration<RewardChainDefinition>
{
    public void Configure(EntityTypeBuilder<RewardChainDefinition> builder)
    {
        builder.HasOne(builder => builder.RewardDefinition).WithMany().IsRequired();
    }
}