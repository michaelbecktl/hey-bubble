  public class UserDTO
  {
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
  }

public class PostDTO
{
  public int PostId { get; set; }
  public int UserId { get; set; }

  public string? DisplayName { get; set; }

  public required string Content { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
  public string? MediaUrl { get; set; }
  public string? MediaType { get; set; }
  public int? LikeCount { get; set; }

  public int? CommentCount { get; set; }

  public bool isLikedByUser { get; set; }
}

public class NewPostDTO
{
  public required string Content { get; set; }
  public string? MediaUrl { get; set; }
  public string? MediaType { get; set; }

}

public class CommentDTO
{
  public int CommentId { get; set; }
  public int PostId { get; set; }
  public int UserId { get; set; }
  public string? DisplayName { get; set; }
  public required string Content { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string? MediaUrl { get; set; }
  public string? MediaType { get; set; }
  public int? LikeCount { get; set; }
  public bool isLikedByUser { get; set; }
}

public class NewCommentDTO
{
  public int PostId { get; set; }
  public required string Content { get; set; }
  public string? MediaUrl { get; set; }
  public string? MediaType { get; set; }
}