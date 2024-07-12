using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Appointment_Pet_fk",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "Appointment_SpaPackage_fk",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "PackageService_Service_fk",
                table: "PackageService");

            migrationBuilder.DropForeignKey(
                name: "PackageService_SpaPackage_fk",
                table: "PackageService");

            migrationBuilder.DropForeignKey(
                name: "Payment_Appointment_fk",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_User_UserId",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "User_Role_fk",
                table: "User");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "SpaPackage_pk",
                table: "SpaPackage");

            migrationBuilder.DropPrimaryKey(
                name: "Service_pk",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PackageService_pk",
                table: "PackageService");

            migrationBuilder.DropPrimaryKey(
                name: "User_pk",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "Role_pk",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "Pet_pk",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "Payment_pk",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "Appointment_pk",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "SpaPackage");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PackageService");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Pet",
                newName: "Pets");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

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
                table: "Users",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Users",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Users",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Users",
                newName: "DeletedBy");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Roles",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Roles",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Roles",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Roles",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Pets",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Pets",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Pets",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Pets",
                newName: "DeletedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_UserId",
                table: "Pets",
                newName: "IX_Pets_UserId");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Payments",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Payments",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Payments",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Payments",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Payments",
                newName: "TotalAmount");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_AppointmentId",
                table: "Payments",
                newName: "IX_Payments_AppointmentId");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Appointments",
                newName: "PetSitterId");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Appointments",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Appointments",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "DeletionDate",
                table: "Appointments",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Appointments",
                newName: "DeletedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_SpaPackageId",
                table: "Appointments",
                newName: "IX_Appointments_SpaPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_PetId",
                table: "Appointments",
                newName: "IX_Appointments_PetId");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "SpaPackage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SpaPackage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "SpaPackage",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SpaPackage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SpaPackage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Service",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Service",
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

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Pets",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Pets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Payments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Appointments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaPackage",
                table: "SpaPackage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageService",
                table: "PackageService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Pets_PetId",
                table: "Appointments",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_SpaPackage_SpaPackageId",
                table: "Appointments",
                column: "SpaPackageId",
                principalTable: "SpaPackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageService_Service_ServiceId",
                table: "PackageService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageService_SpaPackage_SpaPackageId",
                table: "PackageService",
                column: "SpaPackageId",
                principalTable: "SpaPackage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Appointments_AppointmentId",
                table: "Payments",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_UserId",
                table: "Pets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Pets_PetId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_SpaPackage_SpaPackageId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageService_Service_ServiceId",
                table: "PackageService");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageService_SpaPackage_SpaPackageId",
                table: "PackageService");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Appointments_AppointmentId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_UserId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaPackage",
                table: "SpaPackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageService",
                table: "PackageService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SpaPackage");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PackageService");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "Pet");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

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

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

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

            migrationBuilder.RenameIndex(
                name: "IX_Pets_UserId",
                table: "Pet",
                newName: "IX_Pet_UserId");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Payment",
                newName: "Amount");

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

            migrationBuilder.RenameIndex(
                name: "IX_Payments_AppointmentId",
                table: "Payment",
                newName: "IX_Payment_AppointmentId");

            migrationBuilder.RenameColumn(
                name: "PetSitterId",
                table: "Appointment",
                newName: "StaffId");

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

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_SpaPackageId",
                table: "Appointment",
                newName: "IX_Appointment_SpaPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PetId",
                table: "Appointment",
                newName: "IX_Appointment_PetId");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "SpaPackage",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SpaPackage",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "SpaPackage",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SpaPackage",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "SpaPackage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Service",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Service",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Service",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Service",
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

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Pet",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pet",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Payment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Payment",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Payment",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Payment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Appointment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Appointment",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Appointment",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Appointment",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Appointment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "SpaPackage_pk",
                table: "SpaPackage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Service_pk",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PackageService_pk",
                table: "PackageService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "User_pk",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Role_pk",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Pet_pk",
                table: "Pet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Payment_pk",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Appointment_pk",
                table: "Appointment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModificationBy = table.Column<int>(type: "int", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Review_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Review_Appointment_fk",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Review_User_fk",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_AppointmentId",
                table: "Review",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "Appointment_Pet_fk",
                table: "Appointment",
                column: "PetId",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Appointment_SpaPackage_fk",
                table: "Appointment",
                column: "SpaPackageId",
                principalTable: "SpaPackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "PackageService_Service_fk",
                table: "PackageService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "PackageService_SpaPackage_fk",
                table: "PackageService",
                column: "SpaPackageId",
                principalTable: "SpaPackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Payment_Appointment_fk",
                table: "Payment",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_User_UserId",
                table: "Pet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "User_Role_fk",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
