using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HelloWebAPI.Model.Table
{
    public partial class HelloWebAPIContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Server=bfdemo.database.windows.net;Database=HelloWebAPI;user id=JamisLiao;password=Wenle!98$;");
        //}

        public HelloWebAPIContext(DbContextOptions<HelloWebAPIContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasColumnName("Student_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.StudentCreateDateTime)
                    .HasColumnName("Student_CreateDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.StudentGender)
                    .IsRequired()
                    .HasColumnName("Student_Gender")
                    .HasMaxLength(50);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasColumnName("Student_Name")
                    .HasMaxLength(50);
            });
        }

        public virtual DbSet<Student> Student { get; set; }
    }
}