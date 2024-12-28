using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Presistence.Configurations
{
	internal class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
	{
		public void Configure(EntityTypeBuilder<ProductColor> builder)
		{
			builder.HasKey(x => new { x.ProductId, x.ColorId });
		}
	}
}
