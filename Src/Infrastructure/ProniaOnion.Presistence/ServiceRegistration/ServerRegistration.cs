using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Presistence.Contexts;
using ProniaOnion.Presistence.Implementations.Repositories;
using ProniaOnion.Presistence.Implementations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Presistence.ServerRegistration
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>
				(opt => opt.UseSqlServer(configuration.GetConnectionString("default")));

			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IColorRepository, ColorRepository>();

			services.AddScoped<ICategoryService, CategoryService>();

			return services;
		}
	}
}
