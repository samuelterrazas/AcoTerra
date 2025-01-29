﻿using AcoTerra.API.Data.Entities.Actors;
using AcoTerra.API.Data.Entities.Employees.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Employees;

internal sealed class Employee : Actor
{
    public required EmploymentStatus EmploymentStatus { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public string? EmergencyContacts { get; set; }
}

internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");
        
        builder.Property(employee => employee.Id)
            .ValueGeneratedOnAdd();
    }
}