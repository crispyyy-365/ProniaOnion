using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
	public class ProductColor
	{
		//relational props
		public int ProductId { get; set; }
		public int ColorId { get; set; }
		public Color Color { get; set; }
		public Product Product { get; set; }
	}
}
