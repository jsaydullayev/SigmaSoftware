using FluentValidation;
using SigmaSoftware.Common.Models.CandidateModels;

namespace SigmaSoftware.Common.Validators.CandidateValidators;
public class CreateCandidatorValidator : AbstractValidator<AddCandidateModel>
{
    public CreateCandidatorValidator()
    {
        RuleFor(u => u.FirstName)
            .NotNull()
            .WithMessage("First name cannot be null.")
            .NotEmpty()
            .WithMessage("First name cannot be empty")
            .MaximumLength(50)
            .WithMessage("First name cannot be longer than 50 characters.");

        RuleFor(u => u.LastName)
            .NotNull()
            .WithMessage("Last name cannot be null.")
            .NotEmpty()
            .WithMessage("Last name cannot be empty")
            .MaximumLength(50)
            .WithMessage("Last name cannot be longer than 50 characters.");

        RuleFor(u => u.PhoneNumber)
            .NotNull()
            .WithMessage("Phone number cannot be null")
            .NotEmpty()
            .WithMessage("Phone number cannot be empty")
            .Matches("^998\\d{9}$")
            .WithMessage("Phone number in wrong format.");
    }
}
