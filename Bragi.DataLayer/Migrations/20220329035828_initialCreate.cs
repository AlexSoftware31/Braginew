using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bragi.DataLayer.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    ShortName = table.Column<string>(maxLength: 35, nullable: true),
                    AgencyEnum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    OriginCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Observation = table.Column<string>(nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 500, nullable: true),
                    StateCode = table.Column<string>(maxLength: 100, nullable: true),
                    Iso2CountryCode = table.Column<string>(maxLength: 20, nullable: true),
                    Latitude = table.Column<string>(maxLength: 100, nullable: true),
                    Longitude = table.Column<string>(maxLength: 100, nullable: true),
                    State = table.Column<string>(maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Iso3 = table.Column<string>(maxLength: 4, nullable: true),
                    Iso2 = table.Column<string>(maxLength: 3, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    OfficialName = table.Column<string>(maxLength: 100, nullable: true),
                    Latitude = table.Column<string>(maxLength: 100, nullable: true),
                    Logitude = table.Column<string>(maxLength: 100, nullable: true),
                    Zoom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightMotives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Spanish = table.Column<string>(nullable: true),
                    English = table.Column<string>(nullable: true),
                    Russian = table.Column<string>(nullable: true),
                    Portuguese = table.Column<string>(nullable: true),
                    Italian = table.Column<string>(nullable: true),
                    German = table.Column<string>(nullable: true),
                    French = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightMotives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    ShortName = table.Column<string>(maxLength: 35, nullable: true),
                    SocialReason = table.Column<string>(maxLength: 150, nullable: true),
                    Coordinates = table.Column<string>(maxLength: 100, nullable: true),
                    GeoCode = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Spanish = table.Column<string>(maxLength: 150, nullable: true),
                    English = table.Column<string>(nullable: true),
                    Russian = table.Column<string>(nullable: true),
                    Portuguese = table.Column<string>(nullable: true),
                    Italian = table.Column<string>(nullable: true),
                    German = table.Column<string>(nullable: true),
                    French = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    GeoCode = table.Column<string>(nullable: true),
                    MacroRegion = table.Column<string>(maxLength: 40, nullable: true),
                    Region = table.Column<string>(maxLength: 40, nullable: true),
                    Province = table.Column<string>(maxLength: 40, nullable: true),
                    ToponomyName = table.Column<string>(maxLength: 350, nullable: true),
                    Municipalities = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocupations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Spanish = table.Column<string>(nullable: true),
                    English = table.Column<string>(nullable: true),
                    Russian = table.Column<string>(nullable: true),
                    Portuguese = table.Column<string>(nullable: true),
                    Italian = table.Column<string>(nullable: true),
                    German = table.Column<string>(nullable: true),
                    French = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    GeoCode = table.Column<string>(nullable: true),
                    MacroRegion = table.Column<string>(maxLength: 40, nullable: true),
                    Region = table.Column<string>(maxLength: 40, nullable: true),
                    Province = table.Column<string>(maxLength: 40, nullable: true),
                    ToponomyName = table.Column<string>(maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Method = table.Column<string>(maxLength: 15, nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    StatusCode = table.Column<string>(nullable: true),
                    RequestHeader = table.Column<string>(nullable: true),
                    RequestBody = table.Column<string>(nullable: true),
                    ResponseBody = table.Column<string>(nullable: true),
                    RequestMils = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    GeoCode = table.Column<string>(nullable: true),
                    MacroRegion = table.Column<string>(maxLength: 40, nullable: true),
                    Region = table.Column<string>(maxLength: 40, nullable: true),
                    Province = table.Column<string>(maxLength: 40, nullable: true),
                    ToponomyName = table.Column<string>(maxLength: 350, nullable: true),
                    Municipalities = table.Column<string>(maxLength: 40, nullable: true),
                    MunicipalDistrict = table.Column<string>(maxLength: 40, nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    Section = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: true),
                    StatusEnum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StepsEnum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Spanish = table.Column<string>(nullable: true),
                    English = table.Column<string>(nullable: true),
                    Russian = table.Column<string>(nullable: true),
                    Portuguese = table.Column<string>(nullable: true),
                    Italian = table.Column<string>(nullable: true),
                    German = table.Column<string>(nullable: true),
                    French = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AgencyId = table.Column<int>(nullable: false),
                    IsBooleanResponse = table.Column<bool>(nullable: false),
                    QuestionTypeId = table.Column<int>(nullable: false),
                    Spanish = table.Column<string>(nullable: true),
                    English = table.Column<string>(nullable: true),
                    Russian = table.Column<string>(nullable: true),
                    Portuguese = table.Column<string>(nullable: true),
                    Italian = table.Column<string>(nullable: true),
                    German = table.Column<string>(nullable: true),
                    French = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Companions = table.Column<int>(nullable: false, defaultValue: 0),
                    QuestionId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    StepId = table.Column<int>(nullable: false),
                    HasAcceptedTerms = table.Column<bool>(nullable: false),
                    WasAssisted = table.Column<bool>(nullable: false),
                    AssistantName = table.Column<string>(maxLength: 300, nullable: true),
                    AssistantRelation = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    InspectionCode = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    TransportationMethodId = table.Column<int>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsDominicanPort = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ports_Transportation_TransportationMethodId",
                        column: x => x.TransportationMethodId,
                        principalTable: "Transportation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    UserTypeId = table.Column<int>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    IsDisable = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationTokens_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PrincipalName = table.Column<string>(nullable: true),
                    Passport = table.Column<string>(nullable: true),
                    InOut = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Sequence = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etickets_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenericInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PermanentResidenceAdress = table.Column<string>(maxLength: 200, nullable: true),
                    CityOfResidence = table.Column<string>(maxLength: 150, nullable: true),
                    State = table.Column<string>(maxLength: 150, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 150, nullable: true),
                    CountryResidence = table.Column<string>(maxLength: 150, nullable: true),
                    Companions = table.Column<int>(nullable: false),
                    StopOverInCountries = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false),
                    IsArrival = table.Column<bool>(nullable: false),
                    TransportationMethodId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericInformations_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GenericInformations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GenericInformations_Transportation_TransportationMethodId",
                        column: x => x.TransportationMethodId,
                        principalTable: "Transportation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MigratoryInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Names = table.Column<string>(maxLength: 150, nullable: true),
                    LastNames = table.Column<string>(maxLength: 150, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Nationality = table.Column<string>(maxLength: 10, nullable: true),
                    BirthPlace = table.Column<string>(maxLength: 100, nullable: true),
                    PassportNumber = table.Column<string>(maxLength: 11, nullable: true),
                    DocumentIdNumber = table.Column<string>(maxLength: 25, nullable: true),
                    GeoCode = table.Column<string>(maxLength: 40, nullable: true),
                    Street = table.Column<string>(nullable: true),
                    MaritalStatusId = table.Column<int>(nullable: false),
                    FlightMotiveId = table.Column<int>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: false),
                    HotelId = table.Column<int>(nullable: true),
                    OcupationId = table.Column<int>(nullable: true),
                    AirlineId = table.Column<int>(nullable: true),
                    EmbarkationPortNavId = table.Column<int>(nullable: true),
                    DisembarkationPortNavId = table.Column<int>(nullable: true),
                    OriginPortNavId = table.Column<int>(nullable: true),
                    DaysOfStaying = table.Column<int>(nullable: false),
                    OriginPort = table.Column<string>(maxLength: 100, nullable: true),
                    OriginFlightNumber = table.Column<string>(maxLength: 100, nullable: true),
                    OriginFlightDate = table.Column<DateTime>(nullable: true),
                    EmbarkationPort = table.Column<string>(maxLength: 100, nullable: true),
                    EmbarcationFlightNumber = table.Column<string>(maxLength: 50, nullable: true),
                    EmbarcationDate = table.Column<DateTime>(nullable: true),
                    DisembarkationPort = table.Column<string>(maxLength: 100, nullable: true),
                    DisembarkationFligthNumber = table.Column<string>(nullable: true),
                    TransportationCompany = table.Column<string>(maxLength: 100, nullable: true),
                    SpecificFlightMotive = table.Column<string>(maxLength: 200, nullable: true),
                    IsPrincipal = table.Column<bool>(nullable: false),
                    HasCommonAddress = table.Column<bool>(nullable: false),
                    HasCommonHotel = table.Column<bool>(nullable: false),
                    IsParticularStaying = table.Column<bool>(nullable: false),
                    WillStayAtResort = table.Column<bool>(nullable: false),
                    ConfirmationNumber = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 40, nullable: true),
                    IsResident = table.Column<bool>(nullable: false),
                    ResidenceNumber = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MigratoryInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MigratoryInformations_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigratoryInformations_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MigratoryInformations_Ports_DisembarkationPortNavId",
                        column: x => x.DisembarkationPortNavId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigratoryInformations_Ports_EmbarkationPortNavId",
                        column: x => x.EmbarkationPortNavId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigratoryInformations_FlightMotives_FlightMotiveId",
                        column: x => x.FlightMotiveId,
                        principalTable: "FlightMotives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigratoryInformations_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigratoryInformations_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MigratoryInformations_Ocupations_OcupationId",
                        column: x => x.OcupationId,
                        principalTable: "Ocupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigratoryInformations_Ports_OriginPortNavId",
                        column: x => x.OriginPortNavId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomsInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false),
                    MigratoryInformationId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true),
                    ExceedsMoneyLimit = table.Column<bool>(nullable: false),
                    IsValuesOwner = table.Column<bool>(nullable: false),
                    HasAnimalsOrFood = table.Column<bool>(nullable: false),
                    HasMerchWithTaxValue = table.Column<bool>(nullable: false),
                    DeclaredOriginValue = table.Column<string>(nullable: true),
                    Ammount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    IsUnderAge = table.Column<bool>(nullable: false),
                    SenderName = table.Column<string>(nullable: true),
                    SenderLastName = table.Column<string>(nullable: true),
                    ReceiverName = table.Column<string>(nullable: true),
                    ReceiverLastName = table.Column<string>(nullable: true),
                    RelationShip = table.Column<string>(nullable: true),
                    WorthDestiny = table.Column<string>(nullable: true),
                    CurrencyMerchandiseId = table.Column<int>(nullable: true),
                    ValueOfMerchandise = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomsInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomsInformation_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomsInformation_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomsInformation_Currencies_CurrencyMerchandiseId",
                        column: x => x.CurrencyMerchandiseId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomsInformation_MigratoryInformations_MigratoryInformationId",
                        column: x => x.MigratoryInformationId,
                        principalTable: "MigratoryInformations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PublicHealths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false),
                    MigratoryInformationId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    SpecificSymptoms = table.Column<string>(maxLength: 400, nullable: true),
                    SymptomsDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicHealths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicHealths_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PublicHealths_MigratoryInformations_MigratoryInformationId",
                        column: x => x.MigratoryInformationId,
                        principalTable: "MigratoryInformations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaxReturnInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Cedula = table.Column<string>(maxLength: 11, nullable: true),
                    Telefono = table.Column<string>(maxLength: 10, nullable: true),
                    MigratoryInformationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxReturnInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxReturnInfos_MigratoryInformations_MigratoryInformationId",
                        column: x => x.MigratoryInformationId,
                        principalTable: "MigratoryInformations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeclaredMerch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomsInformationId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 600, nullable: true),
                    DollarValue = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclaredMerch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeclaredMerch_CustomsInformation_CustomsInformationId",
                        column: x => x.CustomsInformationId,
                        principalTable: "CustomsInformation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PublicHealthCountries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    PublicHealthId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicHealthCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicHealthCountries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PublicHealthCountries_PublicHealths_PublicHealthId",
                        column: x => x.PublicHealthId,
                        principalTable: "PublicHealths",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PublicHealthStopOvers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    PublicHealthId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicHealthStopOvers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicHealthStopOvers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PublicHealthStopOvers_PublicHealths_PublicHealthId",
                        column: x => x.PublicHealthId,
                        principalTable: "PublicHealths",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: true),
                    PublicHealthId = table.Column<int>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false),
                    TextReponse = table.Column<string>(nullable: true),
                    BoolResponse = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionResponses_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionResponses_PublicHealths_PublicHealthId",
                        column: x => x.PublicHealthId,
                        principalTable: "PublicHealths",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestionResponses_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StatusId",
                table: "Applications",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StepId",
                table: "Applications",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationTokens_ApplicationId",
                table: "ApplicationTokens",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTypeId",
                table: "AspNetUsers",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsInformation_ApplicationId",
                table: "CustomsInformation",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsInformation_CurrencyId",
                table: "CustomsInformation",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsInformation_CurrencyMerchandiseId",
                table: "CustomsInformation",
                column: "CurrencyMerchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsInformation_MigratoryInformationId",
                table: "CustomsInformation",
                column: "MigratoryInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeclaredMerch_CustomsInformationId",
                table: "DeclaredMerch",
                column: "CustomsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Etickets_ApplicationId",
                table: "Etickets",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericInformations_ApplicationId",
                table: "GenericInformations",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenericInformations_CityId",
                table: "GenericInformations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericInformations_TransportationMethodId",
                table: "GenericInformations",
                column: "TransportationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_MigratoryInformations_AirlineId",
                table: "MigratoryInformations",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_MigratoryInformations_ApplicationId",
                table: "MigratoryInformations",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MigratoryInformations_DisembarkationPortNavId",
                table: "MigratoryInformations",
                column: "DisembarkationPortNavId");

            migrationBuilder.CreateIndex(
                name: "IX_MigratoryInformations_EmbarkationPortNavId",
                table: "MigratoryInformations",
                column: "EmbarkationPortNavId");

            migrationBuilder.CreateIndex(
                name: "IX_MigratoryInformations_FlightMotiveId",
                table: "MigratoryInformations",
                column: "FlightMotiveId");

            migrationBuilder.CreateIndex(
                name: "IX_MigratoryInformations_HotelId",
                table: "MigratoryInformations",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_MigratoryInformations_MaritalStatusId",
                table: "MigratoryInformations",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MigratoryInformations_OcupationId",
                table: "MigratoryInformations",
                column: "OcupationId");

            migrationBuilder.CreateIndex(
                name: "IX_MigratoryInformations_OriginPortNavId",
                table: "MigratoryInformations",
                column: "OriginPortNavId");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_TransportationMethodId",
                table: "Ports",
                column: "TransportationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicHealthCountries_CountryId",
                table: "PublicHealthCountries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicHealthCountries_PublicHealthId",
                table: "PublicHealthCountries",
                column: "PublicHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicHealths_ApplicationId",
                table: "PublicHealths",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicHealths_MigratoryInformationId",
                table: "PublicHealths",
                column: "MigratoryInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PublicHealthStopOvers_CountryId",
                table: "PublicHealthStopOvers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicHealthStopOvers_PublicHealthId",
                table: "PublicHealthStopOvers",
                column: "PublicHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_ApplicationId",
                table: "QuestionResponses",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_PublicHealthId",
                table: "QuestionResponses",
                column: "PublicHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_QuestionId",
                table: "QuestionResponses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AgencyId",
                table: "Questions",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionTypeId",
                table: "Questions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxReturnInfos_MigratoryInformationId",
                table: "TaxReturnInfos",
                column: "MigratoryInformationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeclaredMerch");

            migrationBuilder.DropTable(
                name: "Etickets");

            migrationBuilder.DropTable(
                name: "GenericInformations");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "PublicHealthCountries");

            migrationBuilder.DropTable(
                name: "PublicHealthStopOvers");

            migrationBuilder.DropTable(
                name: "QuestionResponses");

            migrationBuilder.DropTable(
                name: "RequestLogs");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "TaxReturnInfos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CustomsInformation");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "PublicHealths");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "MigratoryInformations");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "FlightMotives");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "Ocupations");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Transportation");
        }
    }
}
