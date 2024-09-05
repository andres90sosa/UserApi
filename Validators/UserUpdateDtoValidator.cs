using FluentValidation;
using UserApi.DTOs;

namespace UserApi.Validators
{
    public class UserUpdateDtoValidator: AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("El email no es válido.");
        }
    }
}
