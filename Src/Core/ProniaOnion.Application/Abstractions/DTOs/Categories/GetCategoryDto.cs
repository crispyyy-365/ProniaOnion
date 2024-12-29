using ProniaOnion.Application.Abstractions.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.DTOs.Categories
{
	public record GetCategoryDto(int Id, string Name, ICollection<ProductItemDto> Products);
}
