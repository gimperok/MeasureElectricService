using MeasureElectricData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MeasureElectricApi
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<SubCompany> SubCompanies { get; set; }
        public DbSet<ConsumptionObject> ConsumptionObjects { get; set; }

        public DbSet<ElectricityMeasuringPoint> ElectricityMeasuringPoints { get; set; }
        public DbSet<ElectricalEnergyCounter> ElectricalEnergyCounters { get; set; }
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; }
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; }

        public DbSet<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }
        public DbSet<SettlementMeter> SettlementMeters { get; set; }

        public DbSet<ElMesPointsSettMeters> ElMesPointsSettMeterss { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Companies");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name");

                entity.Property(e => e.Adress)
                    .HasColumnName("adress");

                entity.HasMany(a => a.SubCompanies)
                      .WithOne(e => e.Company);
            });

            modelBuilder.Entity<SubCompany>(entity =>
            {
                entity.ToTable("SubCompanies");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name");

                entity.Property(e => e.Adress)
                    .HasColumnName("adress");

                entity.HasMany(a => a.ConsumptionObjects)
                      .WithOne(e => e.SubCompany);
            });

            modelBuilder.Entity<ConsumptionObject>(entity =>
            {
                entity.ToTable("ConsumptionObjects");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.HasMany(a => a.ElectricityMeasuringPoints)
                      .WithOne(e => e.ConsumptionObject);
            });

            modelBuilder.Entity<ElectricityMeasuringPoint>(entity =>
            {
                entity.ToTable("ElectricityMeasuringPoint");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name");

                entity.HasMany(e => e.SettlementMeters)
                    .WithMany(e => e.ElectricityMeasuringPointList)
                    .UsingEntity<ElMesPointsSettMeters>();
            });

            modelBuilder.Entity<ElectricalEnergyCounter>(entity =>
            {
                entity.ToTable("ElectricalEnergyCounters");

                entity.HasKey(e => e.ElectricityMeasuringPointId);

                entity.Property(e => e.Type)
                    .HasColumnName("type");

                entity.Property(e => e.VerificationDate)
                    .HasColumnName("verification_date");

                entity.HasOne(e => e.ElectricityMeasuringPoint)
                    .WithOne(e => e.EnergyCounter)
                    .HasForeignKey<ElectricalEnergyCounter>(e => e.ElectricityMeasuringPointId)
                    .IsRequired();
            });

            modelBuilder.Entity<CurrentTransformer>(entity =>
            {
                entity.ToTable("CurrentTransformers");

                entity.HasKey(e => e.ElectricityMeasuringPointId);

                entity.Property(e => e.Type)
                    .HasColumnName("type");

                entity.Property(e => e.VerificationDate)
                    .HasColumnName("verification_date");

                entity.Property(e => e.KTT)
                    .HasColumnName("ktt");

                entity.HasOne(e => e.ElectricityMeasuringPoint)
                    .WithOne(e => e.CurrentTransformer)
                    .HasForeignKey<CurrentTransformer>(e => e.ElectricityMeasuringPointId)
                    .IsRequired();
            });

            modelBuilder.Entity<VoltageTransformer>(entity =>
            {
                entity.ToTable("VoltageTransformers");

                entity.Property(e => e.Type)
                    .HasColumnName("type");

                entity.Property(e => e.VerificationDate)
                    .HasColumnName("verification_date");

                entity.Property(e => e.KTN)
                    .HasColumnName("ktn");

                entity.HasOne(e => e.ElectricityMeasuringPoint)
                    .WithOne(e => e.VoltageTransformer)
                    .HasForeignKey<VoltageTransformer>(e => e.ElectricityMeasuringPointId)
                    .IsRequired();

                entity.HasOne(d => d.ElectricityMeasuringPoint);
            });

            modelBuilder.Entity<ElectricitySupplyPoint>(entity =>
            {
                entity.ToTable("ElectricitySupplyPoints");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name");

                entity.Property(e => e.MaxPower)
                    .HasColumnName("max_power");


                entity.HasOne(e => e.SettlementMeter)
                    .WithMany(e => e.ElectricitySupplyPointList)
                    .HasForeignKey(e => e.SettlementMeterId)
                    .IsRequired(false);
            });

            modelBuilder.Entity<SettlementMeter>(entity =>
            {
                entity.ToTable("SettlementMeters");

                entity.HasKey(e => e.Id);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Database=ServiceDb;");
        }
    }
}
