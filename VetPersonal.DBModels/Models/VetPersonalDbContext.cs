using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VetPersonal.DBModels.Models;

public partial class VetPersonalDbContext : DbContext
{
    public VetPersonalDbContext()
    {
    }

    public VetPersonalDbContext(DbContextOptions<VetPersonalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ContentType> ContentTypes { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<PageContent> PageContents { get; set; }

    public virtual DbSet<PageImage> PageImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1253_CI_AI");

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Articles__3214EC07C9C2968C");

            entity.Property(e => e.ImageName).HasMaxLength(100);
            entity.Property(e => e.Language).HasMaxLength(2);
            entity.Property(e => e.Text).HasColumnType("ntext");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.LanguageNavigation).WithMany(p => p.Articles)
                .HasForeignKey(d => d.Language)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Articles_FK1");
        });

        modelBuilder.Entity<ContentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContentT__3214EC07CAAC649E");

            entity.ToTable("ContentType");

            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Languages_PK");

            entity.Property(e => e.Id).HasMaxLength(2);
            entity.Property(e => e.Abbreviation).HasMaxLength(2);
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pages__3214EC0772702FE8");

            entity.Property(e => e.Language).HasMaxLength(2);
            entity.Property(e => e.MenuText).HasMaxLength(100);
            entity.Property(e => e.Route).HasMaxLength(100);

            entity.HasOne(d => d.LanguageNavigation).WithMany(p => p.Pages)
                .HasForeignKey(d => d.Language)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pages_FK1");
        });

        modelBuilder.Entity<PageContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PageCont__3214EC07CAF97326");

            entity.ToTable("PageContent");

            entity.Property(e => e.Language).HasMaxLength(2);
            entity.Property(e => e.Text).HasColumnType("ntext");

            entity.HasOne(d => d.LanguageNavigation).WithMany(p => p.PageContents)
                .HasForeignKey(d => d.Language)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PageContent_FK1");

            entity.HasOne(d => d.PageNavigation).WithMany(p => p.PageContents)
                .HasForeignKey(d => d.Page)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PageContent_FK3");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.PageContents)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PageContent_FK2");
        });

        modelBuilder.Entity<PageImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PageImag__3214EC075AFE3D7D");

            entity.Property(e => e.ImageName).HasMaxLength(100);

            entity.HasOne(d => d.PageNavigation).WithMany(p => p.PageImages)
                .HasForeignKey(d => d.Page)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PageImages_FK1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
