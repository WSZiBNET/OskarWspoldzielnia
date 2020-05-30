using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIWspolnota.Models
{
    public partial class HousingAssociationContext : DbContext
    {
        public HousingAssociationContext()
        {
        }

        public HousingAssociationContext(DbContextOptions<HousingAssociationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblFlats> TblFlats { get; set; }
        public virtual DbSet<TblInvoices> TblInvoices { get; set; }
        public virtual DbSet<TblOwners> TblOwners { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }
        public virtual DbSet<VwFlats> VwFlats { get; set; }
        public virtual DbSet<VwOwners> VwOwners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;DataBase=HousingAssociation;Integrated Security=True;", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblFlats>(entity =>
            {
                entity.ToTable("tblFlats");

                entity.HasIndex(e => e.Number)
                    .HasName("UX_tblFlats_Number")
                    .IsUnique();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Geometry)
                    .IsRequired()
                    .HasColumnType("geometry")
                    .HasDefaultValueSql("('POLYGON((0 0, 8 0, 8 11, 0 11, 0 0))')");

                entity.Property(e => e.GeometryDesc).HasComputedColumnSql("([Geometry].[STAsText]())");

                entity.Property(e => e.Map).HasColumnType("image");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.ModUser).HasMaxLength(128);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SurfaceArea).HasComputedColumnSql("(isnull([Geometry].[STArea](),(0)))");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.TblFlats)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFlats_tblOwners");
            });

            modelBuilder.Entity<TblInvoices>(entity =>
            {
                entity.ToTable("tblInvoices");

                entity.HasIndex(e => e.Number)
                    .HasName("UX_tblInvoices_Number")
                    .IsUnique();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.ModUser).HasMaxLength(128);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Value).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Flat)
                    .WithMany(p => p.TblInvoices)
                    .HasForeignKey(d => d.FlatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInvoices_tblFlats");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.TblInvoices)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInvoices_tblOwners");
            });

            modelBuilder.Entity<TblOwners>(entity =>
            {
                entity.ToTable("tblOwners");

                entity.HasIndex(e => new { e.FirstName, e.LastName })
                    .HasName("UX_tblOwners_Name")
                    .IsUnique();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.ModUser).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOwners)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOwners_tblUsers");
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.ToTable("tblUsers", "config");

                entity.HasIndex(e => e.Login)
                    .HasName("UX_tblUsers_Login")
                    .IsUnique();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.ModUser).HasMaxLength(128);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            modelBuilder.Entity<VwFlats>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwFlats");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Map).HasColumnType("image");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<VwOwners>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwOwners");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
