using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.DATA.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ref");

            migrationBuilder.EnsureSchema(
                name: "as");

            migrationBuilder.EnsureSchema(
                name: "gmap");

            migrationBuilder.EnsureSchema(
                name: "gen");

            migrationBuilder.EnsureSchema(
                name: "plan");

            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.CreateTable(
                name: "ACCOUNT_TYPE",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AsEvolutionDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsEvolutionDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ASSET",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PATH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EXTENSION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ID_FAMILY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSET", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BaseChartData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseChartData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GMAP_ADMINISTRATIVE_AREA_LEVEL_1",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_ADMINISTRATIVE_AREA_LEVEL_1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMAP_ADMINISTRATIVE_AREA_LEVEL_2",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_ADMINISTRATIVE_AREA_LEVEL_2", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMAP_COUNTRY",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_COUNTRY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMAP_LOCALITY",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_LOCALITY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMAP_NEIGHBORHOOD",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_NEIGHBORHOOD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMAP_POSTAL_CODE",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_POSTAL_CODE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMAP_ROUTE",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_ROUTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMAP_STREET_NUMBER",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_STREET_NUMBER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMAP_SUBLOCALITY_LEVEL_1",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_SUBLOCALITY_LEVEL_1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMAP_SUBLOCALITY_LEVEL_2",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_SUBLOCALITY_LEVEL_2", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMAP_TYPE",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KEYWORD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MONTH",
                schema: "gen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LANGUAGE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LABEL_LONG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LABEL_SHORT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MONTH", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MOVEMENT",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVEMENT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OPERATION_METHOD",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_METHOD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OPERATION_PLACE",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CODE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_PLACE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PLAN",
                schema: "plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    YEAR = table.Column<int>(type: "int", nullable: false),
                    COLOR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REFERENCE_TABLE",
                schema: "plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TABLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFERENCE_TABLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SelectNameValueDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectNameValueDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoldeDto",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Solde = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "STATE_ASIF",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATE_ASIF", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_PREFERENCE",
                schema: "user",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    THEME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SCHEME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LAYOUT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LANGUAGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AVATAR_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BANNER_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PREFERENCE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "V_PLAN_GLOBAL",
                schema: "plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ACCOUNT = table.Column<int>(type: "int", nullable: true),
                    ID_MOVEMENT = table.Column<int>(type: "int", nullable: true),
                    ID_ACCOUNT_STATEMENT = table.Column<int>(type: "int", nullable: true),
                    DATE_INTEGRATION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AMOUNT_OPERATION = table.Column<double>(type: "float", nullable: true),
                    PREVIEW_AMOUNT = table.Column<double>(type: "float", nullable: true),
                    ID_PLAN = table.Column<int>(type: "int", nullable: true),
                    ID_PLAN_POSTE = table.Column<int>(type: "int", nullable: true),
                    PLAN_POSTE_LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_POSTE = table.Column<int>(type: "int", nullable: true),
                    ID_REFERENCE = table.Column<int>(type: "int", nullable: true),
                    LABEL_REFERENCE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MONTH = table.Column<int>(type: "int", nullable: true),
                    YEAR = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_PLAN_GLOBAL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BANK_FAMILY",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ASSET = table.Column<int>(type: "int", nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    LABEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_FAMILY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BANK_FAMILY_ASSET_ID_ASSET",
                        column: x => x.ID_ASSET,
                        principalSchema: "ref",
                        principalTable: "ASSET",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GMAP_ADDRESS",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_1 = table.Column<int>(type: "int", nullable: false),
                    ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_2 = table.Column<int>(type: "int", nullable: false),
                    ID_GMAP_COUNTRY = table.Column<int>(type: "int", nullable: false),
                    ID_GMAP_LOCALITY = table.Column<int>(type: "int", nullable: false),
                    ID_GMAP_NEIGHBORHOOD = table.Column<int>(type: "int", nullable: false),
                    ID_GMAP_POSTAL_CODE = table.Column<int>(type: "int", nullable: false),
                    ID_GMAP_ROUTE = table.Column<int>(type: "int", nullable: false),
                    ID_GMAP_STREET_NUMBER = table.Column<int>(type: "int", nullable: false),
                    ID_GMAP_SUBLOCALITY_LEVEL_1 = table.Column<int>(type: "int", nullable: false),
                    ID_GMAP_SUBLOCALITY_LEVEL_2 = table.Column<int>(type: "int", nullable: false),
                    FORMATTED_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LAT = table.Column<double>(type: "float", nullable: false),
                    LNG = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_ADDRESS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_GMAP_ADMINISTRATIVE_AREA_LEVEL_1_ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_1",
                        column: x => x.ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_1,
                        principalSchema: "gmap",
                        principalTable: "GMAP_ADMINISTRATIVE_AREA_LEVEL_1",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_GMAP_ADMINISTRATIVE_AREA_LEVEL_2_ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_1",
                        column: x => x.ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_1,
                        principalSchema: "gmap",
                        principalTable: "GMAP_ADMINISTRATIVE_AREA_LEVEL_2",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_GMAP_COUNTRY_ID_GMAP_COUNTRY",
                        column: x => x.ID_GMAP_COUNTRY,
                        principalSchema: "gmap",
                        principalTable: "GMAP_COUNTRY",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_GMAP_LOCALITY_ID_GMAP_LOCALITY",
                        column: x => x.ID_GMAP_LOCALITY,
                        principalSchema: "gmap",
                        principalTable: "GMAP_LOCALITY",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_GMAP_NEIGHBORHOOD_ID_GMAP_NEIGHBORHOOD",
                        column: x => x.ID_GMAP_NEIGHBORHOOD,
                        principalSchema: "gmap",
                        principalTable: "GMAP_NEIGHBORHOOD",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_GMAP_POSTAL_CODE_ID_GMAP_POSTAL_CODE",
                        column: x => x.ID_GMAP_POSTAL_CODE,
                        principalSchema: "gmap",
                        principalTable: "GMAP_POSTAL_CODE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_GMAP_ROUTE_ID_GMAP_ROUTE",
                        column: x => x.ID_GMAP_ROUTE,
                        principalSchema: "gmap",
                        principalTable: "GMAP_ROUTE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_GMAP_STREET_NUMBER_ID_GMAP_STREET_NUMBER",
                        column: x => x.ID_GMAP_STREET_NUMBER,
                        principalSchema: "gmap",
                        principalTable: "GMAP_STREET_NUMBER",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_GMAP_SUBLOCALITY_LEVEL_1_ID_GMAP_SUBLOCALITY_LEVEL_1",
                        column: x => x.ID_GMAP_SUBLOCALITY_LEVEL_1,
                        principalSchema: "gmap",
                        principalTable: "GMAP_SUBLOCALITY_LEVEL_1",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_GMAP_SUBLOCALITY_LEVEL_2_ID_GMAP_SUBLOCALITY_LEVEL_2",
                        column: x => x.ID_GMAP_SUBLOCALITY_LEVEL_2,
                        principalSchema: "gmap",
                        principalTable: "GMAP_SUBLOCALITY_LEVEL_2",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GMAP_TYPE_LANGUAGE",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_GMAP_TYPE = table.Column<int>(type: "int", nullable: false),
                    LANGUAGE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_TYPE_LANGUAGE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GMAP_TYPE_LANGUAGE_GMAP_TYPE_ID_GMAP_TYPE",
                        column: x => x.ID_GMAP_TYPE,
                        principalSchema: "gmap",
                        principalTable: "GMAP_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OPERATION_TYPE_FAMILY",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_MOVEMENT = table.Column<int>(type: "int", nullable: false),
                    ID_ASSET = table.Column<int>(type: "int", nullable: false),
                    LABEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ID_USER_GROUP = table.Column<int>(type: "int", nullable: false),
                    IS_MANDATORY = table.Column<bool>(type: "bit", maxLength: 4, nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_TYPE_FAMILY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OPERATION_TYPE_FAMILY_ASSET_ID_ASSET",
                        column: x => x.ID_ASSET,
                        principalSchema: "ref",
                        principalTable: "ASSET",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OPERATION_TYPE_FAMILY_MOVEMENT_ID_MOVEMENT",
                        column: x => x.ID_MOVEMENT,
                        principalSchema: "ref",
                        principalTable: "MOVEMENT",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "POSTE",
                schema: "plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_MOVEMENT = table.Column<int>(type: "int", nullable: false),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSTE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_POSTE_MOVEMENT_ID_MOVEMENT",
                        column: x => x.ID_MOVEMENT,
                        principalSchema: "ref",
                        principalTable: "MOVEMENT",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BANK_FILE_DEFINITION",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_BANK_FAMILY = table.Column<int>(type: "int", nullable: false),
                    LABEL_FIELD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LABEL_ORDER = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_FILE_DEFINITION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BANK_FILE_DEFINITION_BANK_FAMILY_ID_BANK_FAMILY",
                        column: x => x.ID_BANK_FAMILY,
                        principalSchema: "ref",
                        principalTable: "BANK_FAMILY",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BANK_SUB_FAMILY",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ASSET = table.Column<int>(type: "int", nullable: false),
                    ID_BANK_FAMILY = table.Column<int>(type: "int", nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LABEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_SUB_FAMILY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BANK_SUB_FAMILY_ASSET_ID_ASSET",
                        column: x => x.ID_ASSET,
                        principalSchema: "ref",
                        principalTable: "ASSET",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BANK_SUB_FAMILY_BANK_FAMILY_ID_BANK_FAMILY",
                        column: x => x.ID_BANK_FAMILY,
                        principalSchema: "ref",
                        principalTable: "BANK_FAMILY",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OPERATION_METHOD_LEXICAL",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_BANK_FAMILY = table.Column<int>(type: "int", nullable: false),
                    ID_OPERATION_METHOD = table.Column<int>(type: "int", nullable: false),
                    KEYWORD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ORDER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_METHOD_LEXICAL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OPERATION_METHOD_LEXICAL_BANK_FAMILY_ID_BANK_FAMILY",
                        column: x => x.ID_BANK_FAMILY,
                        principalSchema: "ref",
                        principalTable: "BANK_FAMILY",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OPERATION_METHOD_LEXICAL_OPERATION_METHOD_ID_OPERATION_METHOD",
                        column: x => x.ID_OPERATION_METHOD,
                        principalSchema: "ref",
                        principalTable: "OPERATION_METHOD",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GMAP_ADDRESS_TYPE",
                schema: "gmap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_GMAP_ADDRESS = table.Column<int>(type: "int", nullable: false),
                    ID_GMAP_TYPE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMAP_ADDRESS_TYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_TYPE_GMAP_ADDRESS_ID_GMAP_ADDRESS",
                        column: x => x.ID_GMAP_ADDRESS,
                        principalSchema: "gmap",
                        principalTable: "GMAP_ADDRESS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GMAP_ADDRESS_TYPE_GMAP_TYPE_ID_GMAP_TYPE",
                        column: x => x.ID_GMAP_TYPE,
                        principalSchema: "gmap",
                        principalTable: "GMAP_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USER",
                schema: "user",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER_PREFERENCE = table.Column<int>(type: "int", nullable: true),
                    ID_GMAP_ADDRESS = table.Column<int>(type: "int", nullable: true),
                    USER_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASSWORD_HASH = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PASSWORD_SALT = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GENDER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIRTH_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LAST_ACTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_USER_GROUP = table.Column<int>(type: "int", nullable: false),
                    MAIL_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTIVATION_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTIVATION_DATE_SEND = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVATION_IS_CONFIRMED = table.Column<bool>(type: "bit", nullable: false),
                    ROLE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_GMAP_ADDRESS_ID_GMAP_ADDRESS",
                        column: x => x.ID_GMAP_ADDRESS,
                        principalSchema: "gmap",
                        principalTable: "GMAP_ADDRESS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_USER_USER_PREFERENCE_ID_USER_PREFERENCE",
                        column: x => x.ID_USER_PREFERENCE,
                        principalSchema: "user",
                        principalTable: "USER_PREFERENCE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OPERATION_METHOD_OTF",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_OPERATION_METHOD = table.Column<int>(type: "int", nullable: false),
                    ID_OPERATION_TYPE_FAMILY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_METHOD_OTF", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OPERATION_METHOD_OTF_OPERATION_METHOD_ID_OPERATION_METHOD",
                        column: x => x.ID_OPERATION_METHOD,
                        principalSchema: "ref",
                        principalTable: "OPERATION_METHOD",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OPERATION_METHOD_OTF_OPERATION_TYPE_FAMILY_ID_OPERATION_TYPE_FAMILY",
                        column: x => x.ID_OPERATION_TYPE_FAMILY,
                        principalSchema: "ref",
                        principalTable: "OPERATION_TYPE_FAMILY",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OPERATION_TYPE",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_OPERATION_TYPE_FAMILY = table.Column<int>(type: "int", nullable: false),
                    LABEL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ID_USER_GROUP = table.Column<int>(type: "int", nullable: false),
                    IS_MANDATORY = table.Column<bool>(type: "bit", nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_TYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OPERATION_TYPE_OPERATION_TYPE_FAMILY_ID_OPERATION_TYPE_FAMILY",
                        column: x => x.ID_OPERATION_TYPE_FAMILY,
                        principalSchema: "ref",
                        principalTable: "OPERATION_TYPE_FAMILY",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PLAN_POSTE",
                schema: "plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PLAN = table.Column<int>(type: "int", nullable: false),
                    ID_POSTE = table.Column<int>(type: "int", nullable: false),
                    ID_REFERENCE_TABLE = table.Column<int>(type: "int", nullable: false),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAN_POSTE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLAN_POSTE_PLAN_ID_PLAN",
                        column: x => x.ID_PLAN,
                        principalSchema: "plan",
                        principalTable: "PLAN",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PLAN_POSTE_POSTE_ID_POSTE",
                        column: x => x.ID_POSTE,
                        principalSchema: "plan",
                        principalTable: "POSTE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PLAN_POSTE_REFERENCE_TABLE_ID_REFERENCE_TABLE",
                        column: x => x.ID_REFERENCE_TABLE,
                        principalSchema: "plan",
                        principalTable: "REFERENCE_TABLE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BANK_AGENCY",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_BANK_SUB_FAMILY = table.Column<int>(type: "int", nullable: false),
                    ID_GMAP_ADDRESS = table.Column<int>(type: "int", nullable: false),
                    LABEL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_AGENCY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BANK_AGENCY_BANK_SUB_FAMILY_ID_BANK_SUB_FAMILY",
                        column: x => x.ID_BANK_SUB_FAMILY,
                        principalSchema: "ref",
                        principalTable: "BANK_SUB_FAMILY",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BANK_AGENCY_GMAP_ADDRESS_ID_GMAP_ADDRESS",
                        column: x => x.ID_GMAP_ADDRESS,
                        principalSchema: "gmap",
                        principalTable: "GMAP_ADDRESS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OPERATION_TRANSVERSE",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    LABEL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_TRANSVERSE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OPERATION_TRANSVERSE_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalSchema: "user",
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PARAMETER",
                schema: "gen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMPORT_FILE_DIR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARAMETER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARAMETER_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalSchema: "user",
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PLAN_USER",
                schema: "plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    ID_PLAN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAN_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLAN_USER_PLAN_ID_PLAN",
                        column: x => x.ID_PLAN,
                        principalSchema: "plan",
                        principalTable: "PLAN",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PLAN_USER_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalSchema: "user",
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USER_MESSAGE",
                schema: "user",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    MESSAGE_FROM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MESSAGE_DATE_SENT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MESSAGE_SUBJECT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MESSAGE_BODY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_READ = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_MESSAGE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_MESSAGE_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalSchema: "user",
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USER_SHORTCUT",
                schema: "user",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_SHORTCUT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_SHORTCUT_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalSchema: "user",
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OPERATION",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_OPERATION_METHOD = table.Column<int>(type: "int", nullable: false),
                    ID_OPERATION_TYPE = table.Column<int>(type: "int", nullable: false),
                    LABEL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    REFERENCE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ID_USER_GROUP = table.Column<int>(type: "int", nullable: false),
                    IS_MANDATORY = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OPERATION_OPERATION_METHOD_ID_OPERATION_METHOD",
                        column: x => x.ID_OPERATION_METHOD,
                        principalSchema: "ref",
                        principalTable: "OPERATION_METHOD",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OPERATION_OPERATION_TYPE_ID_OPERATION_TYPE",
                        column: x => x.ID_OPERATION_TYPE,
                        principalSchema: "ref",
                        principalTable: "OPERATION_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PLAN_POSTE_FREQUENCY",
                schema: "plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PLAN_POSTE = table.Column<int>(type: "int", nullable: false),
                    ID_FREQUENCY = table.Column<int>(type: "int", nullable: false),
                    PREVIEW_AMOUNT = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAN_POSTE_FREQUENCY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLAN_POSTE_FREQUENCY_MONTH_ID_FREQUENCY",
                        column: x => x.ID_FREQUENCY,
                        principalSchema: "gen",
                        principalTable: "MONTH",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PLAN_POSTE_FREQUENCY_PLAN_POSTE_ID_PLAN_POSTE",
                        column: x => x.ID_PLAN_POSTE,
                        principalSchema: "plan",
                        principalTable: "PLAN_POSTE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PLAN_POSTE_REFERENCE",
                schema: "plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PLAN_POSTE = table.Column<int>(type: "int", nullable: false),
                    ID_REFERENCE_TABLE = table.Column<int>(type: "int", nullable: false),
                    ID_REFERENCE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAN_POSTE_REFERENCE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLAN_POSTE_REFERENCE_PLAN_POSTE_ID_PLAN_POSTE",
                        column: x => x.ID_PLAN_POSTE,
                        principalSchema: "plan",
                        principalTable: "PLAN_POSTE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PLAN_POSTE_REFERENCE_REFERENCE_TABLE_ID_REFERENCE_TABLE",
                        column: x => x.ID_REFERENCE_TABLE,
                        principalSchema: "plan",
                        principalTable: "REFERENCE_TABLE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER_OWNER = table.Column<int>(type: "int", nullable: false),
                    ID_BANK_AGENCY = table.Column<int>(type: "int", nullable: false),
                    ID_ACCOUNT_TYPE = table.Column<int>(type: "int", nullable: false),
                    NUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LABEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    START_AMOUNT = table.Column<double>(type: "float", nullable: false),
                    ALERT_THRESHOLD = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_ACCOUNT_TYPE_ID_ACCOUNT_TYPE",
                        column: x => x.ID_ACCOUNT_TYPE,
                        principalSchema: "ref",
                        principalTable: "ACCOUNT_TYPE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_BANK_AGENCY_ID_BANK_AGENCY",
                        column: x => x.ID_BANK_AGENCY,
                        principalSchema: "ref",
                        principalTable: "BANK_AGENCY",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_USER_ID_USER_OWNER",
                        column: x => x.ID_USER_OWNER,
                        principalSchema: "user",
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT_STATEMENT_IMPORT",
                schema: "as",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    ID_BANK_AGENCY = table.Column<int>(type: "int", nullable: false),
                    FILE_IMPORT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_IMPORT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT_STATEMENT_IMPORT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_IMPORT_BANK_AGENCY_ID_BANK_AGENCY",
                        column: x => x.ID_BANK_AGENCY,
                        principalSchema: "ref",
                        principalTable: "BANK_AGENCY",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_IMPORT_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalSchema: "user",
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PLAN_POSTE_USER",
                schema: "plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PLAN_POSTE = table.Column<int>(type: "int", nullable: false),
                    ID_PLAN_USER = table.Column<int>(type: "int", nullable: false),
                    IS_SALARY_ESTIMATED_PART = table.Column<int>(type: "int", nullable: false),
                    PERCENTAGE_PART = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAN_POSTE_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLAN_POSTE_USER_PLAN_POSTE_ID_PLAN_POSTE",
                        column: x => x.ID_PLAN_POSTE,
                        principalSchema: "plan",
                        principalTable: "PLAN_POSTE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PLAN_POSTE_USER_PLAN_USER_ID_PLAN_USER",
                        column: x => x.ID_PLAN_USER,
                        principalSchema: "plan",
                        principalTable: "PLAN_USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OPERATION_DETAIL",
                schema: "ref",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_OPERATION = table.Column<int>(type: "int", nullable: false),
                    KEYWORD_OPERATION = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KEYWORD_PLACE = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OPERATION_LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PLACE_LABEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_GMAP_ADDRESS = table.Column<int>(type: "int", nullable: true),
                    ID_OPERATION_PLACE = table.Column<int>(type: "int", nullable: false),
                    ID_USER_GROUP = table.Column<int>(type: "int", nullable: false),
                    IS_MANDATORY = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_DETAIL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OPERATION_DETAIL_GMAP_ADDRESS_ID_GMAP_ADDRESS",
                        column: x => x.ID_GMAP_ADDRESS,
                        principalSchema: "gmap",
                        principalTable: "GMAP_ADDRESS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OPERATION_DETAIL_OPERATION_ID_OPERATION",
                        column: x => x.ID_OPERATION,
                        principalSchema: "ref",
                        principalTable: "OPERATION",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OPERATION_DETAIL_OPERATION_PLACE_ID_OPERATION_PLACE",
                        column: x => x.ID_OPERATION_PLACE,
                        principalSchema: "ref",
                        principalTable: "OPERATION_PLACE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PLAN_ACCOUNT",
                schema: "plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PLAN = table.Column<int>(type: "int", nullable: false),
                    ID_ACCOUNT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAN_ACCOUNT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLAN_ACCOUNT_ACCOUNT_ID_ACCOUNT",
                        column: x => x.ID_ACCOUNT,
                        principalSchema: "ref",
                        principalTable: "ACCOUNT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PLAN_ACCOUNT_PLAN_ID_PLAN",
                        column: x => x.ID_PLAN,
                        principalSchema: "plan",
                        principalTable: "PLAN",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USER_ACCOUNT",
                schema: "user",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    ID_ACCOUNT = table.Column<int>(type: "int", nullable: false),
                    ACTIVATION_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ACCOUNT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_ACCOUNT_ACCOUNT_ID_ACCOUNT",
                        column: x => x.ID_ACCOUNT,
                        principalSchema: "ref",
                        principalTable: "ACCOUNT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_USER_ACCOUNT_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalSchema: "user",
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USER_CUSTOM_OTF",
                schema: "user",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    ID_ACCOUNT = table.Column<int>(type: "int", nullable: true),
                    ID_OPERATION_TYPE_FAMILY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_CUSTOM_OTF", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_CUSTOM_OTF_ACCOUNT_ID_ACCOUNT",
                        column: x => x.ID_ACCOUNT,
                        principalSchema: "ref",
                        principalTable: "ACCOUNT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_USER_CUSTOM_OTF_OPERATION_TYPE_FAMILY_ID_OPERATION_TYPE_FAMILY",
                        column: x => x.ID_OPERATION_TYPE_FAMILY,
                        principalSchema: "ref",
                        principalTable: "OPERATION_TYPE_FAMILY",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_USER_CUSTOM_OTF_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalSchema: "user",
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT_STATEMENT",
                schema: "as",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_IMPORT = table.Column<int>(type: "int", nullable: false),
                    ID_ACCOUNT = table.Column<int>(type: "int", nullable: false),
                    ID_OPERATION_METHOD = table.Column<int>(type: "int", nullable: false),
                    ID_OPERATION = table.Column<int>(type: "int", nullable: false),
                    ID_OPERATION_DETAIL = table.Column<int>(type: "int", nullable: false),
                    ID_OPERATION_TYPE = table.Column<int>(type: "int", nullable: false),
                    ID_OPERATION_TYPE_FAMILY = table.Column<int>(type: "int", nullable: false),
                    ID_MOVEMENT = table.Column<int>(type: "int", nullable: false),
                    DATE_OPERATION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LABEL_AS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    REFERENCE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DATE_INTEGRATION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AMOUNT_OPERATION = table.Column<double>(type: "float", nullable: false),
                    DATE_IMPORT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_ACCOUNT_STATEMENT_IT = table.Column<int>(type: "int", nullable: true),
                    ID_ACCOUNT_IT = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT_STATEMENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_ACCOUNT_ID_ACCOUNT",
                        column: x => x.ID_ACCOUNT,
                        principalSchema: "ref",
                        principalTable: "ACCOUNT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_ACCOUNT_STATEMENT_IMPORT_ID_IMPORT",
                        column: x => x.ID_IMPORT,
                        principalSchema: "as",
                        principalTable: "ACCOUNT_STATEMENT_IMPORT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_MOVEMENT_ID_MOVEMENT",
                        column: x => x.ID_MOVEMENT,
                        principalSchema: "ref",
                        principalTable: "MOVEMENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_OPERATION_DETAIL_ID_OPERATION_DETAIL",
                        column: x => x.ID_OPERATION_DETAIL,
                        principalSchema: "ref",
                        principalTable: "OPERATION_DETAIL",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_OPERATION_ID_OPERATION",
                        column: x => x.ID_OPERATION,
                        principalSchema: "ref",
                        principalTable: "OPERATION",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_OPERATION_METHOD_ID_OPERATION_METHOD",
                        column: x => x.ID_OPERATION_METHOD,
                        principalSchema: "ref",
                        principalTable: "OPERATION_METHOD",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_OPERATION_TYPE_FAMILY_ID_OPERATION_TYPE_FAMILY",
                        column: x => x.ID_OPERATION_TYPE_FAMILY,
                        principalSchema: "ref",
                        principalTable: "OPERATION_TYPE_FAMILY",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_OPERATION_TYPE_ID_OPERATION_TYPE",
                        column: x => x.ID_OPERATION_TYPE,
                        principalSchema: "ref",
                        principalTable: "OPERATION_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT_STATEMENT_IMPORT_FILE",
                schema: "as",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_IMPORT = table.Column<int>(type: "int", nullable: false),
                    ID_ACCOUNT = table.Column<int>(type: "int", nullable: true),
                    DATE_OPERATION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LABEL_AS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ID_OPERATION_METHOD = table.Column<int>(type: "int", nullable: true),
                    ID_OPERATION = table.Column<int>(type: "int", nullable: true),
                    ID_OPERATION_DETAIL = table.Column<int>(type: "int", nullable: true),
                    ID_OPERATION_TYPE = table.Column<int>(type: "int", nullable: true),
                    ID_OPERATION_TYPE_FAMILY = table.Column<int>(type: "int", nullable: true),
                    ID_MOVEMENT = table.Column<int>(type: "int", nullable: true),
                    ID_STATE = table.Column<int>(type: "int", nullable: true),
                    REFERENCE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DATE_INTEGRATION = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AMOUNT_OPERATION = table.Column<double>(type: "float", nullable: true),
                    DATE_IMPORT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LABEL_OPERATION_WORK = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IS_DUPLICATED = table.Column<bool>(type: "bit", nullable: false),
                    OD_OPERATION_KEYWORD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OD_PLACE_KEYWORD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OD_OPERATION_LABEL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OD_PLACE_LABEL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT_STATEMENT_IMPORT_FILE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_IMPORT_FILE_ACCOUNT_ID_ACCOUNT",
                        column: x => x.ID_ACCOUNT,
                        principalSchema: "ref",
                        principalTable: "ACCOUNT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_IMPORT_FILE_ACCOUNT_STATEMENT_IMPORT_ID_IMPORT",
                        column: x => x.ID_IMPORT,
                        principalSchema: "as",
                        principalTable: "ACCOUNT_STATEMENT_IMPORT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_IMPORT_FILE_MOVEMENT_ID_MOVEMENT",
                        column: x => x.ID_MOVEMENT,
                        principalSchema: "ref",
                        principalTable: "MOVEMENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_IMPORT_FILE_OPERATION_DETAIL_ID_OPERATION_DETAIL",
                        column: x => x.ID_OPERATION_DETAIL,
                        principalSchema: "ref",
                        principalTable: "OPERATION_DETAIL",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_IMPORT_FILE_OPERATION_ID_OPERATION",
                        column: x => x.ID_OPERATION,
                        principalSchema: "ref",
                        principalTable: "OPERATION",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_IMPORT_FILE_OPERATION_METHOD_ID_OPERATION_METHOD",
                        column: x => x.ID_OPERATION_METHOD,
                        principalSchema: "ref",
                        principalTable: "OPERATION_METHOD",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_IMPORT_FILE_OPERATION_TYPE_FAMILY_ID_OPERATION_TYPE_FAMILY",
                        column: x => x.ID_OPERATION_TYPE_FAMILY,
                        principalSchema: "ref",
                        principalTable: "OPERATION_TYPE_FAMILY",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_IMPORT_FILE_OPERATION_TYPE_ID_OPERATION_TYPE",
                        column: x => x.ID_OPERATION_TYPE,
                        principalSchema: "ref",
                        principalTable: "OPERATION_TYPE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_IMPORT_FILE_STATE_ASIF_ID_STATE",
                        column: x => x.ID_STATE,
                        principalSchema: "ref",
                        principalTable: "STATE_ASIF",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT_STATEMENT_PLAN",
                schema: "as",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ACCOUNT_STATEMENT = table.Column<int>(type: "int", nullable: false),
                    ID_PLAN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT_STATEMENT_PLAN", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_PLAN_ACCOUNT_STATEMENT_ID_ACCOUNT_STATEMENT",
                        column: x => x.ID_ACCOUNT_STATEMENT,
                        principalSchema: "as",
                        principalTable: "ACCOUNT_STATEMENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ACCOUNT_STATEMENT_PLAN_PLAN_ID_PLAN",
                        column: x => x.ID_PLAN,
                        principalSchema: "plan",
                        principalTable: "PLAN",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OPERATION_TRANSVERSE_AS",
                schema: "as",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_OPERATION_TRANSVERSE = table.Column<int>(type: "int", nullable: false),
                    ID_ACCOUNT_STATEMENT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_TRANSVERSE_AS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OPERATION_TRANSVERSE_AS_ACCOUNT_STATEMENT_ID_ACCOUNT_STATEMENT",
                        column: x => x.ID_ACCOUNT_STATEMENT,
                        principalSchema: "as",
                        principalTable: "ACCOUNT_STATEMENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OPERATION_TRANSVERSE_AS_OPERATION_TRANSVERSE_ID_OPERATION_TRANSVERSE",
                        column: x => x.ID_OPERATION_TRANSVERSE,
                        principalSchema: "ref",
                        principalTable: "OPERATION_TRANSVERSE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OPERATION_TRANSVERSE_ASIF",
                schema: "as",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_OPERATION_TRANSVERSE = table.Column<int>(type: "int", nullable: false),
                    ID_ACCOUNT_STATEMENT_IMPORT_FILE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATION_TRANSVERSE_ASIF", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OPERATION_TRANSVERSE_ASIF_ACCOUNT_STATEMENT_IMPORT_FILE_ID_ACCOUNT_STATEMENT_IMPORT_FILE",
                        column: x => x.ID_ACCOUNT_STATEMENT_IMPORT_FILE,
                        principalSchema: "as",
                        principalTable: "ACCOUNT_STATEMENT_IMPORT_FILE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OPERATION_TRANSVERSE_ASIF_OPERATION_TRANSVERSE_ID_OPERATION_TRANSVERSE",
                        column: x => x.ID_OPERATION_TRANSVERSE,
                        principalSchema: "ref",
                        principalTable: "OPERATION_TRANSVERSE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_ID_ACCOUNT_TYPE",
                schema: "ref",
                table: "ACCOUNT",
                column: "ID_ACCOUNT_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_ID_BANK_AGENCY",
                schema: "ref",
                table: "ACCOUNT",
                column: "ID_BANK_AGENCY");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_ID_USER_OWNER",
                schema: "ref",
                table: "ACCOUNT",
                column: "ID_USER_OWNER");

            migrationBuilder.CreateIndex(
                name: "IX_AccountNumber",
                schema: "ref",
                table: "ACCOUNT",
                column: "NUMBER",
                unique: true,
                filter: "[NUMBER] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_ID_ACCOUNT",
                schema: "as",
                table: "ACCOUNT_STATEMENT",
                column: "ID_ACCOUNT");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_ID_IMPORT",
                schema: "as",
                table: "ACCOUNT_STATEMENT",
                column: "ID_IMPORT");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_ID_MOVEMENT",
                schema: "as",
                table: "ACCOUNT_STATEMENT",
                column: "ID_MOVEMENT");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_ID_OPERATION",
                schema: "as",
                table: "ACCOUNT_STATEMENT",
                column: "ID_OPERATION");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_ID_OPERATION_DETAIL",
                schema: "as",
                table: "ACCOUNT_STATEMENT",
                column: "ID_OPERATION_DETAIL");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_ID_OPERATION_METHOD",
                schema: "as",
                table: "ACCOUNT_STATEMENT",
                column: "ID_OPERATION_METHOD");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_ID_OPERATION_TYPE",
                schema: "as",
                table: "ACCOUNT_STATEMENT",
                column: "ID_OPERATION_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_ID_OPERATION_TYPE_FAMILY",
                schema: "as",
                table: "ACCOUNT_STATEMENT",
                column: "ID_OPERATION_TYPE_FAMILY");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_IMPORT_ID_BANK_AGENCY",
                schema: "as",
                table: "ACCOUNT_STATEMENT_IMPORT",
                column: "ID_BANK_AGENCY");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_IMPORT_ID_USER",
                schema: "as",
                table: "ACCOUNT_STATEMENT_IMPORT",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_IMPORT_FILE_ID_ACCOUNT",
                schema: "as",
                table: "ACCOUNT_STATEMENT_IMPORT_FILE",
                column: "ID_ACCOUNT");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_IMPORT_FILE_ID_IMPORT",
                schema: "as",
                table: "ACCOUNT_STATEMENT_IMPORT_FILE",
                column: "ID_IMPORT");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_IMPORT_FILE_ID_MOVEMENT",
                schema: "as",
                table: "ACCOUNT_STATEMENT_IMPORT_FILE",
                column: "ID_MOVEMENT");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_IMPORT_FILE_ID_OPERATION",
                schema: "as",
                table: "ACCOUNT_STATEMENT_IMPORT_FILE",
                column: "ID_OPERATION");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_IMPORT_FILE_ID_OPERATION_DETAIL",
                schema: "as",
                table: "ACCOUNT_STATEMENT_IMPORT_FILE",
                column: "ID_OPERATION_DETAIL");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_IMPORT_FILE_ID_OPERATION_METHOD",
                schema: "as",
                table: "ACCOUNT_STATEMENT_IMPORT_FILE",
                column: "ID_OPERATION_METHOD");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_IMPORT_FILE_ID_OPERATION_TYPE",
                schema: "as",
                table: "ACCOUNT_STATEMENT_IMPORT_FILE",
                column: "ID_OPERATION_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_IMPORT_FILE_ID_OPERATION_TYPE_FAMILY",
                schema: "as",
                table: "ACCOUNT_STATEMENT_IMPORT_FILE",
                column: "ID_OPERATION_TYPE_FAMILY");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_IMPORT_FILE_ID_STATE",
                schema: "as",
                table: "ACCOUNT_STATEMENT_IMPORT_FILE",
                column: "ID_STATE");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_STATEMENT_PLAN_ID_PLAN",
                schema: "as",
                table: "ACCOUNT_STATEMENT_PLAN",
                column: "ID_PLAN");

            migrationBuilder.CreateIndex(
                name: "IX_ASP_IdAccountStatement_IdPlan",
                schema: "as",
                table: "ACCOUNT_STATEMENT_PLAN",
                columns: new[] { "ID_ACCOUNT_STATEMENT", "ID_PLAN" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BANK_AGENCY_ID_BANK_SUB_FAMILY",
                schema: "ref",
                table: "BANK_AGENCY",
                column: "ID_BANK_SUB_FAMILY");

            migrationBuilder.CreateIndex(
                name: "IX_BANK_AGENCY_ID_GMAP_ADDRESS",
                schema: "ref",
                table: "BANK_AGENCY",
                column: "ID_GMAP_ADDRESS");

            migrationBuilder.CreateIndex(
                name: "IX_BANK_FAMILY_ID_ASSET",
                schema: "ref",
                table: "BANK_FAMILY",
                column: "ID_ASSET");

            migrationBuilder.CreateIndex(
                name: "IX_BANK_FILE_DEFINITION_ID_BANK_FAMILY",
                schema: "ref",
                table: "BANK_FILE_DEFINITION",
                column: "ID_BANK_FAMILY");

            migrationBuilder.CreateIndex(
                name: "IX_BANK_SUB_FAMILY_ID_ASSET",
                schema: "ref",
                table: "BANK_SUB_FAMILY",
                column: "ID_ASSET");

            migrationBuilder.CreateIndex(
                name: "IX_BANK_SUB_FAMILY_ID_BANK_FAMILY",
                schema: "ref",
                table: "BANK_SUB_FAMILY",
                column: "ID_BANK_FAMILY");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_ADDRESS_ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_1",
                schema: "gmap",
                table: "GMAP_ADDRESS",
                column: "ID_GMAP_ADMINISTRATIVE_AREA_LEVEL_1");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_ADDRESS_ID_GMAP_COUNTRY",
                schema: "gmap",
                table: "GMAP_ADDRESS",
                column: "ID_GMAP_COUNTRY");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_ADDRESS_ID_GMAP_LOCALITY",
                schema: "gmap",
                table: "GMAP_ADDRESS",
                column: "ID_GMAP_LOCALITY");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_ADDRESS_ID_GMAP_NEIGHBORHOOD",
                schema: "gmap",
                table: "GMAP_ADDRESS",
                column: "ID_GMAP_NEIGHBORHOOD");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_ADDRESS_ID_GMAP_POSTAL_CODE",
                schema: "gmap",
                table: "GMAP_ADDRESS",
                column: "ID_GMAP_POSTAL_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_ADDRESS_ID_GMAP_ROUTE",
                schema: "gmap",
                table: "GMAP_ADDRESS",
                column: "ID_GMAP_ROUTE");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_ADDRESS_ID_GMAP_STREET_NUMBER",
                schema: "gmap",
                table: "GMAP_ADDRESS",
                column: "ID_GMAP_STREET_NUMBER");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_ADDRESS_ID_GMAP_SUBLOCALITY_LEVEL_1",
                schema: "gmap",
                table: "GMAP_ADDRESS",
                column: "ID_GMAP_SUBLOCALITY_LEVEL_1");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_ADDRESS_ID_GMAP_SUBLOCALITY_LEVEL_2",
                schema: "gmap",
                table: "GMAP_ADDRESS",
                column: "ID_GMAP_SUBLOCALITY_LEVEL_2");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_ADDRESS_TYPE_ID_GMAP_ADDRESS",
                schema: "gmap",
                table: "GMAP_ADDRESS_TYPE",
                column: "ID_GMAP_ADDRESS");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_ADDRESS_TYPE_ID_GMAP_TYPE",
                schema: "gmap",
                table: "GMAP_ADDRESS_TYPE",
                column: "ID_GMAP_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_GMAP_TYPE_LANGUAGE_ID_GMAP_TYPE",
                schema: "gmap",
                table: "GMAP_TYPE_LANGUAGE",
                column: "ID_GMAP_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_ID_OPERATION_METHOD",
                schema: "ref",
                table: "OPERATION",
                column: "ID_OPERATION_METHOD");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_ID_OPERATION_TYPE",
                schema: "ref",
                table: "OPERATION",
                column: "ID_OPERATION_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_OperationKey",
                schema: "ref",
                table: "OPERATION",
                columns: new[] { "LABEL", "ID_OPERATION_METHOD", "ID_OPERATION_TYPE" },
                unique: true,
                filter: "[LABEL] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Keyword",
                schema: "ref",
                table: "OPERATION_DETAIL",
                columns: new[] { "KEYWORD_OPERATION", "KEYWORD_PLACE", "ID_USER_GROUP" },
                unique: true,
                filter: "[KEYWORD_OPERATION] IS NOT NULL AND [KEYWORD_PLACE] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_DETAIL_ID_GMAP_ADDRESS",
                schema: "ref",
                table: "OPERATION_DETAIL",
                column: "ID_GMAP_ADDRESS");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_DETAIL_ID_OPERATION",
                schema: "ref",
                table: "OPERATION_DETAIL",
                column: "ID_OPERATION");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_DETAIL_ID_OPERATION_PLACE",
                schema: "ref",
                table: "OPERATION_DETAIL",
                column: "ID_OPERATION_PLACE");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_METHOD_LEXICAL_ID_BANK_FAMILY",
                schema: "ref",
                table: "OPERATION_METHOD_LEXICAL",
                column: "ID_BANK_FAMILY");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_METHOD_LEXICAL_ID_OPERATION_METHOD",
                schema: "ref",
                table: "OPERATION_METHOD_LEXICAL",
                column: "ID_OPERATION_METHOD");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_METHOD_OTF_ID_OPERATION_TYPE_FAMILY",
                schema: "ref",
                table: "OPERATION_METHOD_OTF",
                column: "ID_OPERATION_TYPE_FAMILY");

            migrationBuilder.CreateIndex(
                name: "IX_PK_UNICITY",
                schema: "ref",
                table: "OPERATION_METHOD_OTF",
                columns: new[] { "ID_OPERATION_METHOD", "ID_OPERATION_TYPE_FAMILY" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_TRANSVERSE_ID_USER",
                schema: "ref",
                table: "OPERATION_TRANSVERSE",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_TRANSVERSE_AS_ID_ACCOUNT_STATEMENT",
                schema: "as",
                table: "OPERATION_TRANSVERSE_AS",
                column: "ID_ACCOUNT_STATEMENT");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_TRANSVERSE_AS_ID_OPERATION_TRANSVERSE",
                schema: "as",
                table: "OPERATION_TRANSVERSE_AS",
                column: "ID_OPERATION_TRANSVERSE");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_TRANSVERSE_ASIF_ID_ACCOUNT_STATEMENT_IMPORT_FILE",
                schema: "as",
                table: "OPERATION_TRANSVERSE_ASIF",
                column: "ID_ACCOUNT_STATEMENT_IMPORT_FILE");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_TRANSVERSE_ASIF_ID_OPERATION_TRANSVERSE",
                schema: "as",
                table: "OPERATION_TRANSVERSE_ASIF",
                column: "ID_OPERATION_TRANSVERSE");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_TYPE_ID_OPERATION_TYPE_FAMILY",
                schema: "ref",
                table: "OPERATION_TYPE",
                column: "ID_OPERATION_TYPE_FAMILY");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_TYPE_FAMILY_ID_ASSET",
                schema: "ref",
                table: "OPERATION_TYPE_FAMILY",
                column: "ID_ASSET");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATION_TYPE_FAMILY_ID_MOVEMENT",
                schema: "ref",
                table: "OPERATION_TYPE_FAMILY",
                column: "ID_MOVEMENT");

            migrationBuilder.CreateIndex(
                name: "IX_OTF_Id_IdMovement",
                schema: "ref",
                table: "OPERATION_TYPE_FAMILY",
                columns: new[] { "ID", "ID_MOVEMENT" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETER_ID_USER",
                schema: "gen",
                table: "PARAMETER",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_ACCOUNT_ID_ACCOUNT",
                schema: "plan",
                table: "PLAN_ACCOUNT",
                column: "ID_ACCOUNT");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_ACCOUNT_ID_PLAN",
                schema: "plan",
                table: "PLAN_ACCOUNT",
                column: "ID_PLAN");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_POSTE_ID_PLAN",
                schema: "plan",
                table: "PLAN_POSTE",
                column: "ID_PLAN");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_POSTE_ID_POSTE",
                schema: "plan",
                table: "PLAN_POSTE",
                column: "ID_POSTE");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_POSTE_ID_REFERENCE_TABLE",
                schema: "plan",
                table: "PLAN_POSTE",
                column: "ID_REFERENCE_TABLE");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_POSTE_FREQUENCY_ID_FREQUENCY",
                schema: "plan",
                table: "PLAN_POSTE_FREQUENCY",
                column: "ID_FREQUENCY");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_POSTE_FREQUENCY_ID_PLAN_POSTE",
                schema: "plan",
                table: "PLAN_POSTE_FREQUENCY",
                column: "ID_PLAN_POSTE");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_POSTE_REFERENCE_ID_PLAN_POSTE",
                schema: "plan",
                table: "PLAN_POSTE_REFERENCE",
                column: "ID_PLAN_POSTE");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_POSTE_REFERENCE_ID_REFERENCE_TABLE",
                schema: "plan",
                table: "PLAN_POSTE_REFERENCE",
                column: "ID_REFERENCE_TABLE");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_POSTE_USER_ID_PLAN_POSTE",
                schema: "plan",
                table: "PLAN_POSTE_USER",
                column: "ID_PLAN_POSTE");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_POSTE_USER_ID_PLAN_USER",
                schema: "plan",
                table: "PLAN_POSTE_USER",
                column: "ID_PLAN_USER");

            migrationBuilder.CreateIndex(
                name: "IX_PLAN_USER_ID_USER",
                schema: "plan",
                table: "PLAN_USER",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_PlanUser",
                schema: "plan",
                table: "PLAN_USER",
                columns: new[] { "ID_PLAN", "ID_USER" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_POSTE_ID_MOVEMENT",
                schema: "plan",
                table: "POSTE",
                column: "ID_MOVEMENT");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ID_GMAP_ADDRESS",
                schema: "user",
                table: "USER",
                column: "ID_GMAP_ADDRESS");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ID_USER_PREFERENCE",
                schema: "user",
                table: "USER",
                column: "ID_USER_PREFERENCE");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ACCOUNT_ID_ACCOUNT",
                schema: "user",
                table: "USER_ACCOUNT",
                column: "ID_ACCOUNT");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ACCOUNT_ID_USER",
                schema: "user",
                table: "USER_ACCOUNT",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_UCO_IdOperationTypeFamily_IdUser_IdAccount",
                schema: "user",
                table: "USER_CUSTOM_OTF",
                columns: new[] { "ID_OPERATION_TYPE_FAMILY", "ID_USER", "ID_ACCOUNT" },
                unique: true,
                filter: "[ID_ACCOUNT] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USER_CUSTOM_OTF_ID_ACCOUNT",
                schema: "user",
                table: "USER_CUSTOM_OTF",
                column: "ID_ACCOUNT");

            migrationBuilder.CreateIndex(
                name: "IX_USER_CUSTOM_OTF_ID_USER",
                schema: "user",
                table: "USER_CUSTOM_OTF",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_USER_MESSAGE_ID_USER",
                schema: "user",
                table: "USER_MESSAGE",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_USER_SHORTCUT_ID_USER",
                schema: "user",
                table: "USER_SHORTCUT",
                column: "ID_USER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNT_STATEMENT_PLAN",
                schema: "as");

            migrationBuilder.DropTable(
                name: "AsEvolutionDto");

            migrationBuilder.DropTable(
                name: "BANK_FILE_DEFINITION",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "BaseChartData");

            migrationBuilder.DropTable(
                name: "GMAP_ADDRESS_TYPE",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "GMAP_TYPE_LANGUAGE",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "OPERATION_METHOD_LEXICAL",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "OPERATION_METHOD_OTF",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "OPERATION_TRANSVERSE_AS",
                schema: "as");

            migrationBuilder.DropTable(
                name: "OPERATION_TRANSVERSE_ASIF",
                schema: "as");

            migrationBuilder.DropTable(
                name: "PARAMETER",
                schema: "gen");

            migrationBuilder.DropTable(
                name: "PLAN_ACCOUNT",
                schema: "plan");

            migrationBuilder.DropTable(
                name: "PLAN_POSTE_FREQUENCY",
                schema: "plan");

            migrationBuilder.DropTable(
                name: "PLAN_POSTE_REFERENCE",
                schema: "plan");

            migrationBuilder.DropTable(
                name: "PLAN_POSTE_USER",
                schema: "plan");

            migrationBuilder.DropTable(
                name: "SelectNameValueDto");

            migrationBuilder.DropTable(
                name: "SoldeDto");

            migrationBuilder.DropTable(
                name: "USER_ACCOUNT",
                schema: "user");

            migrationBuilder.DropTable(
                name: "USER_CUSTOM_OTF",
                schema: "user");

            migrationBuilder.DropTable(
                name: "USER_MESSAGE",
                schema: "user");

            migrationBuilder.DropTable(
                name: "USER_SHORTCUT",
                schema: "user");

            migrationBuilder.DropTable(
                name: "V_PLAN_GLOBAL",
                schema: "plan");

            migrationBuilder.DropTable(
                name: "GMAP_TYPE",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "ACCOUNT_STATEMENT",
                schema: "as");

            migrationBuilder.DropTable(
                name: "ACCOUNT_STATEMENT_IMPORT_FILE",
                schema: "as");

            migrationBuilder.DropTable(
                name: "OPERATION_TRANSVERSE",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "MONTH",
                schema: "gen");

            migrationBuilder.DropTable(
                name: "PLAN_POSTE",
                schema: "plan");

            migrationBuilder.DropTable(
                name: "PLAN_USER",
                schema: "plan");

            migrationBuilder.DropTable(
                name: "ACCOUNT",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "ACCOUNT_STATEMENT_IMPORT",
                schema: "as");

            migrationBuilder.DropTable(
                name: "OPERATION_DETAIL",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "STATE_ASIF",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "POSTE",
                schema: "plan");

            migrationBuilder.DropTable(
                name: "REFERENCE_TABLE",
                schema: "plan");

            migrationBuilder.DropTable(
                name: "PLAN",
                schema: "plan");

            migrationBuilder.DropTable(
                name: "ACCOUNT_TYPE",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "BANK_AGENCY",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "USER",
                schema: "user");

            migrationBuilder.DropTable(
                name: "OPERATION",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "OPERATION_PLACE",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "BANK_SUB_FAMILY",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "GMAP_ADDRESS",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "USER_PREFERENCE",
                schema: "user");

            migrationBuilder.DropTable(
                name: "OPERATION_METHOD",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "OPERATION_TYPE",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "BANK_FAMILY",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "GMAP_ADMINISTRATIVE_AREA_LEVEL_1",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "GMAP_ADMINISTRATIVE_AREA_LEVEL_2",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "GMAP_COUNTRY",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "GMAP_LOCALITY",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "GMAP_NEIGHBORHOOD",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "GMAP_POSTAL_CODE",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "GMAP_ROUTE",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "GMAP_STREET_NUMBER",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "GMAP_SUBLOCALITY_LEVEL_1",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "GMAP_SUBLOCALITY_LEVEL_2",
                schema: "gmap");

            migrationBuilder.DropTable(
                name: "OPERATION_TYPE_FAMILY",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "ASSET",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "MOVEMENT",
                schema: "ref");
        }
    }
}
