using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HedHome.Data.Migrations
{
    public partial class SimplifyCampus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campuses_Institutions_InstitutionId",
                table: "Campuses");

            migrationBuilder.DropIndex(
                name: "IX_Campuses_InstitutionId",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Campuses");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CityId",
                table: "Courses",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Cities_CityId",
                table: "Courses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Cities_CityId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CityId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "Campuses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_InstitutionId",
                table: "Campuses",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campuses_Institutions_InstitutionId",
                table: "Campuses",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
