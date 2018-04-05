using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HedHome.Data.Migrations
{
    public partial class RemoveCityFromCampus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campuses_Cities_CityId",
                table: "Campuses");

            migrationBuilder.DropIndex(
                name: "IX_Campuses_CityId",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Campuses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Campuses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_CityId",
                table: "Campuses",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campuses_Cities_CityId",
                table: "Campuses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
