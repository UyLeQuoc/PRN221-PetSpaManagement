using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "SpaPackage");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PackageService");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "User",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "User",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "User",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "User",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "SpaPackage",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "SpaPackage",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "SpaPackage",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "SpaPackage",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Service",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Service",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Service",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Service",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Role",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Role",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Role",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Role",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Review",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Review",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Review",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Review",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Pet",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Pet",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Pet",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Pet",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Payment",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Payment",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Payment",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Payment",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "PackageService",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "PackageService",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "PackageService",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "PackageService",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Appointment",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Appointment",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Appointment",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Appointment",
                newName: "DeletedBy");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "User",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "SpaPackage",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SpaPackage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Service",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Service",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Role",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Review",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Pet",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Pet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Payment",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Payment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "PackageService",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PackageService",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Appointment",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SpaPackage");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PackageService");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "User",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "User",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "User",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "User",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "SpaPackage",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "SpaPackage",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "SpaPackage",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "SpaPackage",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Service",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Service",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Service",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Service",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Role",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Role",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Role",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Role",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Review",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Review",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Review",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Review",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Pet",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Pet",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Pet",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Pet",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Payment",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Payment",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Payment",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Payment",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "PackageService",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "PackageService",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "PackageService",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "PackageService",
                newName: "DeletionDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Appointment",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Appointment",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Appointment",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Appointment",
                newName: "DeletionDate");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "SpaPackage",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "SpaPackage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Service",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Service",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Role",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Role",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Review",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Review",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Pet",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Pet",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Payment",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Payment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "PackageService",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PackageService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Appointment",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Appointment",
                type: "datetime2",
                nullable: true);
        }
    }
}
