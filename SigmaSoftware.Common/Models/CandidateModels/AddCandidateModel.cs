namespace SigmaSoftware.Common.Models.CandidateModels;
public class AddCandidateModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public TimeSpan CallStartTime { get; set; }
    public TimeSpan CallEndTime { get; set; }
    public string LinkedInProfile { get; set; }
    public string GitHubProfile { get; set; }
    public string? Description { get; set; }
}
