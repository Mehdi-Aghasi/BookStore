using BookStore.Application.DTOs;
using FluentValidation;

namespace BookStore.Application.Validators
{
    public class UpdateBookDtoValidator:AbstractValidator<UpdateBookDto>
    {
         public UpdateBookDtoValidator()
        {

            RuleFor(x => x.Title)
                .MinimumLength(3).WithMessage("عنوان باید حداقل ۳ کاراکتر باشد.")
                .MaximumLength(100).WithMessage("عنوان نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد.")
                .When(x => !string.IsNullOrWhiteSpace(x.Title));

            RuleFor(x => x.Author)
                .MinimumLength(3).WithMessage("نام نویسنده باید حداقل ۳ کاراکتر باشد.")
                .MaximumLength(100).WithMessage("نام نویسنده نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد.")
                .When(x => !string.IsNullOrWhiteSpace(x.Author));

            RuleFor(x => x.ISBN)
                .Matches(@"^\d{10}(\d{3})?$").WithMessage("ISBN باید 10 یا 13 رقم باشد.")
                .When(x => !string.IsNullOrWhiteSpace(x.ISBN));

            RuleFor(x => x.Description)
                .MaximumLength(300).WithMessage("حداکثر طول توضیحات ۳۰۰ کاراکتر است.")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("قیمت باید بزرگ‌تر از صفر باشد.")
                .When(x => x.Price.HasValue);

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("موجودی نمی‌تواند منفی باشد.")
                .When(x => x.Stock.HasValue);
        }
    }
}
