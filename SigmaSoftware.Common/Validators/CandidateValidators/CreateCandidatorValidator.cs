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
         .Matches("^998\\d{9}$").When(x => !string.IsNullOrEmpty(x.PhoneNumber))
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
            .Must(x => !x.HasValue || (x.Value.Hours >= 0 && x.Value.Hours < 24))
            .WithMessage("Call start time must be in range from 0 to 23 hours")
            .Must(x => !x.HasValue || (x.Value.Minutes >= 0 && x.Value.Minutes < 60))
            .WithMessage("Call start time must be in range from 0 to 59 minutes");

        RuleFor(u => u.CallEndTime)
            .Must(x => !x.HasValue || (x.Value.Hours >= 0 && x.Value.Hours < 24))
            .WithMessage("Call end time must be in range from 0 to 23 hours")
            .Must(x => !x.HasValue || (x.Value.Minutes >= 0 && x.Value.Minutes < 60))
            .WithMessage("Call end time must be in range from 0 to 59 minutes")
            .GreaterThan(x => x.CallStartTime)
            .WithMessage("Call end time must be greater than call start time")
            .LessThan(x => x.CallStartTime.HasValue ? x.CallStartTime.Value.Add(new TimeSpan(3, 0, 0)) : (TimeSpan?)null)
            .WithMessage("Call end time must be less than call start time + 1 hour");

        RuleFor(u => u.LinkedInProfile)
            .NotEmpty().When(x => !string.IsNullOrEmpty(x.LinkedInProfile))
            .Matches(@"^(https?:\/\/)?(www\.)?(linkedin\.com\/)(in|pub|company)\/[a-zA-Z0-9\-]+\/?$")
            .WithMessage("LinkedIn profile in wrong format.")
            .MaximumLength(100)
            .WithMessage("LinkedIn profile cannot be longer than 100 characters.");

        RuleFor(u => u.GitHubProfile)
            .NotEmpty().When(x => !string.IsNullOrEmpty(x.GitHubProfile))
            .Matches(@"^(https?:\/\/)?(www\.)?(github\.com\/)[a-zA-Z0-9\-]+\/?$")
            .WithMessage("GitHub profile in wrong format.")
            .MaximumLength(100)
            .WithMessage("GitHub profile cannot be longer than 100 characters.");

        RuleFor(u => u.Description)
            .NotNull().
            WithMessage("Description cannot be null")
            .NotEmpty()
            .WithMessage("Description cannot be empty")
            .MaximumLength(500)
            .WithMessage("Description cannot be longer than 500 characters.");
    }
}
