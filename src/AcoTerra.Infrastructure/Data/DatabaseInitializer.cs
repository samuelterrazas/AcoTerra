using AcoTerra.Core.Entities.Actors.Enums;
using AcoTerra.Core.Entities.Customers;
using AcoTerra.Core.Entities.Drivers;
using AcoTerra.Core.Entities.Drivers.Enums;
using AcoTerra.Core.Entities.Producers;
using AcoTerra.Core.Entities.Products;
using AcoTerra.Core.Entities.Products.Enums;
using AcoTerra.Core.Entities.Trucks;
using Bogus;
using Bogus.Extensions.UnitedStates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace AcoTerra.Infrastructure.Data;

public sealed class DatabaseInitializer(
    ApplicationDbContext dbContext,
    ILogger<DatabaseInitializer> logger
)
{
    public async Task InitializeAsync()
    {
        try
        {
            await dbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        await using IDbContextTransaction transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            #region Producers

            var producers = new List<Producer>();

            for (int i = 0; i < 10; i++)
            {
                var faker = new Faker("es");

                var producer = new Producer
                {
                    Id = i + 1,
                    Name = faker.Person.FullName,
                    IdentificationType = IdentificationType.DNI,
                    IdentificationNumber = faker.Person.Ssn(),
                    PhoneNumber = faker.Person.Phone,
                    Email = faker.Person.Email,
                };

                producers.Add(producer);
            }
            
            dbContext.Set<Producer>().AddRange(producers);

            #endregion
            
            #region Products

            var products = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                var faker = new Faker("es");

                var product = new Product
                {
                    Id = i + 100,
                    Name = faker.Commerce.Product(),
                    PackagingType = PackagingType.Pallet,
                    Weight = decimal.Round(faker.Random.Decimal(min: 10, max: 1500)),
                    Price = decimal.Parse(faker.Commerce.Price()),
                };

                products.Add(product);
            }

            dbContext.Set<Product>().AddRange(products);

            #endregion

            #region Customers

            var customers = new List<Customer>();

            for (int i = 0; i < 10; i++)
            {
                var faker = new Faker("es");

                var customer = new Customer
                {
                    Id = i + 1_000,
                    Name = faker.Person.FullName,
                    IdentificationType = IdentificationType.DNI,
                    IdentificationNumber = faker.Person.Ssn(),
                    PhoneNumber = faker.Person.Phone,
                    Email = faker.Person.Email,
                };
            
                customers.Add(customer);
            }
            
            dbContext.Set<Customer>().AddRange(customers);

            #endregion
            
            #region Drivers

            var drivers = new List<Driver>();

            for (int i = 0; i < 10; i++)
            {
                var faker = new Faker("es");

                var driver = new Driver
                {
                    Id = i + 10_000,
                    Name = faker.Person.FullName,
                    IdentificationType = IdentificationType.DNI,
                    IdentificationNumber = faker.Person.Ssn(),
                    PhoneNumber = faker.Person.Phone,
                    Email = faker.Person.Email,
                    EmploymentStatus = EmploymentStatus.Active,
                    DateOfBirth = DateOnly.FromDateTime(faker.Person.DateOfBirth),
                };
            
                drivers.Add(driver);
            }
            
            dbContext.Set<Driver>().AddRange(drivers);

            #endregion

            #region Trailers

            var trailers = new List<Trailer>
            {
                new()
                {
                    Id = 1,
                    LicensePlate = "BA 321 DC",
                    Capacity = 45_000,
                },
                new()
                {
                    Id = 2,
                    LicensePlate = "AC 654 FE",
                    Capacity = 48_000,
                },
            };
            
            dbContext.Set<Trailer>().AddRange(trailers);

            #endregion

            #region Trucks

            var trucks = new List<Truck>
            {
                new()
                {
                    Id = 1,
                    LicensePlate = "AB 123 CD",
                    Brand = "Mercedes-Benz",
                    Model = "Actros 2645",
                    ManufacturingYear = 2020,
                    ChassisNumber = "8APZZZ12345678901",
                    EngineNumber = "MBOM471198A123456",
                    DriverId = 10_001,
                    TrailerId = 1,
                },
                new()
                {
                    Id = 2,
                    LicensePlate = "AC 456 EF",
                    Brand = "Scania",
                    Model = "R 500",
                    ManufacturingYear = 2021,
                    ChassisNumber = "9BSZZZ12345678902",
                    EngineNumber = "SCANIA12345AB6789",
                    DriverId = 10_002,
                    TrailerId = 2,
                },
            };
            
            dbContext.Set<Truck>().AddRange(trucks);
            
            #endregion

            await dbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
}