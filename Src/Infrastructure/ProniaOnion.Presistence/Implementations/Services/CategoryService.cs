using ProniaOnion.Application.Abstractions.DTOs.Categories;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Presistence.Implementations.Services
{
	internal class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		public CategoryService(ICategoryRepository repository)
		{
			_categoryRepository = repository;
		}

		public async Task CreateAsync(CreateCategoryDto categoryDto)
		{
			if (await _categoryRepository.AnyAsync(c => c.Name == categoryDto.Name)) throw new Exception("Not Found");
			await _categoryRepository.AddAsync(new Category { Name = categoryDto.Name });
			await _categoryRepository.SaveChangesAsync();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<GetCategoryDto>> GetAllAsync(int page, int take)
		{
			IEnumerable<GetCategoryDto> categories = await _categoryRepository
			   .GetAll(skip: (page - 1) * take, take: take)
			   .Select(c => new GetCategoryDto(c.Id, c.Name)
			   .ToListAsync();
			return categories;
		}

		public Task<CategoryItemDto> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(int id, UpdateCategoryDto categoryDto)
		{
			throw new NotImplementedException();
		}
	}
}
