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
    public string Username { get; set; }

    [StringLength(16, MinimumLength = 8)]
    public string Password { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$")]
    public string Email { get; set; }
  }

      // User's Profile Information Model //
    public class UserProfile
    {
      [Key]
      [ForeignKey("User")]
      public int UserId { get; set; }

      [StringLength(30, MinimumLength = 3)]
      public string DisplayName { get; set; }

      public DateOnly Dob { get; set; }

      public string? ProfilePhoto { get; set; }

      public string Gender { get; set; }

      public string Country { get; set; }

      public string NativeLanguage { get; set; }

      public string LearningLanguage { get; set; }

    }
}