

using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;
    public class RegisterRequestValidators : AbstractValidator<RegisterRequest>
    {
    public RegisterRequestValidators()
    {
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email Is A required")
            .EmailAddress().WithMessage("Invalid Email Formate");
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is Required");
        RuleFor(temp => temp.PersonName).NotEmpty().WithMessage("PersonName  is Required and should not be empty");
        RuleFor(temp => temp.Gender).IsInEnum().WithMessage("Gender is Invalid");
    }
    }

