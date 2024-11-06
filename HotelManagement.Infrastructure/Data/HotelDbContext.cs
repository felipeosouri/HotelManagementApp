using HotelManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infrastructure.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones entre entidades
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Passengers)
                .WithOne(p => p.Reservation)
                .HasForeignKey(p => p.ReservationId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany()
                .HasForeignKey(r => r.RoomId);

            // Configuración para el tipo propietario Contact
            modelBuilder.Entity<Reservation>()
                .OwnsOne(r => r.EmergencyContact, contact =>
                {
                    contact.Property(c => c.FullName).HasColumnName("EmergencyContactFullName");
                    contact.Property(c => c.ContactPhone).HasColumnName("EmergencyContactPhone");
                });

            // Configuración para el tipo propietario RoomLocation
            modelBuilder.Entity<Room>()
                .OwnsOne(r => r.Location, location =>
                {
                    location.Property(l => l.Floor).HasColumnName("RoomFloor");
                    location.Property(l => l.Wing).HasColumnName("RoomWing");
                    location.Property(l => l.RoomNumber).HasColumnName("RoomNumber");
                });

            // Especificar precisión para BasePrice y Taxes
            modelBuilder.Entity<Room>()
                .Property(r => r.BasePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Room>()
                .Property(r => r.Taxes)
                .HasPrecision(18, 2);
        }
    }
}
