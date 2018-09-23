using System;
using System.Linq;
using Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entities;

namespace Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Event> Events { get; set; }
		public DbSet<User> Users { get; set; }
		
		public ApplicationDbContext(DbContextOptions options) : base(options) {}

		public override int SaveChanges()
		{
			AddTimestamps();
			return base.SaveChanges();
		}
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new EventMapping());
			modelBuilder.ApplyConfiguration(new UserMapping());
		}

		private void AddTimestamps()
		{
			var entities = ChangeTracker.Entries()
				.Where(e => e.Entity is IEntityBase && (e.State == EntityState.Added || e.State == EntityState.Modified));

			foreach (var entity in entities)
			{
				if (entity.State == EntityState.Added)
					((IEntityBase)entity.Entity).CreatedAt = DateTime.Now;
				else
					((IEntityBase)entity.Entity).UpdatedAt = DateTime.Now;
			}
		}
	}
}