using BookStore.Application.DTOs;
using FluentValidation;
using System.Data;

namespace BookStore.Application.Validators
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name is required")
             .MinimumLength(3).WithMessage("Name must be at least 3 characters")
             .MaximumLength(100).WithMessage("Name must be at most 100 characters");
            RuleFor(x => x.Bio)
             .MaximumLength(500).WithMessage("Bio must be at most 500 characters");
            RuleFor(x => x.Age)
              .GreaterThan(0).WithMessage("Age must be greater than 0")
              .LessThan(150).WithMessage("Age seems unrealistic");
        }
    }

    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorDto>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters")
            .MaximumLength(100).WithMessage("Name must be at most 100 characters")
            .When(x => x.Name != null);

            RuleFor(x => x.Bio)
              .MaximumLength(500).WithMessage("Bio must be at most 500 characters")
              .When(x => x.Bio != null);

            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Age must be greater than 0")
               .LessThan(150).WithMessage("Age seems unrealistic")
               .When(x => x.Age.HasValue);
        }
    }
}
