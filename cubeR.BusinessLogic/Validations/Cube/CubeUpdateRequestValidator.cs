using cubeR.DataAccess.DTOs.Cube;
using FluentValidation;

namespace cubeR.BusinessLogic.Validations.Cube;
public class CubeUpdateRequestValidator : AbstractValidator<CubeUpdateRequestDTO>
{
    public CubeUpdateRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(250);
        RuleFor(x => x.SidesCount).NotEmpty();
        RuleFor(x => x.PiecesCount).NotEmpty();
    }
}
