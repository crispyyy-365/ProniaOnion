using ProniaOnion.Application.Abstractions.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
	public interface ICategoryService
	{
		Task<IEnumerable<GetCategoryDto>> GetAllAsync(int page, int take);
		Task<CategoryItemDto> GetByIdAsync(int id);
		Task<bool> CreateAsync(CreateCategoryDto categoryDto);
		Task UpdateAsync(int id, UpdateCategoryDto categoryDto);
		Task DeleteAsync(int id);
	}
}
