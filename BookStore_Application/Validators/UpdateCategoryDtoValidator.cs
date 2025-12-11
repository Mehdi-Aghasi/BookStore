using BookStore.Application.DTOs;
using FluentValidation;

namespace BookStore.Application.Validators
{
    public partial class CreateCategoryValidator
    {
        public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
        {
            public UpdateCategoryDtoValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Category name must not be empty.")
                    .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");

                RuleFor(x => x.Slug)
                    .NotEmpty().WithMessage("Slug must not be empty.")
                    .MaximumLength(100).WithMessage("Slug must not exceed 100 characters.")
                    .Matches(@"^[a-zA-Z0-9_-]+$").WithMessage("Slug can only contain letters, numbers, hyphens, and underscores.");

                RuleFor(x => x.Description)
                    .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            }
        }
    }
}

