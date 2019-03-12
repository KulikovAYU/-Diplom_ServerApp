using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FC_EMDB.Migrations.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbonementStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DaysCount = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonementStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbonementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Human",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Family = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirdth = table.Column<DateTime>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PasportData = table.Column<string>(nullable: true),
                    Login = table.Column<int>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Employee_Login = table.Column<string>(maxLength: 50, nullable: true),
                    Employee_PasswordHash = table.Column<string>(maxLength: 50, nullable: true),
                    Desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Human", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    TrainingName = table.Column<string>(nullable: true),
                    IsFinished = table.Column<bool>(nullable: false),
                    LevelName = table.Column<string>(nullable: true),
                    mDescription = table.Column<string>(nullable: true),
                    IsReplaced = table.Column<bool>(nullable: false),
                    IsMustPay = table.Column<bool>(nullable: false),
                    ProgramType = table.Column<string>(nullable: true),
                    IsNewTraining = table.Column<bool>(nullable: false),
                    Ispopular = table.Column<bool>(nullable: false),
                    PlacesCount = table.Column<int>(nullable: false),
                    FreePlacesCount = table.Column<int>(nullable: false),
                    BusyPlacesCount = table.Column<int>(nullable: false),
                    GymId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abonements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    DateOfRegistration = table.Column<DateTime>(nullable: false),
                    CountDays = table.Column<DateTime>(nullable: false),
                    AbonementStatusId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    AbonementTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abonements_AbonementStatuses_AbonementStatusId",
                        column: x => x.AbonementStatusId,
                        principalTable: "AbonementStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abonements_AbonementTypes_AbonementTypeId",
                        column: x => x.AbonementTypeId,
                        principalTable: "AbonementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abonements_Human_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Human",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoachTrainings",
                columns: table => new
                {
                    CoachId = table.Column<int>(nullable: false),
                    TrainingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachTrainings", x => new { x.CoachId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_CoachTrainings_Human_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Human",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachTrainings_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreRegistrations",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    AbonementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreRegistrations", x => new { x.TrainingId, x.AbonementId });
                    table.ForeignKey(
                        name: "FK_PreRegistrations_Abonements_AbonementId",
                        column: x => x.AbonementId,
                        principalTable: "Abonements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreRegistrations_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingAbonements",
                columns: table => new
                {
                    ComeInTime = table.Column<DateTime>(nullable: false),
                    ComeOutTime = table.Column<DateTime>(nullable: false),
                    TrainingId = table.Column<int>(nullable: false),
                    AbonementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingAbonements", x => new { x.TrainingId, x.AbonementId });
                    table.ForeignKey(
                        name: "FK_TrainingAbonements_Abonements_AbonementId",
                        column: x => x.AbonementId,
                        principalTable: "Abonements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingAbonements_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonements_AbonementStatusId",
                table: "Abonements",
                column: "AbonementStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Abonements_AbonementTypeId",
                table: "Abonements",
                column: "AbonementTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Abonements_ClientId",
                table: "Abonements",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoachTrainings_TrainingId",
                table: "CoachTrainings",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_PreRegistrations_AbonementId",
                table: "PreRegistrations",
                column: "AbonementId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingAbonements_AbonementId",
                table: "TrainingAbonements",
                column: "AbonementId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_GymId",
                table: "Trainings",
                column: "GymId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachTrainings");

            migrationBuilder.DropTable(
                name: "PreRegistrations");

            migrationBuilder.DropTable(
                name: "TrainingAbonements");

            migrationBuilder.DropTable(
                name: "Abonements");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "AbonementStatuses");

            migrationBuilder.DropTable(
                name: "AbonementTypes");

            migrationBuilder.DropTable(
                name: "Human");

            migrationBuilder.DropTable(
                name: "Gyms");
        }
    }
}
