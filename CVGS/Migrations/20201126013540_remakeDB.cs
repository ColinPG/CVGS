using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVGS.Migrations
{
    public partial class remakeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
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
                    PromoEmailEnabled = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    Bio = table.Column<string>(nullable: false, defaultValueSql: "('Tell us about yourself.')"),
                    GamerTag = table.Column<string>(nullable: false, defaultValueSql: "('YourGamerTag')"),
                    firstName = table.Column<string>(maxLength: 450, nullable: true),
                    lastName = table.Column<string>(maxLength: 450, nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    gender = table.Column<string>(maxLength: 450, nullable: true),
                    country = table.Column<string>(maxLength: 450, nullable: true),
                    provinceState = table.Column<string>(maxLength: 450, nullable: true),
                    city = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    Alpha2Code = table.Column<string>(maxLength: 2, nullable: false),
                    EnglishName = table.Column<string>(maxLength: 50, nullable: false),
                    FrenchName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Country_PK", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "EsrbRating",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 5, nullable: false),
                    EnglishRating = table.Column<string>(maxLength: 30, nullable: false),
                    FrenchRating = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EsrbRatingCode_PK", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "GameCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnglishCategory = table.Column<string>(maxLength: 20, nullable: false),
                    FrenchCategory = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamePerspective",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 1, nullable: false),
                    EnglishPerspectiveName = table.Column<string>(maxLength: 15, nullable: false),
                    FrenchPerspectiveName = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GamePerspective_PK", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "GameStatus",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 1, nullable: false),
                    EnglishCategory = table.Column<string>(maxLength: 15, nullable: false),
                    FrenchCategory = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GameStatus_PK", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "GameSubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameCategoryId = table.Column<int>(nullable: false),
                    EnglishCategory = table.Column<string>(maxLength: 20, nullable: false),
                    FrenchCategory = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSubCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    EnglishName = table.Column<string>(maxLength: 40, nullable: false),
                    FrenchName = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Platform_PK", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 2, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 3, nullable: false),
                    EnglishName = table.Column<string>(maxLength: 50, nullable: false),
                    FrenchName = table.Column<string>(maxLength: 50, nullable: false),
                    FederalTax = table.Column<double>(nullable: true, defaultValueSql: "((0))"),
                    FederalTaxAcronym = table.Column<string>(maxLength: 10, nullable: true),
                    ProvincialTax = table.Column<double>(nullable: true, defaultValueSql: "((0))"),
                    ProvincialTaxAcronym = table.Column<string>(maxLength: 10, nullable: true),
                    PstOnGst = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProvinceLookup_PK", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "CategoryPreference",
                columns: table => new
                {
                    userId = table.Column<string>(nullable: false),
                    gamecategoryId = table.Column<int>(nullable: false),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__5503CE5E31DD18C6", x => new { x.userId, x.gamecategoryId });
                    table.ForeignKey(
                        name: "FK__CategoryP__gamec__61316BF4",
                        column: x => x.gamecategoryId,
                        principalTable: "GameCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CategoryP__userI__603D47BB",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    GameStatusCode = table.Column<string>(maxLength: 1, nullable: false),
                    GameCategoryId = table.Column<int>(nullable: false),
                    GameSubCategoryId = table.Column<int>(nullable: true),
                    EsrbRatingCode = table.Column<string>(maxLength: 5, nullable: false),
                    EnglishName = table.Column<string>(maxLength: 70, nullable: false),
                    FrenchName = table.Column<string>(maxLength: 70, nullable: false),
                    FrenchVersion = table.Column<bool>(nullable: false),
                    EnglishPlayerCount = table.Column<string>(maxLength: 30, nullable: true),
                    FrenchPlayerCount = table.Column<string>(maxLength: 30, nullable: true),
                    GamePerspectiveCode = table.Column<string>(maxLength: 1, nullable: true),
                    EnglishTrailer = table.Column<string>(maxLength: 4000, nullable: true),
                    FrenchTrailer = table.Column<string>(maxLength: 4000, nullable: true),
                    EnglishDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    FrenchDescription = table.Column<string>(maxLength: 4000, nullable: true),
                    EnglishDetail = table.Column<string>(maxLength: 4000, nullable: true),
                    FrenchDetail = table.Column<string>(maxLength: 4000, nullable: true),
                    UserName = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "('Unknown')"),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Game_PK", x => x.Guid);
                    table.ForeignKey(
                        name: "Game_EsrbRating_FK",
                        column: x => x.EsrbRatingCode,
                        principalTable: "EsrbRating",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Game_GameCategory_FK",
                        column: x => x.GameCategoryId,
                        principalTable: "GameCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Game_GamePerspective_FK",
                        column: x => x.GamePerspectiveCode,
                        principalTable: "GamePerspective",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Game_GameStatus_FK",
                        column: x => x.GameStatusCode,
                        principalTable: "GameStatus",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Game_GameSubCategory_FK",
                        column: x => x.GameSubCategoryId,
                        principalTable: "GameSubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryPreference",
                columns: table => new
                {
                    userId = table.Column<string>(nullable: false),
                    gameSubcategoryId = table.Column<int>(nullable: false),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubCateg__AEDF96AEA68DA694", x => new { x.userId, x.gameSubcategoryId });
                    table.ForeignKey(
                        name: "FK__SubCatego__gameS__65F62111",
                        column: x => x.gameSubcategoryId,
                        principalTable: "GameSubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__SubCatego__userI__6501FCD8",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlatformPreference",
                columns: table => new
                {
                    userId = table.Column<string>(nullable: false),
                    platformCode = table.Column<string>(maxLength: 10, nullable: false),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Platform__A669FBFE92BE477D", x => new { x.userId, x.platformCode });
                    table.ForeignKey(
                        name: "FK__PlatformP__platf__5C6CB6D7",
                        column: x => x.platformCode,
                        principalTable: "Platform",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PlatformP__userI__5B78929E",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressMailing",
                columns: table => new
                {
                    mailingId = table.Column<Guid>(nullable: false),
                    street = table.Column<string>(maxLength: 20, nullable: false),
                    postalCode = table.Column<string>(maxLength: 6, nullable: false),
                    city = table.Column<string>(maxLength: 20, nullable: false),
                    apartmentNumber = table.Column<string>(maxLength: 20, nullable: false),
                    province = table.Column<string>(maxLength: 20, nullable: false),
                    firstName = table.Column<string>(maxLength: 20, nullable: false),
                    lastName = table.Column<string>(maxLength: 20, nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    userId = table.Column<string>(maxLength: 450, nullable: false),
                    ProvinceCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AddressM__4E8DFD561DD20E0B", x => x.mailingId);
                    table.ForeignKey(
                        name: "FK_AddressMailing_Country_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Country",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressMailing_Province_ProvinceCode",
                        column: x => x.ProvinceCode,
                        principalTable: "Province",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AddressMa__userI__7908F585",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressShipping",
                columns: table => new
                {
                    shippingId = table.Column<Guid>(nullable: false),
                    street = table.Column<string>(maxLength: 20, nullable: false),
                    postalCode = table.Column<string>(maxLength: 6, nullable: false),
                    city = table.Column<string>(maxLength: 20, nullable: false),
                    apartmentNumber = table.Column<string>(maxLength: 20, nullable: false),
                    province = table.Column<string>(maxLength: 20, nullable: false),
                    firstName = table.Column<string>(maxLength: 20, nullable: false),
                    lastName = table.Column<string>(maxLength: 20, nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    userId = table.Column<string>(maxLength: 450, nullable: false),
                    ProvinceCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AddressS__EDF80BCA6656726E", x => x.shippingId);
                    table.ForeignKey(
                        name: "FK_AddressShipping_Country_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Country",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressShipping_Province_ProvinceCode",
                        column: x => x.ProvinceCode,
                        principalTable: "Province",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AddressSh__userI__79FD19BE",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressMailing_CountryCode",
                table: "AddressMailing",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_AddressMailing_ProvinceCode",
                table: "AddressMailing",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_AddressMailing_userId",
                table: "AddressMailing",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressShipping_CountryCode",
                table: "AddressShipping",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_AddressShipping_ProvinceCode",
                table: "AddressShipping",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_AddressShipping_userId",
                table: "AddressShipping",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

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
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPreference_gamecategoryId",
                table: "CategoryPreference",
                column: "gamecategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_EsrbRatingCode",
                table: "Game",
                column: "EsrbRatingCode");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameCategoryId",
                table: "Game",
                column: "GameCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GamePerspectiveCode",
                table: "Game",
                column: "GamePerspectiveCode");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameStatusCode",
                table: "Game",
                column: "GameStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameSubCategoryId",
                table: "Game",
                column: "GameSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformPreference_platformCode",
                table: "PlatformPreference",
                column: "platformCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryPreference_gameSubcategoryId",
                table: "SubCategoryPreference",
                column: "gameSubcategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressMailing");

            migrationBuilder.DropTable(
                name: "AddressShipping");

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
                name: "CategoryPreference");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "PlatformPreference");

            migrationBuilder.DropTable(
                name: "SubCategoryPreference");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EsrbRating");

            migrationBuilder.DropTable(
                name: "GameCategory");

            migrationBuilder.DropTable(
                name: "GamePerspective");

            migrationBuilder.DropTable(
                name: "GameStatus");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropTable(
                name: "GameSubCategory");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
