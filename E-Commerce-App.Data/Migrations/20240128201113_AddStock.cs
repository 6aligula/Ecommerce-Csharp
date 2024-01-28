using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Data.Migrations
{
    public partial class AddStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountInStock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 409, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 409, DateTimeKind.Local).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 409, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(9925));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(9981));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 409, DateTimeKind.Local).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 409, DateTimeKind.Local).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 406, DateTimeKind.Local).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "10",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "11",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "12",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "13",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "14",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "15",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "16",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "17",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "18",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "19",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "20",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "21",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "22",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "23",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "24",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "25",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "26",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "27",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "28",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "29",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "30",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "31",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "32",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "7",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "8",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "9",
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 21, 11, 13, 408, DateTimeKind.Local).AddTicks(4388));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountInStock",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 397, DateTimeKind.Local).AddTicks(3201));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 397, DateTimeKind.Local).AddTicks(3321));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 397, DateTimeKind.Local).AddTicks(3326));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 393, DateTimeKind.Local).AddTicks(5773));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "10",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "11",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4404));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "12",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "13",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "14",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "15",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4416));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "16",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "17",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "18",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "19",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "20",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "21",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "22",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "23",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "24",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "25",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "26",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "27",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "28",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "29",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "30",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "31",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "32",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "7",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "8",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "9",
                column: "CreationDate",
                value: new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4397));
        }
    }
}
