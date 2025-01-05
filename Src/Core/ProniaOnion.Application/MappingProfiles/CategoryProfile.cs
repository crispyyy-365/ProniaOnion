﻿using AutoMapper;
using ProniaOnion.Application.Abstractions.DTOs.Categories;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.MappingProfiles
{
	internal class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, CategoryItemDto>();
			CreateMap<Category, GetCategoryDto>().ReverseMap();
			CreateMap<CreateCategoryDto, Category>();
			CreateMap<UpdateCategoryDto, Category>().ForMember(c => c.Id, opt => opt.Ignore());
		}
	}
}
