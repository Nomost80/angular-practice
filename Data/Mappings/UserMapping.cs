using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Data.Mappings
{
	public class UserMapping : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("users");
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).UseMySqlIdentityColumn();
			builder.Property(p => p.CreatedAt).IsRequired();
			builder.Property(p => p.UpdatedAt);
			builder.Property(p => p.FirstName).IsRequired();
			builder.Property(p => p.LastName).IsRequired();
			builder.HasIndex(p => p.Email).IsUnique();
			builder.Property(p => p.Email).IsRequired();
			builder.Property(p => p.Password).IsRequired();
			builder.Property(p => p.SchoolGroup).IsRequired();
			builder.HasIndex(p => p.Avatar).IsUnique();
			builder.Property(p => p.Avatar);
			builder.Property(p => p.EmailAlert).HasDefaultValue(true);
		}
	}
}