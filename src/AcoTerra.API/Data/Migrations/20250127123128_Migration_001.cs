using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcoTerra.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "additional_equipment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    cost = table.Column<decimal>(type: "TEXT", nullable: false),
                    condition = table.Column<string>(type: "TEXT", nullable: false),
                    vehicle_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_additional_equipment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    identification_type = table.Column<string>(type: "TEXT", nullable: false),
                    identification_number = table.Column<string>(type: "TEXT", nullable: false),
                    phone_number = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    identification_type = table.Column<string>(type: "TEXT", nullable: false),
                    identification_number = table.Column<string>(type: "TEXT", nullable: false),
                    phone_number = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    employment_status = table.Column<string>(type: "TEXT", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    emergency_contacts = table.Column<string>(type: "TEXT", nullable: true),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "financial_information",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    purchase_price = table.Column<decimal>(type: "TEXT", nullable: false),
                    financed = table.Column<bool>(type: "INTEGER", nullable: false),
                    installments = table.Column<int>(type: "INTEGER", nullable: false),
                    outstanding_balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    vehicle_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financial_information", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "legal_documents",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    document = table.Column<string>(type: "TEXT", nullable: false),
                    expiration_date = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    vehicle_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    actor_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legal_documents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maintenance_history",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    cost = table.Column<decimal>(type: "TEXT", nullable: false),
                    tires = table.Column<string>(type: "TEXT", nullable: true),
                    document = table.Column<string>(type: "TEXT", nullable: true),
                    vehicle_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_maintenance_history", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "producers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    identification_type = table.Column<string>(type: "TEXT", nullable: false),
                    identification_number = table.Column<string>(type: "TEXT", nullable: false),
                    phone_number = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    price_per_package = table.Column<decimal>(type: "TEXT", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "technical_information",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    current_mileage = table.Column<double>(type: "REAL", nullable: false),
                    fuel_type = table.Column<string>(type: "TEXT", nullable: false),
                    average_consumption = table.Column<double>(type: "REAL", nullable: false),
                    tank_size = table.Column<double>(type: "REAL", nullable: false),
                    vehicle_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_technical_information", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "traffic_fines",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    violation = table.Column<string>(type: "TEXT", nullable: false),
                    amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    date_issued = table.Column<DateTime>(type: "TEXT", nullable: false),
                    paid_at = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    document = table.Column<string>(type: "TEXT", nullable: true),
                    vehicle_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_traffic_fines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trucks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    license_plate = table.Column<string>(type: "TEXT", nullable: false),
                    brand = table.Column<string>(type: "TEXT", nullable: false),
                    model = table.Column<string>(type: "TEXT", nullable: false),
                    manufacturing_year = table.Column<int>(type: "INTEGER", nullable: false),
                    chassis_number = table.Column<string>(type: "TEXT", nullable: false),
                    engine_number = table.Column<string>(type: "TEXT", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trucks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "freight",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    number = table.Column<string>(type: "TEXT", nullable: false),
                    origin = table.Column<string>(type: "TEXT", nullable: false),
                    destination = table.Column<string>(type: "TEXT", nullable: false),
                    total_quantity = table.Column<double>(type: "REAL", nullable: false),
                    total_price = table.Column<decimal>(type: "TEXT", nullable: false),
                    remarks = table.Column<string>(type: "TEXT", nullable: true),
                    vehicle_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    employee_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_freight", x => x.id);
                    table.ForeignKey(
                        name: "fk_freight_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trailers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    license_plate = table.Column<string>(type: "TEXT", nullable: false),
                    capacity = table.Column<double>(type: "REAL", nullable: false),
                    truck_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trailers", x => x.id);
                    table.ForeignKey(
                        name: "fk_trailers_vehicle_truck_id",
                        column: x => x.truck_id,
                        principalTable: "trucks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "shipments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    number = table.Column<string>(type: "TEXT", nullable: false),
                    origin_latitude = table.Column<double>(type: "REAL", nullable: false),
                    origin_longitude = table.Column<double>(type: "REAL", nullable: false),
                    destination_latitude = table.Column<double>(type: "REAL", nullable: false),
                    destination_longitude = table.Column<double>(type: "REAL", nullable: false),
                    quantity = table.Column<double>(type: "REAL", nullable: false),
                    price = table.Column<decimal>(type: "TEXT", nullable: false),
                    freight_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    customer_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shipments", x => x.id);
                    table.ForeignKey(
                        name: "fk_shipments_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_shipments_freight_freight_id",
                        column: x => x.freight_id,
                        principalTable: "freight",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipments_producers",
                columns: table => new
                {
                    shipment_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    producer_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shipments_producers", x => new { x.shipment_id, x.producer_id });
                    table.ForeignKey(
                        name: "fk_shipments_producers_producer_producer_id",
                        column: x => x.producer_id,
                        principalTable: "producers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_shipments_producers_shipments_shipment_id",
                        column: x => x.shipment_id,
                        principalTable: "shipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipments_products",
                columns: table => new
                {
                    shipment_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    product_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shipments_products", x => new { x.shipment_id, x.product_id });
                    table.ForeignKey(
                        name: "fk_shipments_products_product_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_shipments_products_shipments_shipment_id",
                        column: x => x.shipment_id,
                        principalTable: "shipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_additional_equipment_vehicle_id",
                table: "additional_equipment",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_financial_information_vehicle_id",
                table: "financial_information",
                column: "vehicle_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_freight_employee_id",
                table: "freight",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "ix_freight_vehicle_id",
                table: "freight",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_legal_documents_actor_id",
                table: "legal_documents",
                column: "actor_id");

            migrationBuilder.CreateIndex(
                name: "ix_legal_documents_vehicle_id",
                table: "legal_documents",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_maintenance_history_vehicle_id",
                table: "maintenance_history",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_shipments_customer_id",
                table: "shipments",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_shipments_freight_id",
                table: "shipments",
                column: "freight_id");

            migrationBuilder.CreateIndex(
                name: "ix_shipments_producers_producer_id",
                table: "shipments_producers",
                column: "producer_id");

            migrationBuilder.CreateIndex(
                name: "ix_shipments_products_product_id",
                table: "shipments_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_technical_information_vehicle_id",
                table: "technical_information",
                column: "vehicle_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_traffic_fines_vehicle_id",
                table: "traffic_fines",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_trailers_truck_id",
                table: "trailers",
                column: "truck_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "additional_equipment");

            migrationBuilder.DropTable(
                name: "financial_information");

            migrationBuilder.DropTable(
                name: "legal_documents");

            migrationBuilder.DropTable(
                name: "maintenance_history");

            migrationBuilder.DropTable(
                name: "shipments_producers");

            migrationBuilder.DropTable(
                name: "shipments_products");

            migrationBuilder.DropTable(
                name: "technical_information");

            migrationBuilder.DropTable(
                name: "traffic_fines");

            migrationBuilder.DropTable(
                name: "trailers");

            migrationBuilder.DropTable(
                name: "producers");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "shipments");

            migrationBuilder.DropTable(
                name: "trucks");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "freight");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
