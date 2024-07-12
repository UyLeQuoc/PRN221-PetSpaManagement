using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;

namespace RepositoryLayer
{
    public class PetSpaManagementDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }

        //public virtual DbSet<PackageService> PackageServices { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        //public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        //public virtual DbSet<Service> Services { get; set; }
        //public virtual DbSet<SpaPackage> SpaPackages { get; set; }

        public PetSpaManagementDbContext(DbContextOptions<PetSpaManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.User)
                      .WithMany(e => e.Payments)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("User");
            //    entity.HasKey(e => e.Id).HasName("User_pk");

            //    entity.Property(e => e.Name).HasMaxLength(100);
            //    entity.Property(e => e.Email).HasMaxLength(100);
            //    entity.Property(e => e.Password).HasMaxLength(100);

            //    entity.HasOne(e => e.Role)
            //          .WithMany(e => e.Users)
            //          .HasForeignKey(e => e.RoleId)
            //          .OnDelete(DeleteBehavior.SetNull)
            //          .HasConstraintName("User_Role_fk");

            //    entity.HasMany(e => e.Pets)
            //          .WithOne(e => e.User)
            //          .HasForeignKey(e => e.UserId)
            //          .OnDelete(DeleteBehavior.Cascade);

            //    entity.HasMany(e => e.Reviews)
            //          .WithOne(e => e.User)
            //          .HasForeignKey(e => e.UserId)
            //          .OnDelete(DeleteBehavior.Cascade);

            //    //entity.HasMany(e => e.Appointments)
            //    //      .WithOne(e => e.User)
            //    //      .HasForeignKey(e => e.UserId)
            //    //      .OnDelete(DeleteBehavior.Cascade)
            //    //      .HasConstraintName("Appointment_User_fk").IsRequired(false);

            //    //entity.HasMany(e => e.StaffAppointments)
            //    //      .WithOne(e => e.Staff)
            //    //      .HasForeignKey(e => e.StaffId)
            //    //      .OnDelete(DeleteBehavior.Cascade)
            //    //      .HasConstraintName("Appointment_Staff_fk").IsRequired(false);
            //});

            //modelBuilder.Entity<Pet>(entity =>
            //{
            //    entity.ToTable("Pet");
            //    entity.HasKey(e => e.Id).HasName("Pet_pk");

            //    entity.Property(e => e.Name).HasMaxLength(100);
            //    entity.Property(e => e.Type).HasMaxLength(50);

            //    entity.HasOne(e => e.User)
            //          .WithMany(e => e.Pets)
            //          .HasForeignKey(e => e.UserId)
            //          .OnDelete(DeleteBehavior.Cascade);

            //    entity.HasMany(e => e.Appointments)
            //          .WithOne(e => e.Pet)
            //          .HasForeignKey(e => e.PetId)
            //          .OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity<Appointment>(entity =>
            //{
            //    entity.ToTable("Appointment");
            //    entity.HasKey(e => e.Id).HasName("Appointment_pk");

            //    entity.Property(e => e.DateTime).HasColumnType("datetime");
            //    entity.Property(e => e.Status).HasMaxLength(50);
            //    entity.Property(e => e.Notes).HasMaxLength(500);

            //    //entity.HasOne(e => e.User)
            //    //      .WithMany(u => u.Appointments)
            //    //      .HasForeignKey(e => e.UserId)
            //    //      .OnDelete(DeleteBehavior.Cascade)
            //    //      .HasConstraintName("Appointment_User_fk");

            //    entity.HasOne(e => e.Pet)
            //          .WithMany(e => e.Appointments)
            //          .HasForeignKey(e => e.PetId)
            //          .OnDelete(DeleteBehavior.Cascade)
            //          .HasConstraintName("Appointment_Pet_fk");

            //    entity.HasOne(e => e.SpaPackage)
            //          .WithMany(e => e.Appointments)
            //          .HasForeignKey(e => e.SpaPackageId)
            //          .OnDelete(DeleteBehavior.Cascade)
            //          .HasConstraintName("Appointment_SpaPackage_fk");

            //    entity.HasMany(e => e.Payments)
            //          .WithOne(e => e.Appointment)
            //          .HasForeignKey(e => e.AppointmentId)
            //          .OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity<PackageService>(entity =>
            //{
            //    entity.ToTable("PackageService");
            //    entity.HasKey(e => e.Id).HasName("PackageService_pk");

            //    entity.HasOne(e => e.SpaPackage)
            //          .WithMany(e => e.PackageServices)
            //          .HasForeignKey(e => e.SpaPackageId)
            //          .OnDelete(DeleteBehavior.Cascade)
            //          .HasConstraintName("PackageService_SpaPackage_fk");

            //    entity.HasOne(e => e.Service)
            //          .WithMany(e => e.PackageServices)
            //          .HasForeignKey(e => e.ServiceId)
            //          .OnDelete(DeleteBehavior.Cascade)
            //          .HasConstraintName("PackageService_Service_fk");
            //});

            //modelBuilder.Entity<Payment>(entity =>
            //{
            //    entity.ToTable("Payment");
            //    entity.HasKey(e => e.Id).HasName("Payment_pk");

            //    entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            //    entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            //    entity.Property(e => e.PaymentDate).HasColumnType("datetime");

            //    entity.HasOne(e => e.Appointment)
            //          .WithMany(e => e.Payments)
            //          .HasForeignKey(e => e.AppointmentId)
            //          .OnDelete(DeleteBehavior.Cascade)
            //          .HasConstraintName("Payment_Appointment_fk");
            //});

            //modelBuilder.Entity<Review>(entity =>
            //{
            //    entity.ToTable("Review");
            //    entity.HasKey(e => e.Id).HasName("Review_pk");

            //    entity.Property(e => e.Rating).HasColumnType("int");
            //    entity.Property(e => e.Comment).HasMaxLength(500);

            //    entity.HasOne(e => e.User)
            //          .WithMany(e => e.Reviews)
            //          .HasForeignKey(e => e.UserId)
            //          .OnDelete(DeleteBehavior.NoAction)
            //          .HasConstraintName("Review_User_fk");

            //    entity.HasOne(e => e.Appointment)
            //          .WithMany()
            //          .HasForeignKey(e => e.AppointmentId)
            //          .OnDelete(DeleteBehavior.Cascade)
            //          .HasConstraintName("Review_Appointment_fk");
            //});

            //modelBuilder.Entity<Role>(entity =>
            //{
            //    entity.ToTable("Role");
            //    entity.HasKey(e => e.Id).HasName("Role_pk");

            //    entity.Property(e => e.Name).HasMaxLength(50);

            //    entity.HasMany(e => e.Users)
            //          .WithOne(e => e.Role)
            //          .HasForeignKey(e => e.RoleId)
            //          .OnDelete(DeleteBehavior.SetNull);
            //});

            //modelBuilder.Entity<Service>(entity =>
            //{
            //    entity.ToTable("Service");
            //    entity.HasKey(e => e.Id).HasName("Service_pk");

            //    entity.Property(e => e.Name).HasMaxLength(100);
            //    entity.Property(e => e.Description).HasMaxLength(500);
            //    entity.Property(e => e.Duration).HasColumnType("int");

            //    entity.HasMany(e => e.PackageServices)
            //          .WithOne(e => e.Service)
            //          .HasForeignKey(e => e.ServiceId)
            //          .OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity<SpaPackage>(entity =>
            //{
            //    entity.ToTable("SpaPackage");
            //    entity.HasKey(e => e.Id).HasName("SpaPackage_pk");

            //    entity.Property(e => e.Name).HasMaxLength(100);
            //    entity.Property(e => e.Description).HasMaxLength(500);
            //    entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            //    entity.Property(e => e.PictureUrl).HasMaxLength(250);
            //    entity.Property(e => e.EstimatedTime).HasColumnType("int");

            //    entity.HasMany(e => e.PackageServices)
            //          .WithOne(e => e.SpaPackage)
            //          .HasForeignKey(e => e.SpaPackageId)
            //          .OnDelete(DeleteBehavior.Cascade);

            //    entity.HasMany(e => e.Appointments)
            //          .WithOne(e => e.SpaPackage)
            //          .HasForeignKey(e => e.SpaPackageId)
            //          .OnDelete(DeleteBehavior.Cascade);
            //});
        }
    }
}