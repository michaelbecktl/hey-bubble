using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entity
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

    public DateTime CreatedAt { get; set; }

    public UserProfile? UserProfile { get; set; }
    public ICollection<Post>? Posts { get; set; } = new List<Post>();
    public ICollection<Comment>? Comments { get; set; } = new List<Comment>();

    public ICollection<PostLike>? PostLikes { get; set; } = new List<PostLike>();

    public ICollection<CommentLike>? CommentLike { get; set; } = new List<CommentLike>();
  }

  // User's Profile Information Model //
  public class UserProfile
  {
    [Key]
    [ForeignKey("UserId")]
    public int UserId { get; set; }

    [StringLength(30, MinimumLength = 3)]
    public required string DisplayName { get; set; }

    public DateOnly Dob { get; set; }

    public string? ProfilePhoto { get; set; }

    public required string Gender { get; set; }

    public required string Country { get; set; }

    public required string NativeLanguage { get; set; }

    public required string LearningLanguage { get; set; }

    public required int Following { get; set; }

    public required int Followers { get; set; }

    public User User { get; set; } = null!;

    }
}