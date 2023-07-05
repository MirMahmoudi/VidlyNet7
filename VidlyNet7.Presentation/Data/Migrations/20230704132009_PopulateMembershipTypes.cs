using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyNet7.Presentation.Data.Migrations
{
	/// <inheritdoc />
	public partial class PopulateMembershipTypes : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "MembershipTypes",
				columns: new[] { "Id", "Name", "SignUpFee", "DurationInMonth", "DiscountRate" },
				values: new object[] { 1, "Pay as You Go", 0, 0, 0 }
			);
			migrationBuilder.InsertData(
				table: "MembershipTypes",
				columns: new[] { "Id", "Name", "SignUpFee", "DurationInMonth", "DiscountRate" },
				values: new object[] { 2, "Monthly", 30, 1, 10 }
			);
			migrationBuilder.InsertData(
				table: "MembershipTypes",
				columns: new[] { "Id", "Name", "SignUpFee", "DurationInMonth", "DiscountRate" },
				values: new object[] { 3, "Quaterly", 90, 3, 15 }
			);
			migrationBuilder.InsertData(
				table: "MembershipTypes",
				columns: new[] { "Id", "Name", "SignUpFee", "DurationInMonth", "DiscountRate" },
				values: new object[] { 4, "Annual", 300, 12, 20 }
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "MembershipTypes",
				keyColumn: "Id",
				keyValues: new object[] { 1, 2, 3, 4 }
			);
		}
	}
}
