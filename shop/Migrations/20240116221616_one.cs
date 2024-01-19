using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descreption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poster = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "resetPassword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resetPassword", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "us",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_us", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userLogin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userRegister",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRegister", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Descreption = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    Poster = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prod_Categ_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ci",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ci", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_ci_prod_ProductId",
                        column: x => x.ProductId,
                        principalTable: "prod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ci_us_UserId",
                        column: x => x.UserId,
                        principalTable: "us",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rev",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId1 = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rev", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_rev_prod_ProductId",
                        column: x => x.ProductId,
                        principalTable: "prod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rev_prod_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "prod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_rev_us_UserId",
                        column: x => x.UserId,
                        principalTable: "us",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rev_us_UserId1",
                        column: x => x.UserId1,
                        principalTable: "us",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "wl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wl_prod_ProductId",
                        column: x => x.ProductId,
                        principalTable: "prod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_wl_us_UserId",
                        column: x => x.UserId,
                        principalTable: "us",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "od",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_od", x => x.Id);
                    table.ForeignKey(
                        name: "FK_od_ci_CartItemId",
                        column: x => x.CartItemId,
                        principalTable: "ci",
                        principalColumn: "CartItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ci_ProductId",
                table: "ci",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ci_UserId",
                table: "ci",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_od_CartItemId",
                table: "od",
                column: "CartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_prod_CategoryId",
                table: "prod",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_rev_ProductId",
                table: "rev",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_rev_ProductId1",
                table: "rev",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_rev_UserId",
                table: "rev",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_rev_UserId1",
                table: "rev",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_wl_ProductId",
                table: "wl",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_wl_UserId",
                table: "wl",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adm");

            migrationBuilder.DropTable(
                name: "bl");

            migrationBuilder.DropTable(
                name: "od");

            migrationBuilder.DropTable(
                name: "resetPassword");

            migrationBuilder.DropTable(
                name: "rev");

            migrationBuilder.DropTable(
                name: "userLogin");

            migrationBuilder.DropTable(
                name: "userRegister");

            migrationBuilder.DropTable(
                name: "wl");

            migrationBuilder.DropTable(
                name: "ci");

            migrationBuilder.DropTable(
                name: "prod");

            migrationBuilder.DropTable(
                name: "us");

            migrationBuilder.DropTable(
                name: "Categ");
        }
    }
}
