using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Presistence.Contexts;
using ProniaOnion.Presistence.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Presistence.Implementations.Repositories
{
	internal class ColorRepository : Repository<Color>, IColorRepository
	{
		public ColorRepository(AppDbContext context) : base(context) { }
	}
}
