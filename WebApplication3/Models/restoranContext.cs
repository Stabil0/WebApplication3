using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication3.Models
{
    public partial class restoranContext : DbContext
    {
       
        public restoranContext()
        {
        }

        public restoranContext(DbContextOptions<restoranContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Emploeey> Emploeeys { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Orde> Ordes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source = C:\\Users\\stabilo\\Documents\\restoran\\restoran.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emploeey>(entity =>
            {
                entity.HasKey(e => e.EmployeeCode);

                entity.ToTable("Emploeey");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Employee_code");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnType("string (255)");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("CHAR (255)")
                    .HasColumnName("Full_name");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("CHAR (50)");

                entity.Property(e => e.Old).HasColumnType("INT");

                entity.Property(e => e.PassportData)
                    .HasColumnType("INT")
                    .HasColumnName("Passport_data");

                entity.Property(e => e.Phone).HasColumnType("INT");

                entity.Property(e => e.PositionCode)
                    .HasColumnType("INT")
                    .HasColumnName("Position_code");

                entity.HasOne(d => d.PositionCodeNavigation)
                    .WithMany(p => p.Emploeeys)
                    .HasForeignKey(d => d.PositionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.DishCode);

                entity.ToTable("Menu");

                entity.Property(e => e.DishCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Dish_Code");

                entity.Property(e => e.Cost).HasColumnType("INT");

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasColumnType("CHAR (255)")
                    .HasColumnName("Dish_name");

                entity.Property(e => e.IngredientCode)
                    .HasColumnType("INT")
                    .HasColumnName("Ingredient_code");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnType("datatime");

                entity.Property(e => e.Volume1)
                    .HasColumnType("INT")
                    .HasColumnName("volume_1");

                entity.Property(e => e.Volume2)
                    .HasColumnType("INT")
                    .HasColumnName("volume_2");

                entity.Property(e => e.Volume3)
                    .HasColumnType("INT")
                    .HasColumnName("volume_3");

                entity.HasOne(d => d.IngredientCodeNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.IngredientCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Orde>(entity =>
            {
                entity.HasKey(e => e.CustomerName);

                entity.ToTable("Orde");

                entity.Property(e => e.CustomerName)
                    .HasColumnType("CHAR (255)")
                    .HasColumnName("Customer_name");

                entity.Property(e => e.Chec).HasColumnType("INT");

                entity.Property(e => e.Cost).HasColumnType("INT");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.DishCode)
                    .HasColumnType("INT")
                    .HasColumnName("Dish_Code");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnType("INT")
                    .HasColumnName("Employee_code");

                entity.Property(e => e.Phone).HasColumnType("INT");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.HasOne(d => d.DishCodeNavigation)
                    .WithMany(p => p.Ordes)
                    .HasForeignKey(d => d.DishCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.EmployeeCodeNavigation)
                    .WithMany(p => p.Ordes)
                    .HasForeignKey(d => d.EmployeeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionCode);

                entity.ToTable("Position");

                entity.Property(e => e.PositionCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Position_code");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnType("CHAR (255)")
                    .HasColumnName("Job_title");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnType("CHAR (255)");

                entity.Property(e => e.Responsibilities)
                    .IsRequired()
                    .HasColumnType("CHAR (255)");

                entity.Property(e => e.Salary).HasColumnType("INT");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.IngredientCode);

                entity.ToTable("Warehouse");

                entity.Property(e => e.IngredientCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Ingredient_code");

                entity.Property(e => e.Cost).HasColumnType("INT");

                entity.Property(e => e.Data).HasColumnType("INT");

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasColumnType("CHAR (255)")
                    .HasColumnName("Ingredient_name");

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasColumnType("CHAR (255)");

                entity.Property(e => e.ShelfIfe)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("Shelf__ife");

                entity.Property(e => e.Volume).HasColumnType("INT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
