using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace DiscussionForum.Models.db
{
    public partial class discussionForumDBContext : IdentityDbContext<ApplicationUser>
    {
        public discussionForumDBContext()
        {

        }

        public discussionForumDBContext(DbContextOptions<discussionForumDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Discussion> Discussions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\discussionForum_DB;Database=discussionForumDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN"},
                new { Id = Guid.NewGuid().ToString(), Name = "Member", NormalizedName = "MEMBER"});

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => new { e.Did, e.CommenNo });

                entity.Property(e => e.Did).HasColumnName("DID");

                entity.Property(e => e.CommenNo).HasColumnName("CommenNO");

                entity.Property(e => e.Decription).HasMaxLength(255);

                entity.Property(e => e.ReplyDate).HasColumnType("datetime");

                entity.Property(e => e.UserIp)
                    .HasMaxLength(100)
                    .HasColumnName("UserIP");

                entity.Property(e => e.UserName).HasMaxLength(10);
            });

            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.HasKey(e => e.Did);

                entity.Property(e => e.Did).HasColumnName("DID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DiscussionDetails).HasMaxLength(255);

                entity.Property(e => e.DiscussionTopic).HasMaxLength(100);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UserIp)
                    .HasMaxLength(100)
                    .HasColumnName("UserIP");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
