using BookStore.Application.DTOs;
using FluentValidation;

namespace BookStore.Application.Validators
{
    public class CreateBookDtoValidation : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidation()
        {
            RuleFor(x => x.Title)
           .NotEmpty().WithMessage("عنوان کتاب نمی‌تواند خالی باشد")
           .MinimumLength(3).WithMessage("عنوان کتاب باید حداقل ۳ کاراکتر باشد")
           .MaximumLength(100).WithMessage("عنوان کتاب نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("نام نویسنده نمی‌تواند خالی باشد")
                .MinimumLength(3).WithMessage("نام نویسنده باید حداقل ۳ کاراکتر باشد")
                .MaximumLength(100).WithMessage("نام نویسنده نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("ISBN اجباری است.")
                .Matches(@"^\d{10}(\d{3})?$").WithMessage("باید 10 یا 13 رقم باشد.");

            RuleFor(x => x.Description)
                .MaximumLength(300).WithMessage("حداکثر طول توضیحات ۳۰۰ کاراکتر است")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("قیمت باید بزرگ‌تر از صفر باشد");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("موجودی نمی‌تواند منفی باشد");
        }
    }
}
