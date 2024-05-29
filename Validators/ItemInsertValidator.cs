using backendP.DTOs;
using FluentValidation;

namespace backendP.Validators
{
    public class ItemInsertValidator:AbstractValidator<ItemInsertDto>
    {
        public ItemInsertValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe tener una longitud de 2 a 20 caracteres");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe tener una longitud de 2 a 20 caracteres");
            RuleFor(x => x.DepartmentID).GreaterThan(0).WithMessage("El Articulo deber tener un departamento asociado");

        }
    }
}
