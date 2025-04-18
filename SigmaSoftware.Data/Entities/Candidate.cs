using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SigmaSoftware.Data.Entities;
public class Candidate
{
    [Column("id")]
    [Key]
    public Guid Id { get; set; }

    [Column("first_name")]
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Column("last_name")]
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Column("phone_number")]
    [Required]
    [MaxLength(20)]
    public string PhoneNumber { get; set; }

    [Column("email")]
    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    [Column("call_start_time")]
    [Required]
    [DataType(DataType.Time)]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan CallStartTime { get; set; }

    [Column("call_end_time")]
    [Required]
    [DataType(DataType.Time)]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan CallEndTime { get; set; }
    [Column("linkedin_profile")]
    [EmailAddress]
    public string LinkedInProfile { get; set; }

    [Column("git_hub_profile")]
    [EmailAddress]
    public string GitHubProfile { get; set; }

    [Column("description")]
    [MaxLength(500)]
    public string? Description { get; set; }
}
