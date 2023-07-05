using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyNet7.Presentation.Data.Migrations
{
	/// <inheritdoc />
	public partial class PopulateGenres : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new []{ "Id", "Name" },
				values: new object[]{ 1, "Action" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 2, "Adventure" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 3, "Animation" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 4, "Biography" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 5, "Comedy" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 6, "Crime" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 7, "Documentary" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 8, "Drama" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 9, "Family" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 10, "Fantasy" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 11, "History" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 12, "Horror" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 13, "Musical" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 14, "Mystery" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 15, "News" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 16, "Romance" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 17, "Science Fiction" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 18, "Sport" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 19, "Thriller" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 20, "War" }
			);
			migrationBuilder.InsertData(
				table: "Genres",
				columns: new[] { "Id", "Name" },
				values: new object[] { 21, "Western" }
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Genres",
				keyColumn: "Id",
				keyValues: new object[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 ,21 }
			);
		}
	}
}
