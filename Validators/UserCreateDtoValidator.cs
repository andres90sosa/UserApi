using FluentValidation;
using UserApi.DTOs;

namespace UserApi.Validators
{
    public class UserCreateDtoValidator: AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("El email no es válido.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña es obligatoria.");
        }
    }
}
