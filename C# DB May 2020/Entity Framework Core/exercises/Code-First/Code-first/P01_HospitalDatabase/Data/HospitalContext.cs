namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext :DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            :base(options)
        {
            
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"server=DESKTOP-KQ9J3DG\SQLEXPRESS;Database=Hospital System;Integrated Security=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Patient>(entity =>
            {
                entity
                .HasKey(pk => pk.PatientId);

                entity
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

                entity
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

                entity
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsRequired()
                .IsUnicode();

                entity
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsRequired()
                .IsUnicode(false);

                entity
                .Property(p => p.HasInsurance)
                .IsRequired();

            });
            builder.Entity<Visitation>(entity =>
            {
                entity
                .HasKey(pk => pk.VisitationId);

                entity
                .Property(p => p.Comments)
                .IsUnicode()
                .HasMaxLength(250)
                .IsRequired();

                entity
                .HasOne(d => d.Doctor)
                .WithMany(v => v.Visitations)
                .HasForeignKey(fk => fk.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

                entity
                .HasOne(p => p.Patient)
                .WithMany(v => v.Visitations)
                .HasForeignKey(fk => fk.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<Diagnose>(entity =>
            {
                entity
                .HasKey(pk => pk.DiagnoseId);

                entity
                .Property(p => p.Name)
                .IsUnicode()
                .HasMaxLength(50)
                .IsRequired();

                entity
                .Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired();

                entity
                .HasOne(p => p.Patient)
                .WithMany(d => d.Diagnoses)
                .HasForeignKey(fk => fk.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<Medicament>(entity =>
            {
                entity
                .HasKey(pk => pk.MedigamentId);

                entity
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();
            });
            builder.Entity<PatientMedicament>(entity =>
            {
                entity
                .HasKey(ck => new { ck.MedicamentId, ck.PatientId });

                entity
                .HasOne(m => m.Medicament)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(fk => fk.MedicamentId)
                .OnDelete(DeleteBehavior.Cascade);

                entity
                .HasOne(m => m.Patient)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(fk => fk.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<Doctor>(entity =>
            {
                entity
                .HasKey(pk => pk.DoctorId);

                entity
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

                entity
                .Property(p => p.Speciality)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();
            });

        }
    }
}
