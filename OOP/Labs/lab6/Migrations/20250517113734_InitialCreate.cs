using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KNP_Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Authors",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
            //        Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Authors", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Books",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FilePath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
            //        SmallDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        AmountAvailible = table.Column<int>(type: "int", nullable: false),
            //        Rating = table.Column<double>(type: "float", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Books", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Genres",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Genres", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Roles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Roles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BookAuthors",
            //    columns: table => new
            //    {
            //        AuthorsId = table.Column<int>(type: "int", nullable: false),
            //        BooksId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BookAuthors", x => new { x.AuthorsId, x.BooksId });
            //        table.ForeignKey(
            //            name: "FK_BookAuthors_Authors_AuthorsId",
            //            column: x => x.AuthorsId,
            //            principalTable: "Authors",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BookAuthors_Books_BooksId",
            //            column: x => x.BooksId,
            //            principalTable: "Books",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BookGenres",
            //    columns: table => new
            //    {
            //        BooksId = table.Column<int>(type: "int", nullable: false),
            //        GenresId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BookGenres", x => new { x.BooksId, x.GenresId });
            //        table.ForeignKey(
            //            name: "FK_BookGenres_Books_BooksId",
            //            column: x => x.BooksId,
            //            principalTable: "Books",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BookGenres_Genres_GenresId",
            //            column: x => x.GenresId,
            //            principalTable: "Genres",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CardId = table.Column<int>(type: "int", nullable: false),
            //        Username = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ProfilePicId = table.Column<int>(type: "int", nullable: false),
            //        RoleId = table.Column<int>(type: "int", nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Users_Roles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Roles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Orders",
            //    columns: table => new
            //    {
            //        OrderId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        BookId = table.Column<int>(type: "int", nullable: false),
            //        IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DueAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Orders", x => x.OrderId);
            //        table.ForeignKey(
            //            name: "FK_Orders_Books_BookId",
            //            column: x => x.BookId,
            //            principalTable: "Books",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Orders_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Reviews",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        Assessment = table.Column<int>(type: "int", nullable: false),
            //        Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        BookId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Reviews", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Reviews_Books_BookId",
            //            column: x => x.BookId,
            //            principalTable: "Books",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Reviews_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Authors_Name_Surname",
            //    table: "Authors",
            //    columns: new[] { "Name", "Surname" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_BookAuthors_BooksId",
            //    table: "BookAuthors",
            //    column: "BooksId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BookGenres_GenresId",
            //    table: "BookGenres",
            //    column: "GenresId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_BookId",
            //    table: "Orders",
            //    column: "BookId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_UserId",
            //    table: "Orders",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reviews_BookId",
            //    table: "Reviews",
            //    column: "BookId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reviews_UserId",
            //    table: "Reviews",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_RoleId",
            //    table: "Users",
            //    column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "BookAuthors");

            //migrationBuilder.DropTable(
            //    name: "BookGenres");

            //migrationBuilder.DropTable(
            //    name: "Orders");

            //migrationBuilder.DropTable(
            //    name: "Reviews");

            //migrationBuilder.DropTable(
            //    name: "Authors");

            //migrationBuilder.DropTable(
            //    name: "Genres");

            //migrationBuilder.DropTable(
            //    name: "Books");

            //migrationBuilder.DropTable(
            //    name: "Users");

            //migrationBuilder.DropTable(
            //    name: "Roles");
        }
    }
}
