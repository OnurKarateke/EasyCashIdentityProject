using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashIdentityProject.DataAccessLayer.Migrations
{
    public partial class mig_customer_relation_process : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProcessType",
                table: "CustomerAccountsProcesses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverID",
                table: "CustomerAccountsProcesses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderID",
                table: "CustomerAccountsProcesses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerAccountCurrency",
                table: "CustomerAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountsProcesses_ReceiverID",
                table: "CustomerAccountsProcesses",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountsProcesses_SenderID",
                table: "CustomerAccountsProcesses",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountsProcesses_CustomerAccounts_ReceiverID",
                table: "CustomerAccountsProcesses",
                column: "ReceiverID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountsProcesses_CustomerAccounts_SenderID",
                table: "CustomerAccountsProcesses",
                column: "SenderID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountsProcesses_CustomerAccounts_ReceiverID",
                table: "CustomerAccountsProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountsProcesses_CustomerAccounts_SenderID",
                table: "CustomerAccountsProcesses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountsProcesses_ReceiverID",
                table: "CustomerAccountsProcesses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountsProcesses_SenderID",
                table: "CustomerAccountsProcesses");

            migrationBuilder.DropColumn(
                name: "ReceiverID",
                table: "CustomerAccountsProcesses");

            migrationBuilder.DropColumn(
                name: "SenderID",
                table: "CustomerAccountsProcesses");

            migrationBuilder.DropColumn(
                name: "CustomerAccountCurrency",
                table: "CustomerAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessType",
                table: "CustomerAccountsProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
