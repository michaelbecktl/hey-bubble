using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entity
{
  public class PostLike
  {
    [ForeignKey("PostId")]

    public int PostId { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }

    public Post Post { get; set; } = null!;

    public User User { get; set; } = null!;

  }

    public class CommentLike
  {
    [ForeignKey("CommentId")]

    public int CommentId { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }

    public Comment Comment { get; set; } = null!;

    public User User { get; set; } = null!;

  }
}