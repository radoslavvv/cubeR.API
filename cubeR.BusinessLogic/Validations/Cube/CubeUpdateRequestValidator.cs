using cubeR.DataAccess.DTOs.Cube;
using cubeR.DataAccess.Enums;
using FluentValidation;

namespace cubeR.BusinessLogic.Validations.Cube;
public class CubeUpdateRequestValidator : AbstractValidator<CubeUpdateRequestDTO>
{
    public CubeUpdateRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(250);

        RuleFor(x => x.SidesCount).NotEmpty();

        RuleFor(x => x.PiecesCount).NotEmpty();

        RuleFor(x => x.Weight).NotEmpty();

        RuleFor(x => x.DifficultyLevel).NotEmpty().Must(i => Enum.IsDefined(typeof(CubeDifficultyLevel), i)).WithMessage($"Difficulty must be one of the following options: {string.Join(", ", Enum.GetValues(typeof(CubeDifficultyLevel)).Cast<CubeDifficultyLevel>().ToList())}");

        RuleFor(x => x.ReleaseYear).NotEmpty();

        RuleFor(x => x.Material).NotEmpty();
    }
}
