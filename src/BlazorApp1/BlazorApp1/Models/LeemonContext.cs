using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Models;

public partial class LeemonContext : DbContext
{
    public LeemonContext()
    {
    }

    public LeemonContext(DbContextOptions<LeemonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artists> Artists { get; set; }

    public virtual DbSet<Artworks> Artworks { get; set; }

    public virtual DbSet<Comments> Comments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Purchases> Purchases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=художники;User Id=Artists;Password=12345;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artworks>(entity =>
        {
            entity.HasKey(e => e.ArtworkId).HasName("PK__Artworks__4BD2943AABBADC55");

            entity.Property(e => e.ArtworkId).HasColumnName("ArtworkID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Genre).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Artworks)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__Artworks__CreatedB__286302EC");
        });

        modelBuilder.Entity<Artists>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("PK__Artists__AA15BEC466D6C482");

            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.ArtworkId).HasColumnName("ArtworkID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Artwork).WithMany(p => p.Artists)
                .HasForeignKey(d => d.ArtworkId)
                .HasConstraintName("FK__Artists__Artworks__3A81B327");

            entity.HasOne(d => d.User).WithMany(p => p.Artists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Artists__UserID__398D8EEE");
        });

        modelBuilder.Entity<Comments>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__74BC79AEB1C8435D");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedByUserId).HasColumnName("DeletedByUserID");
            entity.Property(e => e.ArtworkID).HasColumnName("ArtworkID");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserName");

            entity.HasOne(d => d.DeletedByUser).WithMany(p => p.CommentsDeletedByUsers)
                .HasForeignKey(d => d.DeletedByUserId)
                .HasConstraintName("FK__Comments__Deleted__31EC6D26");

            entity.HasOne(d => d.Artworks).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ArtworkId)
                .HasConstraintName("FK__Comments__ArtworkID__2E1BDC42");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Comments__UserName__2D27B809");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC318DE74F");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534C1D0541B").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Purchases>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__Purchases__48DEAA2BC5F20D9E");

            entity.Property(e => e.PurchaseId).HasColumnName("PurchasesID");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.ArtworkId).HasColumnName("ArtworkID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Artworks).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.ArtworkId)
                .HasConstraintName("FK__Purchases__Artworks__35BCFE0A");

            entity.HasOne(d => d.User).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Purchases__UserID__34C8D9D1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
