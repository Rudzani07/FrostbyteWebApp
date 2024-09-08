using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FrostbyteWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Departments_DepIDDepartmentID",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banks",
                table: "Banks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "084fbf0e-2cf4-4763-87bb-fb4241890c65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36889756-c941-44fc-a316-885d3059512d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37cec398-8ec2-4261-9b1a-c7299256d081");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "527c3239-8b62-47b4-b56e-a752ff8d7696");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acc361c0-d3ff-4057-affd-fc85758ff51f");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "InventoryLiaisons");

            migrationBuilder.RenameTable(
                name: "Banks",
                newName: "Banks1");

            migrationBuilder.RenameColumn(
                name: "UserBankID",
                table: "UserTypes",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "InventoryLiaisonID",
                table: "Suppliers",
                newName: "SupplierID");

            migrationBuilder.RenameColumn(
                name: "SupplierRequestForQuotation",
                table: "SupplierRequestForQuotations",
                newName: "SupplierRequestForQuotationID");

            migrationBuilder.RenameColumn(
                name: "SupplierPmRequestForQoutationID",
                table: "SendSupplierRequestForQuotations",
                newName: "SupplierRequestForQoutationID");

            migrationBuilder.RenameColumn(
                name: "PurchasingID",
                table: "SendDeliveryNotes",
                newName: "PurchasingManagerID");

            migrationBuilder.RenameColumn(
                name: "InventoryLiaisonID",
                table: "PurchasingManagers",
                newName: "PurchasingManagerID");

            migrationBuilder.RenameColumn(
                name: "InventoryLiaisonID",
                table: "Clients",
                newName: "ClientID");

            migrationBuilder.RenameColumn(
                name: "DepIDDepartmentID",
                table: "Admins",
                newName: "DepartmentID");

            migrationBuilder.RenameColumn(
                name: "InventoryLiaisonID",
                table: "Admins",
                newName: "AdminID");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_DepIDDepartmentID",
                table: "Admins",
                newName: "IX_Admins_DepartmentID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "UserTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "SendPurchasingRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PurchasingRequestID",
                table: "SendPurchasingRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierID",
                table: "SendPurchasingRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PmRequestForQoutationID",
                table: "SendPmRequestForQuotation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SendOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "SendOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierID",
                table: "SendOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrdersOrderID",
                table: "SendDeliveryNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PRPurchasingRequestID",
                table: "SendDeliveryNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PMPurchasingManagerID",
                table: "PmrequestForQoutations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BankUserBankID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sRFQSendSupplierPmRequestForQoutationID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "DeliveryNotes",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Department",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banks1",
                table: "Banks1",
                column: "UserBankID");

            migrationBuilder.CreateTable(
                name: "PurchasingRequest",
                columns: table => new
                {
                    PurchasingRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InventoryLiaisonID = table.Column<int>(type: "int", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    ItemModel = table.Column<int>(type: "int", nullable: false),
                    ItemSerialNumber = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EstimatedPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasingRequest", x => x.PurchasingRequestID);
                    table.ForeignKey(
                        name: "FK_PurchasingRequest_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasingRequest_InventoryLiaisons_InventoryLiaisonID",
                        column: x => x.InventoryLiaisonID,
                        principalTable: "InventoryLiaisons",
                        principalColumn: "InventoryLiaisonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "167343bb-552c-47d8-afc4-27c75aefc17e", null, "supplier", "supplier" },
                    { "8e5f65b2-e6f8-4199-a940-e2611fa158d5", null, "InventoryLiaison", "InventoryLiaison" },
                    { "97310d92-0d0e-42a8-b9e4-ff4b388355de", null, "admin", "admin" },
                    { "bcb8e408-b9c7-4196-8741-6734cad93308", null, "client", "client" },
                    { "d25cb9ca-66e8-4bc9-b0c5-b6f56400ca44", null, "PurchaseManager", "PurchasingManager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_AdminID",
                table: "UserTypes",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_ClientID",
                table: "UserTypes",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_InventoryLiaisonID",
                table: "UserTypes",
                column: "InventoryLiaisonID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_PurchasingManagerID",
                table: "UserTypes",
                column: "PurchasingManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_SupplierID",
                table: "UserTypes",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierRequestForQuotations_DepartmentID",
                table: "SupplierRequestForQuotations",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_SendSupplierRequestForQuotations_PurchasingManagerID",
                table: "SendSupplierRequestForQuotations",
                column: "PurchasingManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_SendSupplierRequestForQuotations_SupplierRequestForQoutationID",
                table: "SendSupplierRequestForQuotations",
                column: "SupplierRequestForQoutationID");

            migrationBuilder.CreateIndex(
                name: "IX_SendPurchasingRequests_PurchasingRequestID",
                table: "SendPurchasingRequests",
                column: "PurchasingRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_SendPurchasingRequests_SupplierID",
                table: "SendPurchasingRequests",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_SendPmRequestForQuotation_PmRequestForQoutationID",
                table: "SendPmRequestForQuotation",
                column: "PmRequestForQoutationID");

            migrationBuilder.CreateIndex(
                name: "IX_SendPmRequestForQuotation_SupplierID",
                table: "SendPmRequestForQuotation",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_SendOrders_OrderID",
                table: "SendOrders",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SendOrders_SupplierID",
                table: "SendOrders",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_SendDeliveryNotes_OrdersOrderID",
                table: "SendDeliveryNotes",
                column: "OrdersOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SendDeliveryNotes_PRPurchasingRequestID",
                table: "SendDeliveryNotes",
                column: "PRPurchasingRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_SendDeliveryNotes_PurchasingManagerID",
                table: "SendDeliveryNotes",
                column: "PurchasingManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_PmrequestForQoutations_PMPurchasingManagerID",
                table: "PmrequestForQoutations",
                column: "PMPurchasingManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_PmrequestForQoutations_PurchasingRequestID",
                table: "PmrequestForQoutations",
                column: "PurchasingRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BankUserBankID",
                table: "Orders",
                column: "BankUserBankID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_sRFQSendSupplierPmRequestForQoutationID",
                table: "Orders",
                column: "sRFQSendSupplierPmRequestForQoutationID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNotes_SupplierID",
                table: "DeliveryNotes",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingRequest_DepartmentID",
                table: "PurchasingRequest",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingRequest_InventoryLiaisonID",
                table: "PurchasingRequest",
                column: "InventoryLiaisonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Departments_DepartmentID",
                table: "Admins",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNotes_Suppliers_SupplierID",
                table: "DeliveryNotes",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Banks1_BankUserBankID",
                table: "Orders",
                column: "BankUserBankID",
                principalTable: "Banks1",
                principalColumn: "UserBankID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SendSupplierRequestForQuotations_sRFQSendSupplierPmRequestForQoutationID",
                table: "Orders",
                column: "sRFQSendSupplierPmRequestForQoutationID",
                principalTable: "SendSupplierRequestForQuotations",
                principalColumn: "SendSupplierPmRequestForQoutationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmrequestForQoutations_PurchasingManagers_PMPurchasingManagerID",
                table: "PmrequestForQoutations",
                column: "PMPurchasingManagerID",
                principalTable: "PurchasingManagers",
                principalColumn: "PurchasingManagerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmrequestForQoutations_PurchasingRequest_PurchasingRequestID",
                table: "PmrequestForQoutations",
                column: "PurchasingRequestID",
                principalTable: "PurchasingRequest",
                principalColumn: "PurchasingRequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendDeliveryNotes_Orders_OrdersOrderID",
                table: "SendDeliveryNotes",
                column: "OrdersOrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendDeliveryNotes_PurchasingManagers_PurchasingManagerID",
                table: "SendDeliveryNotes",
                column: "PurchasingManagerID",
                principalTable: "PurchasingManagers",
                principalColumn: "PurchasingManagerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendDeliveryNotes_PurchasingRequest_PRPurchasingRequestID",
                table: "SendDeliveryNotes",
                column: "PRPurchasingRequestID",
                principalTable: "PurchasingRequest",
                principalColumn: "PurchasingRequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendOrders_Orders_OrderID",
                table: "SendOrders",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendOrders_Suppliers_SupplierID",
                table: "SendOrders",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendPmRequestForQuotation_PmrequestForQoutations_PmRequestForQoutationID",
                table: "SendPmRequestForQuotation",
                column: "PmRequestForQoutationID",
                principalTable: "PmrequestForQoutations",
                principalColumn: "PmRequestForQoutationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendPmRequestForQuotation_Suppliers_SupplierID",
                table: "SendPmRequestForQuotation",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendPurchasingRequests_PurchasingRequest_PurchasingRequestID",
                table: "SendPurchasingRequests",
                column: "PurchasingRequestID",
                principalTable: "PurchasingRequest",
                principalColumn: "PurchasingRequestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendPurchasingRequests_Suppliers_SupplierID",
                table: "SendPurchasingRequests",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendSupplierRequestForQuotations_PurchasingManagers_PurchasingManagerID",
                table: "SendSupplierRequestForQuotations",
                column: "PurchasingManagerID",
                principalTable: "PurchasingManagers",
                principalColumn: "PurchasingManagerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SendSupplierRequestForQuotations_SupplierRequestForQuotations_SupplierRequestForQoutationID",
                table: "SendSupplierRequestForQuotations",
                column: "SupplierRequestForQoutationID",
                principalTable: "SupplierRequestForQuotations",
                principalColumn: "SupplierRequestForQuotationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierRequestForQuotations_Departments_DepartmentID",
                table: "SupplierRequestForQuotations",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_Admins_AdminID",
                table: "UserTypes",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_Clients_ClientID",
                table: "UserTypes",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_InventoryLiaisons_InventoryLiaisonID",
                table: "UserTypes",
                column: "InventoryLiaisonID",
                principalTable: "InventoryLiaisons",
                principalColumn: "InventoryLiaisonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_PurchasingManagers_PurchasingManagerID",
                table: "UserTypes",
                column: "PurchasingManagerID",
                principalTable: "PurchasingManagers",
                principalColumn: "PurchasingManagerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_Suppliers_SupplierID",
                table: "UserTypes",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Departments_DepartmentID",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNotes_Suppliers_SupplierID",
                table: "DeliveryNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Banks1_BankUserBankID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SendSupplierRequestForQuotations_sRFQSendSupplierPmRequestForQoutationID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PmrequestForQoutations_PurchasingManagers_PMPurchasingManagerID",
                table: "PmrequestForQoutations");

            migrationBuilder.DropForeignKey(
                name: "FK_PmrequestForQoutations_PurchasingRequest_PurchasingRequestID",
                table: "PmrequestForQoutations");

            migrationBuilder.DropForeignKey(
                name: "FK_SendDeliveryNotes_Orders_OrdersOrderID",
                table: "SendDeliveryNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_SendDeliveryNotes_PurchasingManagers_PurchasingManagerID",
                table: "SendDeliveryNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_SendDeliveryNotes_PurchasingRequest_PRPurchasingRequestID",
                table: "SendDeliveryNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_SendOrders_Orders_OrderID",
                table: "SendOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SendOrders_Suppliers_SupplierID",
                table: "SendOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SendPmRequestForQuotation_PmrequestForQoutations_PmRequestForQoutationID",
                table: "SendPmRequestForQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SendPmRequestForQuotation_Suppliers_SupplierID",
                table: "SendPmRequestForQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SendPurchasingRequests_PurchasingRequest_PurchasingRequestID",
                table: "SendPurchasingRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SendPurchasingRequests_Suppliers_SupplierID",
                table: "SendPurchasingRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SendSupplierRequestForQuotations_PurchasingManagers_PurchasingManagerID",
                table: "SendSupplierRequestForQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_SendSupplierRequestForQuotations_SupplierRequestForQuotations_SupplierRequestForQoutationID",
                table: "SendSupplierRequestForQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierRequestForQuotations_Departments_DepartmentID",
                table: "SupplierRequestForQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_Admins_AdminID",
                table: "UserTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_Clients_ClientID",
                table: "UserTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_InventoryLiaisons_InventoryLiaisonID",
                table: "UserTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_PurchasingManagers_PurchasingManagerID",
                table: "UserTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_Suppliers_SupplierID",
                table: "UserTypes");

            migrationBuilder.DropTable(
                name: "PurchasingRequest");

            migrationBuilder.DropIndex(
                name: "IX_UserTypes_AdminID",
                table: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_UserTypes_ClientID",
                table: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_UserTypes_InventoryLiaisonID",
                table: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_UserTypes_PurchasingManagerID",
                table: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_UserTypes_SupplierID",
                table: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_SupplierRequestForQuotations_DepartmentID",
                table: "SupplierRequestForQuotations");

            migrationBuilder.DropIndex(
                name: "IX_SendSupplierRequestForQuotations_PurchasingManagerID",
                table: "SendSupplierRequestForQuotations");

            migrationBuilder.DropIndex(
                name: "IX_SendSupplierRequestForQuotations_SupplierRequestForQoutationID",
                table: "SendSupplierRequestForQuotations");

            migrationBuilder.DropIndex(
                name: "IX_SendPurchasingRequests_PurchasingRequestID",
                table: "SendPurchasingRequests");

            migrationBuilder.DropIndex(
                name: "IX_SendPurchasingRequests_SupplierID",
                table: "SendPurchasingRequests");

            migrationBuilder.DropIndex(
                name: "IX_SendPmRequestForQuotation_PmRequestForQoutationID",
                table: "SendPmRequestForQuotation");

            migrationBuilder.DropIndex(
                name: "IX_SendPmRequestForQuotation_SupplierID",
                table: "SendPmRequestForQuotation");

            migrationBuilder.DropIndex(
                name: "IX_SendOrders_OrderID",
                table: "SendOrders");

            migrationBuilder.DropIndex(
                name: "IX_SendOrders_SupplierID",
                table: "SendOrders");

            migrationBuilder.DropIndex(
                name: "IX_SendDeliveryNotes_OrdersOrderID",
                table: "SendDeliveryNotes");

            migrationBuilder.DropIndex(
                name: "IX_SendDeliveryNotes_PRPurchasingRequestID",
                table: "SendDeliveryNotes");

            migrationBuilder.DropIndex(
                name: "IX_SendDeliveryNotes_PurchasingManagerID",
                table: "SendDeliveryNotes");

            migrationBuilder.DropIndex(
                name: "IX_PmrequestForQoutations_PMPurchasingManagerID",
                table: "PmrequestForQoutations");

            migrationBuilder.DropIndex(
                name: "IX_PmrequestForQoutations_PurchasingRequestID",
                table: "PmrequestForQoutations");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BankUserBankID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_sRFQSendSupplierPmRequestForQoutationID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryNotes_SupplierID",
                table: "DeliveryNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banks1",
                table: "Banks1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "167343bb-552c-47d8-afc4-27c75aefc17e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e5f65b2-e6f8-4199-a940-e2611fa158d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97310d92-0d0e-42a8-b9e4-ff4b388355de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcb8e408-b9c7-4196-8741-6734cad93308");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d25cb9ca-66e8-4bc9-b0c5-b6f56400ca44");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "SendPurchasingRequests");

            migrationBuilder.DropColumn(
                name: "PurchasingRequestID",
                table: "SendPurchasingRequests");

            migrationBuilder.DropColumn(
                name: "SupplierID",
                table: "SendPurchasingRequests");

            migrationBuilder.DropColumn(
                name: "PmRequestForQoutationID",
                table: "SendPmRequestForQuotation");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SendOrders");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "SendOrders");

            migrationBuilder.DropColumn(
                name: "SupplierID",
                table: "SendOrders");

            migrationBuilder.DropColumn(
                name: "OrdersOrderID",
                table: "SendDeliveryNotes");

            migrationBuilder.DropColumn(
                name: "PRPurchasingRequestID",
                table: "SendDeliveryNotes");

            migrationBuilder.DropColumn(
                name: "PMPurchasingManagerID",
                table: "PmrequestForQoutations");

            migrationBuilder.DropColumn(
                name: "BankUserBankID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "sRFQSendSupplierPmRequestForQoutationID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Banks1",
                newName: "Banks");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserTypes",
                newName: "UserBankID");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "Suppliers",
                newName: "InventoryLiaisonID");

            migrationBuilder.RenameColumn(
                name: "SupplierRequestForQuotationID",
                table: "SupplierRequestForQuotations",
                newName: "SupplierRequestForQuotation");

            migrationBuilder.RenameColumn(
                name: "SupplierRequestForQoutationID",
                table: "SendSupplierRequestForQuotations",
                newName: "SupplierPmRequestForQoutationID");

            migrationBuilder.RenameColumn(
                name: "PurchasingManagerID",
                table: "SendDeliveryNotes",
                newName: "PurchasingID");

            migrationBuilder.RenameColumn(
                name: "PurchasingManagerID",
                table: "PurchasingManagers",
                newName: "InventoryLiaisonID");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Clients",
                newName: "InventoryLiaisonID");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Admins",
                newName: "DepIDDepartmentID");

            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "Admins",
                newName: "InventoryLiaisonID");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_DepartmentID",
                table: "Admins",
                newName: "IX_Admins_DepIDDepartmentID");

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "InventoryLiaisons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SupplierID",
                table: "DeliveryNotes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Department",
                table: "Admins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banks",
                table: "Banks",
                column: "UserBankID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "084fbf0e-2cf4-4763-87bb-fb4241890c65", null, "InventoryLiaison", "InventoryLiaison" },
                    { "36889756-c941-44fc-a316-885d3059512d", null, "PurchaseManager", "PurchasingManager" },
                    { "37cec398-8ec2-4261-9b1a-c7299256d081", null, "supplier", "supplier" },
                    { "527c3239-8b62-47b4-b56e-a752ff8d7696", null, "client", "client" },
                    { "acc361c0-d3ff-4057-affd-fc85758ff51f", null, "admin", "admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Departments_DepIDDepartmentID",
                table: "Admins",
                column: "DepIDDepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
