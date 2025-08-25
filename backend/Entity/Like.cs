using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entity
{
  public class PostLike
  {

    public int PostId { get; set; }

    public int UserId { get; set; }

    public Post Post { get; set; } = null!;

    public User User { get; set; } = null!;

  }

    public class CommentLike
  {

    public int CommentId { get; set; }

    public int UserId { get; set; }

    public Comment Comment { get; set; } = null!;

    public User User { get; set; } = null!;

  }
}