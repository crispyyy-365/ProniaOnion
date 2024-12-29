using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Presistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Presistence.Implementations.Repositories
{
	internal class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		public CategoryRepository(AppDbContext context) : base(context) { }
	}
}
