using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkplaceReservation.Repository.Entities;

namespace WorkplaceReservation.Repository.Context
{
    public class WorkplaceDbContext : DbContext
    {
        public WorkplaceDbContext(DbContextOptions<WorkplaceDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Workplace> Workplaces { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentForWorkplace> EquipmentForWorkplaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Employee
            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(25);
            //Workplace
            modelBuilder.Entity<Workplace>()
                .Property(w => w.Floor)
                .IsRequired();
            modelBuilder.Entity<Workplace>()
                .Property(w => w.Room)
                .IsRequired();
            modelBuilder.Entity<Workplace>()
                .Property(w => w.Table)
                .IsRequired();
            //Reservation
            modelBuilder.Entity<Reservation>()
                .Property(r => r.TimeFrom)
                .IsRequired();
            modelBuilder.Entity<Reservation>()
                .Property(r => r.TimeTo)
                .IsRequired();
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.Reservations)
                .HasForeignKey(r => r.EmployeeId);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Workplace)
                .WithMany(w => w.Reservations)
                .HasForeignKey(r => r.WorkplaceId);
            //Equipment
            modelBuilder.Entity<Equipment>()
                .Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(25);
            //EquipmentforWorkplace
            modelBuilder.Entity<EquipmentForWorkplace>()
                .Property(e => e.Count)
                .IsRequired();
            modelBuilder.Entity<EquipmentForWorkplace>()
                .HasOne(e => e.Workplace)
                .WithMany(w => w.EquipmentForWorkplaces)
                .HasForeignKey(e => e.WorkplaceId);
            modelBuilder.Entity<EquipmentForWorkplace>()
                .HasOne(e => e.Equipment)
                .WithMany(e => e.EquipmentForWorkplaces)
                .HasForeignKey(e => e.EquipmentId);

        }
    }
}
