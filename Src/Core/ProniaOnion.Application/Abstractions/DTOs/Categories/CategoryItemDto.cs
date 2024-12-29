using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.DTOs.Categories
{
	public record CategoryItemDto(int Id, string Name);
	//public record CategoryItemDto
	//{
	//	public int Id { get; set; }
	//	public string Name { get; set; }
	//	public CategoryItemDto(int id, string name)
	//	{
	//		Id = id;
	//		Name = name;
	//	}
	//}
}
