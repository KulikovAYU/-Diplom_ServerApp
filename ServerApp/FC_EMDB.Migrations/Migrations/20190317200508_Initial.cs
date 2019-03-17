using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FC_EMDB.Migrations.Migrations
{
    public partial class Initial : Migration
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
                    DaysFreezeCount = table.Column<DateTime>(nullable: false)
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
                name: "ProgramType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    IsReplaced = table.Column<bool>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
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
                    AbonementNumber = table.Column<int>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    AbonementDateOfRegistration = table.Column<DateTime>(nullable: true),
                    AbonementActionTime = table.Column<DateTime>(nullable: true),
                    AbonementStatusId = table.Column<int>(nullable: true),
                    AbonementTypeId = table.Column<int>(nullable: true),
                    Login = table.Column<string>(maxLength: 50, nullable: true),
                    Employee_PasswordHash = table.Column<string>(maxLength: 50, nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Human", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Human_AbonementStatuses_AbonementStatusId",
                        column: x => x.AbonementStatusId,
                        principalTable: "AbonementStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Human_AbonementTypes_AbonementTypeId",
                        column: x => x.AbonementTypeId,
                        principalTable: "AbonementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Human_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrainingName = table.Column<string>(nullable: true),
                    TrainingDescription = table.Column<string>(nullable: true),
                    IsMustPay = table.Column<bool>(nullable: false),
                    IsNewTraining = table.Column<bool>(nullable: false),
                    Ispopular = table.Column<bool>(nullable: false),
                    LevelId = table.Column<int>(nullable: true),
                    ProgramTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingData_TrainingLevel_LevelId",
                        column: x => x.LevelId,
                        principalTable: "TrainingLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingData_ProgramType_ProgramTypeId",
                        column: x => x.ProgramTypeId,
                        principalTable: "ProgramType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "TrainingClients",
                columns: table => new
                {
                    ComeInTime = table.Column<DateTime>(nullable: false),
                    ComeOutTime = table.Column<DateTime>(nullable: false),
                    IsComeIn = table.Column<bool>(nullable: false),
                    TrainingId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingAbonements", x => new { x.TrainingId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_TrainingAbonements_Human_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Human",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingAbonements_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplcedTraining",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    TrainingDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplcedTraining", x => new { x.TrainingDataId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_ReplcedTraining_TrainingData_TrainingDataId",
                        column: x => x.TrainingDataId,
                        principalTable: "TrainingData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplcedTraining_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDataTraining",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false),
                    TrainingDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDataTraining", x => new { x.TrainingDataId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_TrainingDataTraining_TrainingData_TrainingDataId",
                        column: x => x.TrainingDataId,
                        principalTable: "TrainingData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingDataTraining_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachTrainings_TrainingId",
                table: "CoachTrainings",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Human_AbonementStatusId",
                table: "Human",
                column: "AbonementStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Human_AbonementTypeId",
                table: "Human",
                column: "AbonementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Human_RoleId",
                table: "Human",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplcedTraining_TrainingId",
                table: "ReplcedTraining",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingAbonements_ClientId",
                table: "TrainingClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingData_LevelId",
                table: "TrainingData",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingData_ProgramTypeId",
                table: "TrainingData",
                column: "ProgramTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDataTraining_TrainingId",
                table: "TrainingDataTraining",
                column: "TrainingId");

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
                name: "ReplcedTraining");

            migrationBuilder.DropTable(
                name: "TrainingClients");

            migrationBuilder.DropTable(
                name: "TrainingDataTraining");

            migrationBuilder.DropTable(
                name: "Human");

            migrationBuilder.DropTable(
                name: "TrainingData");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "AbonementStatuses");

            migrationBuilder.DropTable(
                name: "AbonementTypes");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "TrainingLevel");

            migrationBuilder.DropTable(
                name: "ProgramType");

            migrationBuilder.DropTable(
                name: "Gyms");
        }
    }
}
