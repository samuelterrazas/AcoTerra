using AcoTerra.API.Data.Entities.Actors.Enums;
using AcoTerra.API.Data.Entities.Customers;
using AcoTerra.API.Data.Entities.Employees;
using AcoTerra.API.Data.Entities.Employees.Enums;
using AcoTerra.API.Data.Entities.Producers;
using AcoTerra.API.Data.Entities.Products;
using AcoTerra.API.Data.Entities.Products.Enums;
using Bogus;
using Bogus.Extensions.UnitedStates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AcoTerra.API.Data;

internal sealed class DatabaseInitializer(
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
            #region Employees

            var employees = new List<Employee>();

            for (int i = 0; i < 10; i++)
            {
                var faker = new Faker("es");

                var employee = new Employee
                {
                    Id = i + 1,
                    Name = faker.Person.FullName,
                    IdentificationType = IdentificationType.DNI,
                    IdentificationNumber = faker.Person.Ssn(),
                    PhoneNumber = faker.Person.Phone,
                    Email = faker.Person.Email,
                    EmploymentStatus = EmploymentStatus.Active,
                    DateOfBirth = DateOnly.FromDateTime(faker.Person.DateOfBirth),
                };
            
                employees.Add(employee);
            }
            
            dbContext.Set<Employee>().AddRange(employees);

            #endregion
            
            #region Producers

            var producers = new List<Producer>();

            for (int i = 0; i < 10; i++)
            {
                var faker = new Faker("es");

                var producer = new Producer
                {
                    Id = i + 100,
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
                    Id = i + 1_000,
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
                    Id = i + 10_000,
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