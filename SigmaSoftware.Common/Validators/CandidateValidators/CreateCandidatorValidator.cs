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

        RuleFor(u => u.Email)
            .NotNull()
            .WithMessage("Email cannot be null")
            .NotEmpty()
            .WithMessage("Email cannot be empty")
            .EmailAddress()
            .WithMessage("Email in wrong format.")
            .MaximumLength(100)
            .WithMessage("Email cannot be longer than 100 characters.");

        RuleFor(u => u.CallStartTime)
            .NotEmpty()
            .WithMessage("Call start time cannot be empty")
            .NotNull()
            .WithMessage("Call start time cannot be null")
            .Must(x => x.Hours >= 0 && x.Hours < 24)
            .WithMessage("Call start time must be in range from 0 to 23 hours")
            .Must(x => x.Minutes >= 0 && x.Minutes < 60)
            .WithMessage("Call start time must be in range from 0 to 59 minutes");

        RuleFor(u => u.CallEndTime)
            .NotEmpty()
            .WithMessage("Call end time cannot be empty")
            .NotNull()
            .WithMessage("Call end time cannot be null")
            .Must(x => x.Hours >= 0 && x.Hours < 24)
            .WithMessage("Call end time must be in range from 0 to 23 hours")
            .Must(x => x.Minutes >= 0 && x.Minutes < 60)
            .WithMessage("Call start time must be in range from 0 to 59 minutes")
            .GreaterThan(x => x.CallStartTime)
            .WithMessage("Call end time must be greater than call start time")
            .LessThan(x => x.CallStartTime.Add(new TimeSpan(1, 0, 0)))
            .WithMessage("Call end time must be less than call start time + 1 hour");

        RuleFor(u => u.LinkedInProfile)
            .NotEmpty()
            .WithMessage("LinkedIn profile cannot be empty")
            .NotNull()
            .WithMessage("LinkedIn profile cannot be null")
            .Matches(@"^(https?:\/\/)?(www\.)?(linkedin\.com\/)(in|pub|company)\/[a-zA-Z0-9\-]+\/?$")
            .WithMessage("LinkedIn profile in wrong format.")
            .MaximumLength(100)
            .WithMessage("LinkedIn profile cannot be longer than 100 characters.");

        RuleFor(u => u.GitHubProfile)
            .NotEmpty()
            .WithMessage("GitHub profile cannot be empty")
            .NotNull()
            .WithMessage("GitHub profile cannot be null")
            .Matches(@"^(https?:\/\/)?(www\.)?(github\.com\/)[a-zA-Z0-9\-]+\/?$")
            .WithMessage("GitHub profile in wrong format.")
            .MaximumLength(100)
            .WithMessage("GitHub profile cannot be longer than 100 characters.");

        RuleFor(u => u.Description)
            .MaximumLength(500)
            .WithMessage("Description cannot be longer than 500 characters.");
    }
}
