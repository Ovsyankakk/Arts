using System;
using System.Collections.Generic;

namespace BlazorApp1.Models;

public partial class Purchases
{
    public int PurchasetId { get; set; }

    public int? UserId { get; set; }

    public int? ArtworkId { get; set; }

    public virtual Artworks? Artworks { get; set; }

    public virtual User? User { get; set; }
}
