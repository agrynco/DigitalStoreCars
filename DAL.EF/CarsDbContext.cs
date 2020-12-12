using System.Resources;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DAL.EF
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions options) : base(options)
        {
        }

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            return serviceCollection.BuildServiceProvider()
                .GetService<ILoggerFactory>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SetupCarModel(modelBuilder);
            SetupCarTrim(modelBuilder);
            SetupCarVariant(modelBuilder);
            SetupCarOrder(modelBuilder);
            SetupCustomer(modelBuilder);

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            SeedCarModels(modelBuilder);
            SeedCarTrims(modelBuilder);
            SeedCarVariants(modelBuilder);
            SeedCustomers(modelBuilder);
        }

        private void SeedCustomers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Email = "agrynco@gmail.com",
                    Phone = "01234567",
                    Name = "Anatolii Grynchuk"
                },
                new Customer
                {
                    Id = 2,
                    Email = "agrynco+second_customer@gmail.com",
                    Phone = "2345678",
                    Name = "Alex Bolgarob"
                },
                new Customer
                {
                    Id = 3,
                    Email = "agrynco+third_customer@gmail.com",
                    Phone = "2345678",
                    Name = "Bohdan Hertz"
                }
            );
        }

        private void SeedCarVariants(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarVariant>().HasData(
                new CarVariant
                {
                    Id = 1,
                    Engine = "EK31",
                    Price = 2000,
                    Year = 2014,
                    FuelType = FuelType.Petrol,
                    GearType = GearType.Manual,
                    IsAvailable = true,
                    CarTrimId = 1
                },
                new CarVariant
                {
                    Id = 2,
                    Engine = "EK51",
                    Price = 2000,
                    Year = 2014,
                    FuelType = FuelType.Petrol,
                    GearType = GearType.Manual,
                    IsAvailable = true,
                    CarTrimId = 1
                },
                new CarVariant
                {
                    Id = 3,
                    Engine = "EK23",
                    Price = 2000,
                    Year = 2014,
                    FuelType = FuelType.Petrol,
                    GearType = GearType.Manual,
                    IsAvailable = true,
                    CarTrimId = 1
                },
                new CarVariant
                {
                    Id = 4,
                    Engine = "GX",
                    Price = 2000,
                    Year = 2014,
                    FuelType = FuelType.Diesel,
                    GearType = GearType.Automatic,
                    IsAvailable = true,
                    CarTrimId = 2
                },
                new CarVariant
                {
                    Id = 5,
                    Engine = "V-TWIN",
                    Price = 2000,
                    Year = 2010,
                    FuelType = FuelType.Diesel,
                    GearType = GearType.Manual,
                    IsAvailable = true,
                    CarTrimId = 3
                },
                new CarVariant
                {
                    Id = 6,
                    Engine = "iGX",
                    Price = 2000,
                    Year = 2014,
                    FuelType = FuelType.Petrol,
                    GearType = GearType.Automatic,
                    IsAvailable = true,
                    CarTrimId = 3
                });
        }

        private void SeedCarTrims(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarTrim>().HasData(
                new CarTrim
                {
                    Id = 1,
                    Name = "Premium",
                    CarModelId = 1,
                    IsAvailable = true
                },
                new CarTrim
                {
                    Id = 2,
                    Name = "Limited",
                    CarModelId = 1,
                    IsAvailable = true
                },
                new CarTrim
                {
                    Id = 3,
                    Name = "LX",
                    CarModelId = 2,
                    IsAvailable = true
                },
                new CarTrim
                {
                    Id = 4,
                    Name = "EX",
                    CarModelId = 2,
                    IsAvailable = true
                },
                new CarTrim
                {
                    Id = 5,
                    Name = "EX-L",
                    CarModelId = 2,
                    IsAvailable = true
                }
            );
        }

        private void SeedCarModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>().HasData(
                new CarModel
                {
                    Id = 1,
                    Name = "Subaru",
                    BrandName = "Outback",
                    IsAvailable = true
                },
                new CarModel
                {
                    Id = 2,
                    Name = "Honda",
                    BrandName = "CR-V",
                    IsAvailable = true
                },
                new CarModel
                {
                    Id = 3,
                    Name = "Nissan",
                    BrandName = "XTrail",
                    IsAvailable = true
                },
                new CarModel
                {
                    Id = 4,
                    Name = "Kia",
                    BrandName = "Sorento",
                    IsAvailable = true
                },
                new CarModel
                {
                    Id = 5,
                    Name = "Kia",
                    BrandName = "Santa Fe",
                    IsAvailable = true
                });
        }

        private void SetupCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.Property(m => m.Name)
                    .HasMaxLength(150)
                    .IsRequired();
                builder.HasIndex(m => new
                {
                    m.Email
                }).IsUnique();

                builder.Property(m => m.Email)
                    .HasMaxLength(70)
                    .IsRequired();

                builder.Property(m => m.Phone)
                    .HasMaxLength(8)
                    .IsRequired();
            });
        }

        private void SetupCarOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarOrder>(builder =>
            {
                builder.Property(m => m.ModelName)
                    .HasMaxLength(150)
                    .IsRequired();

                builder.Property(m => m.Engine)
                    .HasMaxLength(150)
                    .IsRequired();

                builder.Property(m => m.TrimName)
                    .HasMaxLength(150)
                    .IsRequired();

                builder.Property(m => m.BankLoanDownPayment).HasColumnType("decimal(8,2)");
                builder.Property(m => m.BankLoanMonthlyPayment).HasColumnType("decimal(8,2)");
            });
        }

        private void SetupCarVariant(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarVariant>(builder =>
            {
                builder.Property(m => m.Engine)
                    .HasMaxLength(150)
                    .IsRequired();
            });
        }

        private static void SetupCarTrim(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarTrim>(builder =>
            {
                builder.Property(m => m.Name)
                    .HasMaxLength(150)
                    .IsRequired();
            });
        }

        private static void SetupCarModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>(builder =>
            {
                builder.Property(m => m.Name)
                    .HasMaxLength(150)
                    .IsRequired();

                builder.Property(m => m.BrandName)
                    .HasMaxLength(150)
                    .IsRequired();

                builder.HasIndex(m => new
                {
                    m.Name,
                    m.BrandName
                }).IsUnique();
            });
        }

        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarOrder> CarOrders { get; set; }
        public DbSet<CarTrim> CarTrims { get; set; }
        public DbSet<CarVariant> CarVariants { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}