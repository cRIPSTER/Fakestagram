﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fakestagram.Migrations
{
    /// <inheritdoc />
    public partial class AddedUpdateTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Posts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Posts");
        }
    }
}
