using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Data.Mappings
{
	public class EventMapping : IEntityTypeConfiguration<Event>
	{
		public void Configure(EntityTypeBuilder<Event> builder)
		{
			builder.ToTable("events");
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id).UseMySqlIdentityColumn();
			builder.Property(p => p.CreatedAt).IsRequired();
			builder.Property(p => p.UpdatedAt);
			builder.Property(p => p.Title).IsRequired();
			builder.HasIndex(p => p.Slug).IsUnique();
			builder.Property(p => p.Slug).IsRequired();
			builder.Property(p => p.Description).IsRequired();
			builder.HasIndex(p => p.Image).IsUnique();
			builder.Property(p => p.Image);
			builder.Property(p => p.Price);
			builder.Property(p => p.Question);
			builder.Property(p => p.Address).IsRequired();
			builder.Property(p => p.Postcode).IsRequired();
			builder.Property(p => p.City).IsRequired();
			builder.Property(p => p.Country).IsRequired();
			builder.Property(p => p.VoteDeadline);
			builder.Property(p => p.EnrollmentDeadline);
			builder.Property(p => p.Date);
			builder.Property(p => p.ValidatedAt);

			builder.HasOne(p => p.Author).WithMany(p => p.EventsCreated).IsRequired();
		}
	}
}