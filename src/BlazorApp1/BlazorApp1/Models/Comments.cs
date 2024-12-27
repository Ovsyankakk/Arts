using System;
using System.Collections.Generic;

namespace BlazorApp1.Models;

public partial class Comments
{
    public int CommentId { get; set; }

    public int? UserId { get; set; }

    public int? ArtworkId { get; set; }

    public int? Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedByUserId { get; set; }

    public virtual User? DeletedByUser { get; set; }

    public virtual Artworks? Artwork { get; set; }

    public virtual User? Users { get; set; }
}
