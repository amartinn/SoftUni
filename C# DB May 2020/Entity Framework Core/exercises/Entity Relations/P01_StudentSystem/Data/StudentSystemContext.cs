namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;
    using System;
    using Common;
    public class StudentSystemContext: DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            :base(options)
        {

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"server=DESKTOP-KQ9J3DG\SQLEXPRESS;Database=Student System;Integrated Security=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>(entity =>
            {
                entity.HasKey(p => p.StudentId);

                entity
                .Property(p => p.Name)
                .IsUnicode()
                .HasMaxLength(100)
                .IsRequired(true);

                entity
                .Property(p => p.PhoneNumber)
                .IsFixedLength(true)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired(false);

                entity
                .Property(p => p.RegisteredOn)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAdd();

                entity.Property(p => p.Birthday)
                .IsRequired(false);
            });
            builder.Entity<Course>(entity =>
            {
                entity.HasKey(k => k.CourseId);

                entity.Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

                entity.Property(p => p.Description)
                .IsUnicode()
                .IsRequired(false);

                entity.Property(e => e.StartDate)
                .IsRequired();

                entity.Property(e => e.EndDate)
                    .IsRequired();

                entity.Property(e => e.Price)
                    .IsRequired();
                
            });
            builder.Entity<Resource>(entity =>
            {
                entity.HasKey(k => k.ResourceId);
                entity.Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

                entity.Property(p => p.Url)
                .IsUnicode(false)
                .IsRequired();


                entity.Property(p => p.ResourceType)
                .HasConversion(
                    e => e.ToString(),
                    e => (ResourceType)Enum.Parse(typeof(ResourceType), e))
                .IsRequired();

                entity.HasOne(c => c.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Homework>(entity =>
            {
                entity.HasKey(k => k.HomeworkId);

                entity.Property(p => p.Content)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(p => p.ContentType)
                .HasConversion(
                    e => e.ToString(),
                    e => (ContentType)Enum.Parse(typeof(ContentType), e))
                .IsRequired();

                entity.Property(p => p.SubmissionTime)
                .IsRequired();

                entity.HasOne(e => e.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(e => e.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(ck => new { ck.StudentId, ck.CourseId });

                entity.HasOne(sk => sk.Student)
                .WithMany(sc => sc.CourseEnrollments)
                .HasForeignKey(sk => sk.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ck => ck.Course)
                .WithMany(sc => sc.StudentsEnrolled)
                .HasForeignKey(ck => ck.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            });

        }
    }
}
