using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.DTOs.Categories;
using ProniaOnion.Application.Abstractions.DTOs.Products;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Presistence.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Presistence.Implementations.Services
{
	internal class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _repository;
		private readonly IMapper _mapper;
		public CategoryService(ICategoryRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task CreateAsync(CreateCategoryDto categoryDto)
		{
			if (await _repository.AnyAsync(c => c.Name == categoryDto.Name)) throw new Exception("Not Found");
			var category = _mapper.Map<Category>(categoryDto);
			await _repository.AddAsync(category);
			await _repository.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			Category category = await _repository.GetByIdAsync(id);
			if (category == null) throw new Exception("Not Found");
			_repository.Delete(category);
			await _repository.SaveChangesAsync();
		}

		public async Task<IEnumerable<CategoryItemDto>> GetAllAsync(int page, int take)
		{
			IEnumerable<Category> categories = await _repository
			   .GetAll(skip: (page - 1) * take, take: take)
			   .ToListAsync();
			return _mapper.Map<IEnumerable<CategoryItemDto>>(categories);
		}

		public async Task<GetCategoryDto> GetByIdAsync(int id)
		{
			Category category = await _repository.GetByIdAsync(id, nameof(Category.Products));
			if (category == null) throw new Exception("Not Found");
			//ICollection<ProductItemDto> productItems = category.Products.Select(p => new ProductItemDto(p.Id, p.Price, p.Name, p.SKU, p.Description)).ToList();
			//GetCategoryDto categoryDto = new(category.Id, category.Name, productItems);
			GetCategoryDto categoryDto = _mapper.Map<GetCategoryDto>(category);
			return categoryDto;
		}

		public async Task UpdateAsync(int id, UpdateCategoryDto categoryDto)
		{
			Category category = await _repository.GetByIdAsync(id);
			if (category == null) throw new Exception("Not Found");
			if (await _repository.AnyAsync(c => c.Name == categoryDto.Name && c.Id != id)) throw new Exception("Already exists");
			category = _mapper.Map(categoryDto, category);
			category.LastUpdatedAt = DateTime.Now;
			_repository.Update(category);
			await _repository.SaveChangesAsync();
		}
	}
}
