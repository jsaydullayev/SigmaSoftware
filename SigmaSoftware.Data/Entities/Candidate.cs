using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SigmaSoftware.Data.Entities;
[Table("candidate", Schema = "my")]
public class Candidate
{
    [Column("id")]
    [Key]
    public Guid Id { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    public string LastName { get; set; }

    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("call_start_time")]
    public TimeSpan CallStartTime { get; set; }

    [Column("call_end_time")]
    public TimeSpan CallEndTime { get; set; }
    [Column("linkedin_profile")]
    public string LinkedInProfile { get; set; }

    [Column("git_hub_profile")]
    public string GitHubProfile { get; set; }

    [Column("description")]
    public string? Description { get; set; }
}
