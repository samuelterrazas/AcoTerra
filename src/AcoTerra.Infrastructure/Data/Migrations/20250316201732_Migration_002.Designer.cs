﻿// <auto-generated />
using System;
using AcoTerra.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcoTerra.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250316201732_Migration_002")]
    partial class Migration_002
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("AcoTerra.Core.Entities.Agents.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("identification_number");

                    b.Property<int>("IdentificationType")
                        .HasColumnType("INTEGER")
                        .HasColumnName("identification_type");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name")
                        .UseCollation("NOCASE");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("phone_number");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_agents");

                    b.ToTable("agents", (string)null);

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Freights.Freight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<DateOnly>("LoadingDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("loading_date");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("number");

                    b.Property<string>("Remarks")
                        .HasColumnType("TEXT")
                        .HasColumnName("remarks");

                    b.Property<decimal>("TotalShipmentAmount")
                        .HasColumnType("TEXT")
                        .HasColumnName("total_shipment_amount");

                    b.Property<decimal>("TotalShipmentQuantity")
                        .HasColumnType("TEXT")
                        .HasColumnName("total_shipment_quantity");

                    b.Property<decimal>("TotalShipmentWeight")
                        .HasColumnType("TEXT")
                        .HasColumnName("total_shipment_weight");

                    b.Property<int>("TruckId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("truck_id");

                    b.Property<DateOnly>("UnloadingDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("unloading_date");

                    b.HasKey("Id")
                        .HasName("pk_freight");

                    b.HasIndex("TruckId")
                        .HasDatabaseName("ix_freight_truck_id");

                    b.ToTable("freight", (string)null);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Freights.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("customer_id");

                    b.Property<int>("FreightId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("freight_id");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("location");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("number");

                    b.Property<int>("ProducerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("producer_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("product_id");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnName("status");

                    b.Property<decimal>("TotalProductAmount")
                        .HasColumnType("TEXT")
                        .HasColumnName("total_product_amount");

                    b.Property<decimal>("TotalProductQuantity")
                        .HasColumnType("TEXT")
                        .HasColumnName("total_product_quantity");

                    b.Property<decimal>("TotalProductWeight")
                        .HasColumnType("TEXT")
                        .HasColumnName("total_product_weight");

                    b.HasKey("Id")
                        .HasName("pk_shipments");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_shipments_customer_id");

                    b.HasIndex("FreightId")
                        .HasDatabaseName("ix_shipments_freight_id");

                    b.HasIndex("ProducerId")
                        .HasDatabaseName("ix_shipments_producer_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_shipments_product_id");

                    b.ToTable("shipments", (string)null);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.LegalDocuments.LegalDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int?>("AgentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("agent_id");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("document");

                    b.Property<DateOnly?>("ExpirationDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("expiration_date");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER")
                        .HasColumnName("type");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id")
                        .HasName("pk_legal_documents");

                    b.HasIndex("AgentId")
                        .HasDatabaseName("ix_legal_documents_agent_id");

                    b.HasIndex("VehicleId")
                        .HasDatabaseName("ix_legal_documents_vehicle_id");

                    b.ToTable("legal_documents", (string)null);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("PackagingType")
                        .HasColumnType("INTEGER")
                        .HasColumnName("packaging_type");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT")
                        .HasColumnName("price");

                    b.Property<decimal>("Weight")
                        .HasColumnType("TEXT")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Trucks.Trailer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<decimal>("Capacity")
                        .HasColumnType("TEXT")
                        .HasColumnName("capacity");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("license_plate")
                        .UseCollation("NOCASE");

                    b.Property<int?>("TruckId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("truck_id");

                    b.HasKey("Id")
                        .HasName("pk_trailers");

                    b.HasIndex("TruckId")
                        .IsUnique()
                        .HasDatabaseName("ix_trailers_truck_id");

                    b.ToTable("trailers", (string)null);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.AdditionalEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("Condition")
                        .HasColumnType("INTEGER")
                        .HasColumnName("condition");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT")
                        .HasColumnName("cost");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id")
                        .HasName("pk_additional_equipment");

                    b.HasIndex("VehicleId")
                        .HasDatabaseName("ix_additional_equipment_vehicle_id");

                    b.ToTable("additional_equipment", (string)null);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.FinancialInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<bool>("Financed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("financed");

                    b.Property<int>("Installments")
                        .HasColumnType("INTEGER")
                        .HasColumnName("installments");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<decimal>("OutstandingBalance")
                        .HasColumnType("TEXT")
                        .HasColumnName("outstanding_balance");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("TEXT")
                        .HasColumnName("purchase_price");

                    b.HasKey("Id")
                        .HasName("pk_financial_information");

                    b.ToTable("financial_information", (string)null);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.MaintenanceHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT")
                        .HasColumnName("cost");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("date");

                    b.Property<string>("Document")
                        .HasColumnType("TEXT")
                        .HasColumnName("document");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("type");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id")
                        .HasName("pk_maintenance_history");

                    b.HasIndex("VehicleId")
                        .HasDatabaseName("ix_maintenance_history_vehicle_id");

                    b.ToTable("maintenance_history", (string)null);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.TechnicalInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<decimal>("AverageConsumption")
                        .HasColumnType("TEXT")
                        .HasColumnName("average_consumption");

                    b.Property<decimal>("CurrentMileage")
                        .HasColumnType("TEXT")
                        .HasColumnName("current_mileage");

                    b.Property<int>("FuelType")
                        .HasColumnType("INTEGER")
                        .HasColumnName("fuel_type");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<decimal>("TankSize")
                        .HasColumnType("TEXT")
                        .HasColumnName("tank_size");

                    b.HasKey("Id")
                        .HasName("pk_technical_information");

                    b.ToTable("technical_information", (string)null);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.TrafficFine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT")
                        .HasColumnName("amount");

                    b.Property<DateTime>("DateIssued")
                        .HasColumnType("TEXT")
                        .HasColumnName("date_issued");

                    b.Property<string>("Document")
                        .HasColumnType("TEXT")
                        .HasColumnName("document");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<DateOnly?>("PaidAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("paid_at");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("vehicle_id");

                    b.Property<string>("Violation")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("violation");

                    b.HasKey("Id")
                        .HasName("pk_traffic_fines");

                    b.HasIndex("VehicleId")
                        .HasDatabaseName("ix_traffic_fines_vehicle_id");

                    b.ToTable("traffic_fines", (string)null);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("brand");

                    b.Property<string>("ChassisNumber")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("chassis_number");

                    b.Property<string>("EngineNumber")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("engine_number");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_at");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_modified_by");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("license_plate")
                        .UseCollation("NOCASE");

                    b.Property<int>("ManufacturingYear")
                        .HasColumnType("INTEGER")
                        .HasColumnName("manufacturing_year");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("model");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_vehicles");

                    b.ToTable("vehicles", (string)null);

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Agents.Customer", b =>
                {
                    b.HasBaseType("AcoTerra.Core.Entities.Agents.Agent");

                    b.ToTable("agents", (string)null);

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Agents.Driver", b =>
                {
                    b.HasBaseType("AcoTerra.Core.Entities.Agents.Agent");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("TEXT")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("EmergencyContact")
                        .HasColumnType("TEXT")
                        .HasColumnName("emergency_contact");

                    b.Property<int>("EmploymentStatus")
                        .HasColumnType("INTEGER")
                        .HasColumnName("employment_status");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("vehicle_id");

                    b.HasIndex("VehicleId")
                        .IsUnique()
                        .HasDatabaseName("ix_agents_vehicle_id");

                    b.ToTable("agents", (string)null);

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Agents.Producer", b =>
                {
                    b.HasBaseType("AcoTerra.Core.Entities.Agents.Agent");

                    b.ToTable("agents", (string)null);

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Trucks.Truck", b =>
                {
                    b.HasBaseType("AcoTerra.Core.Entities.Vehicles.Vehicle");

                    b.ToTable("vehicles", (string)null);

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Freights.Freight", b =>
                {
                    b.HasOne("AcoTerra.Core.Entities.Trucks.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_freight_vehicle_truck_id");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Freights.Shipment", b =>
                {
                    b.HasOne("AcoTerra.Core.Entities.Agents.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_shipments_agents_customer_id");

                    b.HasOne("AcoTerra.Core.Entities.Freights.Freight", "Freight")
                        .WithMany("Shipments")
                        .HasForeignKey("FreightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shipments_freight_freight_id");

                    b.HasOne("AcoTerra.Core.Entities.Agents.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_shipments_agents_producer_id");

                    b.HasOne("AcoTerra.Core.Entities.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_shipments_products_product_id");

                    b.Navigation("Customer");

                    b.Navigation("Freight");

                    b.Navigation("Producer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.LegalDocuments.LegalDocument", b =>
                {
                    b.HasOne("AcoTerra.Core.Entities.Agents.Agent", null)
                        .WithMany("LegalDocuments")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_legal_documents_agents_agent_id");

                    b.HasOne("AcoTerra.Core.Entities.Vehicles.Vehicle", null)
                        .WithMany("LegalDocuments")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_legal_documents_vehicle_vehicle_id");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Trucks.Trailer", b =>
                {
                    b.HasOne("AcoTerra.Core.Entities.Trucks.Truck", null)
                        .WithOne("Trailer")
                        .HasForeignKey("AcoTerra.Core.Entities.Trucks.Trailer", "TruckId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_trailers_vehicle_truck_id");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.AdditionalEquipment", b =>
                {
                    b.HasOne("AcoTerra.Core.Entities.Vehicles.Vehicle", null)
                        .WithMany("AdditionalEquipment")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_additional_equipment_vehicle_vehicle_id");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.FinancialInformation", b =>
                {
                    b.HasOne("AcoTerra.Core.Entities.Vehicles.Vehicle", null)
                        .WithOne("FinancialInformation")
                        .HasForeignKey("AcoTerra.Core.Entities.Vehicles.FinancialInformation", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_financial_information_vehicles_id");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.MaintenanceHistory", b =>
                {
                    b.HasOne("AcoTerra.Core.Entities.Vehicles.Vehicle", null)
                        .WithMany("MaintenanceHistory")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_maintenance_history_vehicle_vehicle_id");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.TechnicalInformation", b =>
                {
                    b.HasOne("AcoTerra.Core.Entities.Vehicles.Vehicle", null)
                        .WithOne("TechnicalInformation")
                        .HasForeignKey("AcoTerra.Core.Entities.Vehicles.TechnicalInformation", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_technical_information_vehicles_id");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.TrafficFine", b =>
                {
                    b.HasOne("AcoTerra.Core.Entities.Vehicles.Vehicle", null)
                        .WithMany("TrafficFines")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_traffic_fines_vehicle_vehicle_id");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Agents.Driver", b =>
                {
                    b.HasOne("AcoTerra.Core.Entities.Vehicles.Vehicle", null)
                        .WithOne("Driver")
                        .HasForeignKey("AcoTerra.Core.Entities.Agents.Driver", "VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_agents_vehicle_vehicle_id");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Agents.Agent", b =>
                {
                    b.Navigation("LegalDocuments");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Freights.Freight", b =>
                {
                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Vehicles.Vehicle", b =>
                {
                    b.Navigation("AdditionalEquipment");

                    b.Navigation("Driver");

                    b.Navigation("FinancialInformation")
                        .IsRequired();

                    b.Navigation("LegalDocuments");

                    b.Navigation("MaintenanceHistory");

                    b.Navigation("TechnicalInformation")
                        .IsRequired();

                    b.Navigation("TrafficFines");
                });

            modelBuilder.Entity("AcoTerra.Core.Entities.Trucks.Truck", b =>
                {
                    b.Navigation("Trailer");
                });
#pragma warning restore 612, 618
        }
    }
}
