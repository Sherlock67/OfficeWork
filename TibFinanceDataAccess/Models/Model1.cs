using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TibFinanceDataAccess.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentDetailInfo> StudentDetailInfos { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<Grade>()
                .Property(e => e.GradeName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<StudentDetailInfo>()
                .Property(e => e.Std_Father_Name)
                .IsUnicode(false);

            modelBuilder.Entity<StudentDetailInfo>()
                .Property(e => e.Std_Mother_Name)
                .IsUnicode(false);

            modelBuilder.Entity<StudentDetailInfo>()
                .Property(e => e.Std_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<StudentDetailInfo>()
                .Property(e => e.Std_Gender)
                .IsUnicode(false);

            modelBuilder.Entity<StudentDetailInfo>()
                .Property(e => e.Std_BloodGroup)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
