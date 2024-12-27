using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BlazorApp1.Models;

public partial class Artworks
{
    public int ArtworkId { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly? ReleaseDate { get; set; }

    public string? Genre { get; set; }

    public string? Description { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual ICollection<Artists> Artists { get; set; } = new List<Artists>();

    public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();

    public virtual ICollection<Purchases> Purchases { get; set; } = new List<Purchases>();
}
