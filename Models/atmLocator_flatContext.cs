using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using coop_atm_locator.Controllers;
using coop_atm_locator.Backend;

namespace coop_atm_locator.Models
{
    public partial class atmLocator_flatContext : DbContext
    {
        public atmLocator_flatContext()
        {
        }

        public atmLocator_flatContext(DbContextOptions<atmLocator_flatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Locations> Locations { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locations>(entity =>
            {
                
                entity.HasKey(e => new { e.Name, e.ReferenceId });

/*                entity.HasKey(e => e.LocationId)
                .HasName("PK__Location__E7FEA477FF3BFBB2");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasMaxLength(64)
                    .IsUnicode(false);*/

                entity.Property(e => e.AcceptCash).HasMaxLength(50);

                entity.Property(e => e.AcceptDeposit).HasMaxLength(50);

                entity.Property(e => e.Access).HasMaxLength(50);

                entity.Property(e => e.AccessNotes)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cashless)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.County)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DriveThruOnly)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EnvelopeRequired).HasMaxLength(50);

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HandicapAccess).HasMaxLength(50);

                entity.Property(e => e.Hours)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtfriClose)
                    .IsRequired()
                    .HasColumnName("HoursDTFriClose")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtfriOpen)
                    .IsRequired()
                    .HasColumnName("HoursDTFriOpen")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtmonClose)
                    .IsRequired()
                    .HasColumnName("HoursDTMonClose")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtmonOpen)
                    .IsRequired()
                    .HasColumnName("HoursDTMonOpen")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtsatClose)
                    .IsRequired()
                    .HasColumnName("HoursDTSatClose")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtsatOpen)
                    .IsRequired()
                    .HasColumnName("HoursDTSatOpen")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtsunClose)
                    .IsRequired()
                    .HasColumnName("HoursDTSunClose")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtsunOpen)
                    .IsRequired()
                    .HasColumnName("HoursDTSunOpen")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtthuClose)
                    .IsRequired()
                    .HasColumnName("HoursDTThuClose")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtthuOpen)
                    .IsRequired()
                    .HasColumnName("HoursDTThuOpen")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDttueClose)
                    .IsRequired()
                    .HasColumnName("HoursDTTueClose")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDttueOpen)
                    .IsRequired()
                    .HasColumnName("HoursDTTueOpen")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtwedClose)
                    .IsRequired()
                    .HasColumnName("HoursDTWedClose")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursDtwedOpen)
                    .IsRequired()
                    .HasColumnName("HoursDTWedOpen")
                    .HasMaxLength(50);

                entity.Property(e => e.HoursFriClose)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursFriOpen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursMonClose)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursMonOpen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursSatClose)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursSatOpen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursSunClose)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursSunOpen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursThuClose)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursThuOpen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursTueClose)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursTueOpen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursWedClose)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HoursWedOpen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InstallationType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.LimitedTransactions)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LocationType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.MilitaryIdRequired)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OnMilitaryBase)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OnPremise).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReferenceId)
                    .IsRequired()
                    .HasColumnName("ReferenceID")
                    .HasMaxLength(50);

                entity.Property(e => e.RestrictedAccess)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RetailOutlet)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SelfServiceDevice)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SelfServiceOnly)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surcharge).HasMaxLength(50);

                entity.Property(e => e.WebAddress)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
