using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
  // User's Account Credentials Model //
  public class User
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(30, MinimumLength = 3)]
    public required string Username { get; set; }

    [StringLength(100, MinimumLength = 8)]
    public required string Password { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$")]
    public required string Email { get; set; }
  }

      // User's Profile Information Model //
    public class UserProfile
    {
      [Key]
      [ForeignKey("User")]
      public int UserId { get; set; }

      [StringLength(30, MinimumLength = 3)]
      public required string DisplayName { get; set; }

      public DateOnly Dob { get; set; }

      public string? ProfilePhoto { get; set; }

      public required string Gender { get; set; }

      public required string Country { get; set; }

      public required string NativeLanguage { get; set; }

      public required string LearningLanguage { get; set; }

    }
}