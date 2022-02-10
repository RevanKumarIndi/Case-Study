using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Practicewebapi.Models
{
    public partial class PracticedbContext : DbContext
    {
        public PracticedbContext()
        {
        }

        public PracticedbContext(DbContextOptions<PracticedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<User> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; initial catalog= Practicedb;integrated security=True; MultipleActiveResultSets=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Date)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorReview)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Doctor_Review");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("End_Time");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Problem)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Start_Time");

                entity.Property(e => e.Weight)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Booking__DoctorI__276EDEB3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Booking__UserId__267ABA7A");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhNo).HasMaxLength(10);

                entity.Property(e => e.Specilization)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FeedBack");

                entity.Property(e => e.Date)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FeedBack1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FeedBackId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Doctor)
                    .WithMany()
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__FeedBack__Doctor__38996AB5");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__FeedBack__UserId__398D8EEE");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("Prescription");

                entity.Property(e => e.Prescription1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Prescription");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Prescript__Docto__2E1BDC42");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Prescript__UserI__2F10007B");
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Slot");

                entity.Property(e => e.Availability)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("End_Time");

                entity.Property(e => e.SlotId).ValueGeneratedOnAdd();

                entity.Property(e => e.StartTime)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Start_Time");

                entity.HasOne(d => d.Doctor)
                    .WithMany()
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Slot__DoctorId__29572725");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhNo).HasMaxLength(10);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
