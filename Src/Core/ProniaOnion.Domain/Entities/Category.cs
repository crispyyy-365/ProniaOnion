﻿using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
	public class Category : BaseNameableEntity
	{
		//relational props
		public ICollection<Product> Products { get; set; }
	}
}
