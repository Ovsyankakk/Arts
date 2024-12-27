using System;
using System.Collections.Generic;

namespace BlazorApp1.Models;

public partial class Artists
{
    public int ArtistId { get; set; }

    public int? UserId { get; set; }

    public int? ArtworkId { get; set; }

    public DateTime? AddedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Artworks? Artwork { get; set; }

    public virtual User? User { get; set; }
}
