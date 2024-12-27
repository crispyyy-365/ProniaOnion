using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Presistence.Contexts
{
	internal class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Color> Colors { get; set; }
		public DbSet<ProductColor> ProductColors { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Product>()
				.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(100);
			modelBuilder
				.Entity<Product>()
				.Property(x => x.Price)
				.IsRequired()
				.HasColumnType("decimal(6,2)");
			base.OnModelCreating(modelBuilder);
		}
	}
}
