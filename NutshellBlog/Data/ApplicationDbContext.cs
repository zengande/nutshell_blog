using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutshellBlog.Infrastructure;
using NutshellBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NutshellBlog.Data
{
    public class ApplicationDbContext
        : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }

        #region Entities
        public DbSet<Article> Articles { get; set; }
        public DbSet<Archives> Archives { get; set; }
        public DbSet<Tag> Tags { get; set; }
        #endregion

        #region Mapping Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>(ConfigureArticles);
            modelBuilder.Entity<Archives>(ConfigureArchives);
            modelBuilder.Entity<ArticleTag>(ConfigureArticleTags);
        }

        private void ConfigureArticleTags(EntityTypeBuilder<ArticleTag> builder)
        {
            builder.ToTable("T_Article_Tag");
            builder.HasKey(m => new { m.ArticleId, m.TagId });
            builder.HasOne(pt => pt.Article)
                .WithMany(p => p.ArticleTags)
                .HasForeignKey(pt => pt.ArticleId);
            builder.HasOne(pt => pt.Tag)
                .WithMany(p => p.ArticleTags)
                .HasForeignKey(pt => pt.TagId);
        }

        private void ConfigureArchives(EntityTypeBuilder<Archives> builder)
        {
            builder.ToTable("T_Archives");

            builder.Property(m => m.Name)
                .HasMaxLength(100)
                .IsRequired(false);
            builder.Property(m => m.IsDeleted);

            builder.HasKey(m => m.Id);
        }

        private void ConfigureArticles(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("T_Articles");

            builder.Property(m => m.Identity)
                .HasMaxLength(100)
                .IsRequired(false);
            builder.Property(m => m.Title)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(m => m.Content)
                .HasMaxLength(int.MaxValue)
                .IsRequired();
            builder.Property(m => m.PublishTime);
            builder.Property(m => m.LastEditTime);
            builder.Property(m => m.IsDeleted);
        } 
        #endregion

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();

            return true;
        }

    }
}
