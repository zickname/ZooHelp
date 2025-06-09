using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooHelp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "volunteers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    experience_years = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    requisites_for_help = table.Column<string>(type: "jsonb", nullable: false),
                    social_networks = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_volunteers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "breeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    species_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_breeds", x => x.id);
                    table.ForeignKey(
                        name: "fk_breeds_species_species_id",
                        column: x => x.species_id,
                        principalTable: "species",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    breed_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_castrated = table.Column<bool>(type: "boolean", nullable: false),
                    is_vaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    help_status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    volunteer_entity_id = table.Column<Guid>(type: "uuid", nullable: true),
                    volunteer_entity_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    volunteer_entity_id2 = table.Column<Guid>(type: "uuid", nullable: true),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    apartment = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    house = table.Column<string>(type: "text", nullable: false),
                    street = table.Column<string>(type: "text", nullable: false),
                    zip_code = table.Column<string>(type: "text", nullable: false),
                    birth_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    color = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    health_information = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    height = table.Column<int>(type: "integer", maxLength: 100000, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    weight = table.Column<int>(type: "integer", maxLength: 500000, nullable: false),
                    requisites_for_help = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pets", x => x.id);
                    table.ForeignKey(
                        name: "fk_pets_breeds_breed_id",
                        column: x => x.breed_id,
                        principalTable: "breeds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pets_volunteers_volunteer_entity_id",
                        column: x => x.volunteer_entity_id,
                        principalTable: "volunteers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_pets_volunteers_volunteer_entity_id1",
                        column: x => x.volunteer_entity_id1,
                        principalTable: "volunteers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_pets_volunteers_volunteer_entity_id2",
                        column: x => x.volunteer_entity_id2,
                        principalTable: "volunteers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_pets_volunteers_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "volunteers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_breeds_species_id",
                table: "breeds",
                column: "species_id");

            migrationBuilder.CreateIndex(
                name: "ix_pets_breed_id",
                table: "pets",
                column: "breed_id");

            migrationBuilder.CreateIndex(
                name: "ix_pets_volunteer_entity_id",
                table: "pets",
                column: "volunteer_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_pets_volunteer_entity_id1",
                table: "pets",
                column: "volunteer_entity_id1");

            migrationBuilder.CreateIndex(
                name: "ix_pets_volunteer_entity_id2",
                table: "pets",
                column: "volunteer_entity_id2");

            migrationBuilder.CreateIndex(
                name: "ix_pets_volunteer_id",
                table: "pets",
                column: "volunteer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "breeds");

            migrationBuilder.DropTable(
                name: "volunteers");

            migrationBuilder.DropTable(
                name: "species");
        }
    }
}
