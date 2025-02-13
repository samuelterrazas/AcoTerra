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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    vehicle_id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    cost = table.Column<decimal>(type: "TEXT", nullable: false),
                    condition = table.Column<int>(type: "INTEGER", nullable: false),
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    identification_type = table.Column<int>(type: "INTEGER", nullable: false),
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
                name: "drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    identification_type = table.Column<int>(type: "INTEGER", nullable: false),
                    identification_number = table.Column<string>(type: "TEXT", nullable: false),
                    phone_number = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    employment_status = table.Column<int>(type: "INTEGER", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    emergency_contact = table.Column<string>(type: "TEXT", nullable: true),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "financial_information",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    purchase_price = table.Column<decimal>(type: "TEXT", nullable: false),
                    financed = table.Column<bool>(type: "INTEGER", nullable: false),
                    installments = table.Column<int>(type: "INTEGER", nullable: false),
                    outstanding_balance = table.Column<decimal>(type: "TEXT", nullable: false),
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    vehicle_id = table.Column<int>(type: "INTEGER", nullable: true),
                    actor_id = table.Column<int>(type: "INTEGER", nullable: true),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    document = table.Column<string>(type: "TEXT", nullable: false),
                    expiration_date = table.Column<DateOnly>(type: "TEXT", nullable: true),
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    vehicle_id = table.Column<int>(type: "INTEGER", nullable: false),
                    date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    cost = table.Column<decimal>(type: "TEXT", nullable: false),
                    document = table.Column<string>(type: "TEXT", nullable: true),
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    identification_type = table.Column<int>(type: "INTEGER", nullable: false),
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    packaging_type = table.Column<int>(type: "INTEGER", nullable: false),
                    weight = table.Column<decimal>(type: "TEXT", nullable: false),
                    price = table.Column<decimal>(type: "TEXT", nullable: false),
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    current_mileage = table.Column<decimal>(type: "TEXT", nullable: false),
                    fuel_type = table.Column<int>(type: "INTEGER", nullable: false),
                    average_consumption = table.Column<decimal>(type: "TEXT", nullable: false),
                    tank_size = table.Column<decimal>(type: "TEXT", nullable: false),
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    vehicle_id = table.Column<int>(type: "INTEGER", nullable: false),
                    violation = table.Column<string>(type: "TEXT", nullable: false),
                    amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    date_issued = table.Column<DateTime>(type: "TEXT", nullable: false),
                    paid_at = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    document = table.Column<string>(type: "TEXT", nullable: true),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_traffic_fines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trailers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    license_plate = table.Column<string>(type: "TEXT", nullable: false),
                    capacity = table.Column<decimal>(type: "TEXT", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trailers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trucks",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    license_plate = table.Column<string>(type: "TEXT", nullable: false),
                    brand = table.Column<string>(type: "TEXT", nullable: false),
                    model = table.Column<string>(type: "TEXT", nullable: false),
                    manufacturing_year = table.Column<int>(type: "INTEGER", nullable: false),
                    chassis_number = table.Column<string>(type: "TEXT", nullable: false),
                    engine_number = table.Column<string>(type: "TEXT", nullable: false),
                    driver_id = table.Column<int>(type: "INTEGER", nullable: true),
                    trailer_id = table.Column<int>(type: "INTEGER", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trucks", x => x.id);
                    table.ForeignKey(
                        name: "FK_trucks_drivers_driver_id",
                        column: x => x.driver_id,
                        principalTable: "drivers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_trucks_trailers_trailer_id",
                        column: x => x.trailer_id,
                        principalTable: "trailers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "freight",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    number = table.Column<string>(type: "TEXT", nullable: false),
                    truck_id = table.Column<int>(type: "INTEGER", nullable: false),
                    loading_date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    unloading_date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    total_shipment_quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    total_shipment_weight = table.Column<decimal>(type: "TEXT", nullable: false),
                    total_shipment_amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    remarks = table.Column<string>(type: "TEXT", nullable: true),
                    last_modified_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    last_modified_by = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_freight", x => x.id);
                    table.ForeignKey(
                        name: "fk_freight_trucks_truck_id",
                        column: x => x.truck_id,
                        principalTable: "trucks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "shipments",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    freight_id = table.Column<int>(type: "INTEGER", nullable: false),
                    number = table.Column<string>(type: "TEXT", nullable: false),
                    producer_id = table.Column<int>(type: "INTEGER", nullable: false),
                    product_id = table.Column<int>(type: "INTEGER", nullable: false),
                    total_product_quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    total_product_weight = table.Column<decimal>(type: "TEXT", nullable: false),
                    total_product_amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    customer_id = table.Column<int>(type: "INTEGER", nullable: false),
                    location = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
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
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_shipments_freight_freight_id",
                        column: x => x.freight_id,
                        principalTable: "freight",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_shipments_producer_producer_id",
                        column: x => x.producer_id,
                        principalTable: "producers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_shipments_product_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_additional_equipment_vehicle_id",
                table: "additional_equipment",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_freight_truck_id",
                table: "freight",
                column: "truck_id");

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
                name: "ix_shipments_producer_id",
                table: "shipments",
                column: "producer_id");

            migrationBuilder.CreateIndex(
                name: "ix_shipments_product_id",
                table: "shipments",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_traffic_fines_vehicle_id",
                table: "traffic_fines",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_trucks_driver_id",
                table: "trucks",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "ix_trucks_trailer_id",
                table: "trucks",
                column: "trailer_id",
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
                name: "shipments");

            migrationBuilder.DropTable(
                name: "technical_information");

            migrationBuilder.DropTable(
                name: "traffic_fines");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "freight");

            migrationBuilder.DropTable(
                name: "producers");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "trucks");

            migrationBuilder.DropTable(
                name: "drivers");

            migrationBuilder.DropTable(
                name: "trailers");
        }
    }
}
