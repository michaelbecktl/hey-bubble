using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entity
{
  public class Post
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PostId { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }

    public required string Content { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? MediaUrl { get; set; }
    public string? MediaType { get; set; }
    public int? LikeCount { get; set; }

    public User User { get; set; } = null!;

    public ICollection<Comment>? Comments { get; set; } = new List<Comment>();

    public ICollection<PostLike>? PostLikes { get; set; } = new List<PostLike>();

  }
}