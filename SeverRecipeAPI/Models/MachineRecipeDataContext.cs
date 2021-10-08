using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SeverRecipeAPI.Models
{
    public partial class MachineRecipeDataContext : DbContext
    {
        public MachineRecipeDataContext()
        {
        }

        public MachineRecipeDataContext(DbContextOptions<MachineRecipeDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MachineRecipe> MachineRecipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=MachineRecipeData; Trusted_Connection=True; MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<MachineRecipe>(entity =>
            {
                entity.HasKey(e => e.RecipeId)
                    .HasName("PK__tmp_ms_x__FDD988B0B9DBFA44");

                entity.ToTable("MachineRecipe");

                entity.Property(e => e.MachinePlc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MachinePLC");

                entity.Property(e => e.RecipeName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Speed)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Temperature)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
