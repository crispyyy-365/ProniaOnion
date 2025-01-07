using FluentValidation;
using ProniaOnion.Application.Abstractions.DTOs.Categories;
using ProniaOnion.Application.Abstractions.Repositories;

namespace ProniaOnion.Application.Validators
{
	internal class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
	{
		private readonly ICategoryRepository _repository;

		public CreateCategoryDtoValidator(ICategoryRepository repository)
		{
			_repository = repository;

			RuleFor(c => c.Name)
				.NotEmpty()
					.WithMessage("Data Required")
				.MinimumLength(3)
				.MaximumLength(100)
					.WithMessage("Characters should be less than 100")
				.Matches(@"^[A-Za-z\s0-9]*$")
				.MustAsync(CheckNameExistence);
		}
		public async Task<bool> CheckNameExistence(string name, CancellationToken token)
		{
			return !await _repository.AnyAsync(c => c.Name == name);
		}
	}
}
