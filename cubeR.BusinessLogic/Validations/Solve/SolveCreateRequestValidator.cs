using cubeR.DataAccess.DTOs.Solve;
using cubeR.DataAccess.Enums;
using FluentValidation;
namespace cubeR.BusinessLogic.Validations.Solve;

public class SolveCreateRequestValidator : AbstractValidator<SolveCreateRequestDTO>
{
    public SolveCreateRequestValidator()
    {
        RuleFor(x => x.SolveType).Must(i => Enum.IsDefined(typeof(SolveType), i)).WithMessage($"Solve Type must be one of the following options: {string.Join(", ", Enum.GetValues(typeof(SolveType)).Cast<SolveType>().ToList())}");

        RuleFor(x => x.Scramble).NotEmpty().MinimumLength(1).MaximumLength(250);

        RuleFor(x => x.LoggedDate).NotEmpty();

        RuleFor(x => x.SolveTime).NotEmpty().Matches(@"^(\d+):([0-5]?\d):([0-5]?\d).(\d{1,3})$").WithMessage("Solve Time must be in the following format: hh:mm:ss.SSS");
    }
}
