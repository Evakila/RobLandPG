using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RobLandPG.Models
{
    public partial class RoblandCMContext : DbContext
    {
        public RoblandCMContext()
        {
        }

        public RoblandCMContext(DbContextOptions<RoblandCMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<MyFile> MyFiles { get; set; } = null!;
        public virtual DbSet<Tblclientdocument> Tblclientdocuments { get; set; } = null!;
        public virtual DbSet<Tbluser> Tblusers { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=RoblandCM;Username=postgres;Password=Evakila2018");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("department");

                entity.Property(e => e.Departmentid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("departmentid");

                entity.Property(e => e.Departmentname)
                    .HasMaxLength(500)
                    .HasColumnName("departmentname");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employee");

                entity.Property(e => e.Dateofjoining).HasColumnName("dateofjoining");

                entity.Property(e => e.Department)
                    .HasMaxLength(500)
                    .HasColumnName("department");

                entity.Property(e => e.Employeeid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("employeeid");

                entity.Property(e => e.Employeename)
                    .HasMaxLength(500)
                    .HasColumnName("employeename");

                entity.Property(e => e.Photofilename)
                    .HasMaxLength(500)
                    .HasColumnName("photofilename");
            });

            modelBuilder.Entity<MyFile>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<Tblclientdocument>(entity =>
            {
                entity.ToTable("tblclientdocuments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Contenttype)
                    .HasMaxLength(256)
                    .HasColumnName("contenttype");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .HasColumnName("description");

                entity.Property(e => e.Docname)
                    .HasMaxLength(256)
                    .HasColumnName("docname");

                entity.Property(e => e.Document).HasColumnName("document");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Tbluser>(entity =>
            {
                entity.ToTable("tblusers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(256)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(256)
                    .HasColumnName("country");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(256)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(256)
                    .HasColumnName("lastname");

                entity.Property(e => e.State)
                    .HasMaxLength(256)
                    .HasColumnName("state");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Names)
                    .HasColumnType("char")
                    .HasColumnName("names");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
