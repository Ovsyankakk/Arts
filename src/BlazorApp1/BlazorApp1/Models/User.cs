using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using BlazorApp1.Components.Pages;

namespace BlazorApp1.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;
 
    public string Email { get; set; } = null!;
 
    public string PasswordHash { get; set; } = null!;
    
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Artists> Artists { get; set; } = new List<Artists>();

    public virtual ICollection<Artworks> Artworks { get; set; } = new List<Artworks>();

    public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();

    public virtual ICollection<User> Users { get; set; } = new List<Users>();

    public virtual ICollection<Purchases> Purchases { get; set; } = new List<Purchases>();
}




