using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Models;

public partial class MovieContext : DbContext
{
    public MovieContext()
    {
    }

    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAccount> TbAccounts { get; set; }

    public virtual DbSet<TbActor> TbActors { get; set; }

    public virtual DbSet<TbBlog> TbBlogs { get; set; }

    public virtual DbSet<TbBlogComment> TbBlogComments { get; set; }

    public virtual DbSet<TbCategoryMovie> TbCategoryMovies { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbMovie> TbMovies { get; set; }

    public virtual DbSet<TbMovieDetail> TbMovieDetails { get; set; }

    public virtual DbSet<TbMovieReview> TbMovieReviews { get; set; }

    public virtual DbSet<TbNews> TbNews { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TblAdminMenu> TblAdminMenus { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__tb_Accou__349DA5A633A4E047");

            entity.ToTable("tb_Account");

            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(150);
        });

        modelBuilder.Entity<TbActor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PK__tb_Actor__57B3EA4B53706E94");

            entity.ToTable("tb_Actor");

            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__tb_Blog__54379E300976BCC0");

            entity.ToTable("tb_Blog");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CategoryMovie).WithMany(p => p.TbBlogs)
                .HasForeignKey(d => d.CategoryMovieId)
                .HasConstraintName("FK_tb_Blog_tb_CategoryMovie");
        });

        modelBuilder.Entity<TbBlogComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);

            entity.ToTable("tb_BlogComment");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Blog).WithMany(p => p.TbBlogComments)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK_tb_BlogComment_tb_Blog");
        });

        modelBuilder.Entity<TbCategoryMovie>(entity =>
        {
            entity.HasKey(e => e.CategoryMovieId).HasName("PK__tb_Categ__19093A0B0A9E2101");

            entity.ToTable("tb_CategoryMovie");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.ToTable("tb_Menu");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbMovie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__tb_Movie__4BD2941A8C5BF3D9");

            entity.ToTable("tb_Movie");

            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.TrailerUrl).HasColumnName("TrailerURL");

            entity.HasOne(d => d.CategoryMovie).WithMany(p => p.TbMovies)
                .HasForeignKey(d => d.CategoryMovieId)
                .HasConstraintName("FK_tb_Movie_tb_CategoryMovie");
        });

        modelBuilder.Entity<TbMovieDetail>(entity =>
        {
            entity.HasKey(e => e.MovieDetailId);

            entity.ToTable("tb_MovieDetail");

            entity.Property(e => e.MovieDetailId).HasColumnName("MovieDetail_Id");
            entity.Property(e => e.Mmparating).HasColumnName("MMPARating");

            entity.HasOne(d => d.Movie).WithMany(p => p.TbMovieDetails)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK_tb_MovieDetail_tb_Movie");
        });

        modelBuilder.Entity<TbMovieReview>(entity =>
        {
            entity.HasKey(e => e.MovieReviewId).HasName("PK__tb_Revie__74BC79CE5D444A2E");

            entity.ToTable("tb_MovieReview");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Movie).WithMany(p => p.TbMovieReviews)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_Review__Movie__4CA06362");
        });

        modelBuilder.Entity<TbNews>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__tb_News__954EBDF3CA1B3652");

            entity.ToTable("tb_News");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__tb_Role__8AFACE1AC7FAD7AF");

            entity.ToTable("tb_Role");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblAdminMenu>(entity =>
        {
            entity.HasKey(e => e.AdminMenuId);

            entity.ToTable("tblAdminMenu");

            entity.Property(e => e.AdminMenuId).HasColumnName("AdminMenuID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
