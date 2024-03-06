using cubeR.DataAccess.DTOs.Cube;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace cubeR.BusinessLogic.Validations.Cube;

public class CubeCreateRequestValidator : AbstractValidator<CubeCreateRequestDTO>
{
    public CubeCreateRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(250);
        RuleFor(x => x.SidesCount).NotEmpty();
        RuleFor(x => x.PiecesCount).NotEmpty();
    }
}