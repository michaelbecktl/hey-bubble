public class UserDTO
{
  public int Id { get; set; }
  public required string Username { get; set; }
  public required string Email { get; set; }
}

public class UserProfileDTO
{
  public int UserId { get; set; }
  public required string DisplayName { get; set; }

  public DateOnly Dob { get; set; }

  public string? ProfilePhoto { get; set; }

  public required string Gender { get; set; }

  public required string Country { get; set; }

  public required string NativeLanguage { get; set; }

  public required string LearningLanguage { get; set; }

  public required int Following { get; set; }

  public required int Followers { get; set; }
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

public class UpdatePostDTO
{
  public required string Content { get; set; }

}

public class CommentDTO
{
  public int CommentId { get; set; }
  public int PostId { get; set; }
  public int UserId { get; set; }
  public string? DisplayName { get; set; }
  public required string Content { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
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

public class UpdateCommentDTO
{
  public required string Content { get; set; }

}

public class PostLikeDTO
{
  public int PostId { get; set; }

  public int UserId { get; set; }
}

public class CommentLikeDTO
{
    public int CommentId { get; set; }

    public int UserId { get; set; }
}