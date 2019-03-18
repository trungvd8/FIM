using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ADGroupContent = table.Column<string>(type: "NCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetGeography",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(type: "NCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetGeography", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    ExpertId = table.Column<Guid>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: true),
                    Level = table.Column<byte>(nullable: false),
                    ParentCategoryId = table.Column<Guid>(nullable: true),
                    MasterContractId = table.Column<Guid>(nullable: true),
                    CategoryOrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryOrganizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryOrganizationContent = table.Column<string>(type: "NCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryOrganizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExpertContent = table.Column<string>(type: "NCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MasterContractContent = table.Column<string>(type: "NCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterContracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(type: "NCHAR(10)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    TaxCode = table.Column<string>(type: "NCHAR(10)", nullable: false),
                    Version = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrganizationUnitId = table.Column<Guid>(nullable: true),
                    ADGroupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(type: "NCHAR(10)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Version = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParentCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParentCategoryContent = table.Column<string>(type: "NCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PurchaseRequestId = table.Column<Guid>(nullable: false),
                    RFQId = table.Column<Guid>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: true),
                    Unit = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    RequestQuantity = table.Column<int>(nullable: false),
                    InstockQuantity = table.Column<int>(nullable: false),
                    PurchaseQuantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<int>(nullable: false),
                    Price = table.Column<long>(nullable: false),
                    RemainQuantity = table.Column<int>(nullable: true),
                    TaxType = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    TaxAmount = table.Column<long>(nullable: false),
                    Total = table.Column<long>(nullable: false),
                    Note = table.Column<string>(type: "NVARCHAR(150)", nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Status = table.Column<string>(type: "NCHAR(10)", nullable: false),
                    RootCategoryId = table.Column<Guid>(nullable: true),
                    SubRootCategoryId = table.Column<Guid>(nullable: true),
                    FileId = table.Column<Guid>(nullable: true),
                    BudgetOrganizationId = table.Column<Guid>(nullable: true),
                    BudgetOrganizationUnitId = table.Column<Guid>(nullable: true),
                    BudgetGeoId = table.Column<Guid>(nullable: true),
                    BudgetPeriod = table.Column<string>(type: "NCHAR(10)", nullable: false),
                    ProjectId = table.Column<Guid>(nullable: true),
                    ProjectBudgetId = table.Column<Guid>(nullable: true),
                    RequestCreateDate = table.Column<DateTime>(nullable: false),
                    RequestOrganizationId = table.Column<Guid>(nullable: true),
                    RequestOrganizationUnitId = table.Column<Guid>(nullable: true),
                    RequestUserId = table.Column<Guid>(nullable: true),
                    RequestPhoneNumber = table.Column<string>(type: "NCHAR(20)", nullable: false),
                    ReceiptDate = table.Column<DateTime>(nullable: true),
                    ReceiveAddress = table.Column<string>(type: "NVARCHAR(150)", nullable: true),
                    ReceiveOrganizationId = table.Column<Guid>(nullable: true),
                    ReceiveOrganizationUnitId = table.Column<Guid>(nullable: true),
                    ReceiveUserId = table.Column<Guid>(nullable: true),
                    ReceivePhoneNumber = table.Column<string>(type: "NCHAR(20)", nullable: true),
                    BOMApprover = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    FADApprover = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    FPDApprover = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR(150)", nullable: true),
                    Instock = table.Column<string>(type: "NCHAR(50)", nullable: true),
                    VendorId = table.Column<Guid>(nullable: true),
                    Note = table.Column<string>(type: "NVARCHAR(150)", nullable: true),
                    BudgetRemaining = table.Column<string>(type: "NCHAR(150)", nullable: true),
                    FrameContract = table.Column<bool>(nullable: false),
                    Total = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuotationByVendors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(type: "NCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationByVendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuotationHeaderId = table.Column<Guid>(nullable: false),
                    RFQDetailId = table.Column<Guid>(nullable: false),
                    UnitPrice = table.Column<int>(nullable: true),
                    Price = table.Column<long>(nullable: true),
                    TaxType = table.Column<string>(type: "NCHAR(10)", nullable: false),
                    TaxAmount = table.Column<long>(nullable: true),
                    Total = table.Column<long>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    NoteForVendor = table.Column<DateTime>(nullable: false),
                    VendorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestForQuotations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    ReceivedAddress = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    OrganizationUnitId = table.Column<Guid>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    HandlerId = table.Column<Guid>(nullable: false),
                    SubRootCategoryId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    FileId = table.Column<Guid>(nullable: true),
                    QuotationByVendorId = table.Column<Guid>(nullable: true),
                    PurchaseRequestId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestForQuotations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFQDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RFQId = table.Column<Guid>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: true),
                    SubRootCategoryId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    Quantity = table.Column<long>(nullable: false),
                    Unit = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    Note = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    NoteForVendor = table.Column<DateTime>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    Order = table.Column<byte>(nullable: false),
                    QuotationId = table.Column<Guid>(nullable: true),
                    VendorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFQMailCCs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RFQId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQMailCCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFQWorkflows",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RFQId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Time = table.Column<DateTime>(nullable: true),
                    Reason = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    Level = table.Column<byte>(nullable: true),
                    Status = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQWorkflows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(type: "NCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Display = table.Column<string>(type: "NCHAR(50)", nullable: false),
                    Name = table.Column<string>(type: "NCHAR(50)", nullable: false),
                    ADGroupId = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: true),
                    Token = table.Column<string>(type: "XML", nullable: false),
                    Version = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "NCHAR(100)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    TaxCode = table.Column<string>(type: "NCHAR(10)", nullable: false),
                    Owner = table.Column<string>(type: "NCHAR(50)", nullable: false),
                    Phone = table.Column<string>(type: "NCHAR(20)", nullable: false),
                    Email = table.Column<string>(type: "NCHAR(150)", nullable: true),
                    Website = table.Column<string>(type: "NCHAR(150)", nullable: true),
                    BankAccount = table.Column<string>(type: "NCHAR(150)", nullable: true),
                    Bank = table.Column<string>(type: "NVARCHAR(150)", nullable: true),
                    BankBranch = table.Column<string>(type: "NVARCHAR(150)", nullable: true),
                    IsLock = table.Column<bool>(nullable: false),
                    Approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADGroups");

            migrationBuilder.DropTable(
                name: "BudgetGeography");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryOrganizations");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "MasterContracts");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "OrganizationUnits");

            migrationBuilder.DropTable(
                name: "ParentCategories");

            migrationBuilder.DropTable(
                name: "PRDetails");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "QuotationByVendors");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "RequestForQuotations");

            migrationBuilder.DropTable(
                name: "RFQDetails");

            migrationBuilder.DropTable(
                name: "RFQMailCCs");

            migrationBuilder.DropTable(
                name: "RFQWorkflows");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
