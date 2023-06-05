using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Commerce.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productid = table.Column<int>(name: "product_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productname = table.Column<string>(name: "product_name", type: "text", nullable: false),
                    productdescription = table.Column<string>(name: "product_description", type: "text", nullable: false),
                    productvalue = table.Column<decimal>(name: "product_value", type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productid);
                });

            migrationBuilder.CreateTable(
                name: "Sallers",
                columns: table => new
                {
                    sallerid = table.Column<int>(name: "saller_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sallernamesaller = table.Column<string>(name: "saller_name_saller", type: "text", nullable: false),
                    sallercpf = table.Column<string>(name: "saller_cpf", type: "text", nullable: false),
                    salleremail = table.Column<string>(name: "saller_email", type: "text", nullable: false),
                    salleractive = table.Column<bool>(name: "saller_active", type: "boolean", nullable: false),
                    sallertelephone = table.Column<string>(name: "saller_telephone", type: "text", nullable: false),
                    sallercreatedat = table.Column<DateTime>(name: "saller_created_at", type: "timestamp with time zone", nullable: false),
                    sallerupdatedat = table.Column<DateTime>(name: "saller_updated_at", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sallers", x => x.sallerid);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    saleid = table.Column<int>(name: "sale_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    salename = table.Column<string>(name: "sale_name", type: "text", nullable: false),
                    sallerid = table.Column<int>(name: "saller_id", type: "integer", nullable: true),
                    productid = table.Column<int>(name: "product_id", type: "integer", nullable: true),
                    saleproductvaluetotal = table.Column<decimal>(name: "sale_product_value_total", type: "numeric", nullable: false),
                    salestatus = table.Column<int>(name: "sale_status", type: "integer", nullable: true),
                    salecreatedat = table.Column<DateTime>(name: "sale_created_at", type: "timestamp with time zone", nullable: false),
                    saleupdatedat = table.Column<DateTime>(name: "sale_updated_at", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.saleid);
                    table.ForeignKey(
                        name: "FK_Sales_Products_product_id",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_Sales_Sallers_saller_id",
                        column: x => x.sallerid,
                        principalTable: "Sallers",
                        principalColumn: "saller_id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "product_id", "product_description", "product_name", "product_value" },
                values: new object[,]
                {
                    { 1, "Carne Bovina para Churrasco", "Carne Bovina", 12m },
                    { 2, "Batata Palha - 1Kg", "Batata Palha - 1Kg", 29m },
                    { 3, "Queijo Parmesão - 5,5Kg", "Queijo Parmesão - 5,5Kg", 300m }
                });

            migrationBuilder.InsertData(
                table: "Sallers",
                columns: new[] { "saller_id", "saller_active", "saller_cpf", "saller_created_at", "saller_email", "saller_name_saller", "saller_telephone", "saller_updated_at" },
                values: new object[,]
                {
                    { 1, true, "000.000.000-00", new DateTime(2023, 6, 5, 2, 21, 24, 540, DateTimeKind.Utc).AddTicks(5334), "string", "Person", "0000000-0000", new DateTime(2023, 6, 5, 2, 21, 24, 540, DateTimeKind.Utc).AddTicks(5335) },
                    { 2, true, "000.000.000-00", new DateTime(2023, 6, 5, 2, 21, 24, 540, DateTimeKind.Utc).AddTicks(5336), "string", "Roberto", "0000000-0000", new DateTime(2023, 6, 5, 2, 21, 24, 540, DateTimeKind.Utc).AddTicks(5337) },
                    { 3, true, "000.000.000-00", new DateTime(2023, 6, 5, 2, 21, 24, 540, DateTimeKind.Utc).AddTicks(5337), "string", "Gabriela", "0000000-0000", new DateTime(2023, 6, 5, 2, 21, 24, 540, DateTimeKind.Utc).AddTicks(5338) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_product_id",
                table: "Sales",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_saller_id",
                table: "Sales",
                column: "saller_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sallers");
        }
    }
}
