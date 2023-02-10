using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.UserAggregate;
using Ceyehat.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ceyehat.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
        ConfigureUserRelationshipIdsTable(builder);
    }

    private void ConfigureUserRelationshipIdsTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(u => u.Relationships, rb =>
        {
            rb.ToTable("UserRelationships");

            rb.WithOwner().HasForeignKey("UserId");

            rb.HasKey("Id", "UserId");

            rb.Property(r => r.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => RelationshipId.Create(value));
            
            rb.Property(r => r.Type)
                .HasConversion(
                    type => (int)type,
                    intValue => (RelationshipType)intValue);

            rb.Property(r => r.CustomerId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CustomerId.Create(value));
        });
        
        builder.Metadata.FindNavigation(nameof(User.Relationships))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    } 

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(u => u.FirstName)
            .HasMaxLength(128);

        builder.Property(u => u.LastName)
            .HasMaxLength(128);

        builder.Property(u => u.Email)
            .HasMaxLength(128);

        builder.Property(u => u.Password)
            .HasMaxLength(64);

        builder.Property(u => u.CustomerId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CustomerId.Create(value));
        
        builder.Navigation(u => u.Relationships)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}