using backendP.DTOs;
using FluentValidation;

namespace backendP.Validators
{
    public class ItemUpdateValidator:AbstractValidator<ItemUpdateDto>
    {
        public ItemUpdateValidator() {
            RuleFor(x => x.Name).NotNull().WithMessage("El Nombre no debe ser nullo");
            RuleFor(x => x.Name).NotEmpty().Length(2,10).WithMessage("El Nombre del producto es obligatorio y tiene que tener minimo 2 a 10 caracteres");
            RuleFor(x => x.Name).Length(2, 10).WithMessage("El Nombre tiene que tener minimo 2 a 10 caracteres");

        }
    }
}
