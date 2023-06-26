using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirtMigration.Migrations
{
    public partial class TXTCloud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AreaMasters",
                columns: table => new
                {
                    CompanyCode = table.Column<string>(type: "Nvarchar(10)", maxLength: 10, nullable: false),
                    AreaCode = table.Column<string>(type: "Nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaMasters", x => x.CompanyCode);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<string>(type: "varchar(26)", maxLength: 26, nullable: false),
                    NameAuthor = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hometown = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadquartersLastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContentLastUpdateDate = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: true),
                    TotalBook = table.Column<int>(type: "int", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "BankSuports",
                columns: table => new
                {
                    BankID = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: false),
                    BankCode = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Content = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: true),
                    UrlImageBank = table.Column<string>(type: "Nvarchar(MAX)", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankSuports", x => x.BankID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryItemMasters",
                columns: table => new
                {
                    CategoryItemMasterID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeadquartersLastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContentLastUpdateDate = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: true),
                    JobID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItemMasters", x => x.CategoryItemMasterID);
                });

            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    CityID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: false),
                    AreaCode = table.Column<int>(type: "int", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    HeadquartersLastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddressOrders",
                columns: table => new
                {
                    CustomerAddressOrdersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailAddress = table.Column<string>(type: "Nvarchar(200)", maxLength: 200, nullable: false),
                    IsAddressHome = table.Column<bool>(type: "bit", nullable: false),
                    IsAddressDefaul = table.Column<bool>(type: "bit", nullable: false),
                    ShipPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateRegiter = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddressOrders", x => x.CustomerAddressOrdersID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCarts",
                columns: table => new
                {
                    CartID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateAddPrtoduct = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusProduct = table.Column<bool>(type: "bit", nullable: false),
                    PriceSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceOrigin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentReduction = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCarts", x => x.CartID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerReviews",
                columns: table => new
                {
                    ReviewID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: true),
                    StartReview = table.Column<int>(type: "int", nullable: false),
                    Like = table.Column<int>(type: "int", nullable: false),
                    SatisfactionLevelID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityProductsPurchased = table.Column<int>(type: "int", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerReviews", x => x.ReviewID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CityID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarriageID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRegiter = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vip = table.Column<bool>(type: "bit", nullable: false),
                    StatusAccount = table.Column<bool>(type: "bit", nullable: false),
                    JobID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetailAddress = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: false),
                    DescriptionLastUpdateDate = table.Column<string>(type: "Nvarchar(400)", maxLength: 400, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerWallets",
                columns: table => new
                {
                    WalletID = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointCurent = table.Column<int>(type: "int", nullable: false),
                    PointMax = table.Column<int>(type: "int", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PointPlusLastUpdate = table.Column<int>(type: "int", nullable: false),
                    SatusPointLastUpdate = table.Column<bool>(type: "bit", nullable: false),
                    PointMinusLastUpdate = table.Column<int>(type: "int", nullable: false),
                    StatusWallet = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(500)", maxLength: 500, nullable: true),
                    BlockDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerWallets", x => x.WalletID);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identifier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceShip = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PriceShipNew = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LasUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeadquartersLastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictID);
                });

            migrationBuilder.CreateTable(
                name: "FreeShipPrograms",
                columns: table => new
                {
                    FreeShipProgramID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompanyCode = table.Column<string>(type: "Nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(200)", maxLength: 200, nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeShipPrograms", x => x.FreeShipProgramID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LasUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "HistoryWallets",
                columns: table => new
                {
                    HistoryWalletID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointsReceived = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: false),
                    IncreaseOrDecrease = table.Column<bool>(type: "bit", nullable: false),
                    MethodsReceivingPoints = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryWallets", x => x.HistoryWalletID);
                });

            migrationBuilder.CreateTable(
                name: "ImageItemMasters",
                columns: table => new
                {
                    ImageItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url = table.Column<string>(type: "Nvarchar(MAX)", nullable: true),
                    NameImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageItemMasters", x => x.ImageItemID);
                });

            migrationBuilder.CreateTable(
                name: "ImageReviews",
                columns: table => new
                {
                    ImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeImage = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageReviews", x => x.ImageID);
                });

            migrationBuilder.CreateTable(
                name: "IssuingCompanys",
                columns: table => new
                {
                    IssuingCompanyID = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateOfIncorporation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadquartersLastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContentLastUpdateDate = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: true),
                    Address = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuingCompanys", x => x.IssuingCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "ItemMasters",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    CompanyCode = table.Column<string>(type: "Nvarchar(10)", nullable: false),
                    StoreCode = table.Column<string>(type: "Nvarchar(10)", nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionShort = table.Column<string>(type: "Nvarchar(25)", maxLength: 25, nullable: false),
                    DescriptionLong = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    PriceOrigin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentDiscount = table.Column<int>(type: "int", nullable: true),
                    priceSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityDiscountID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PairDiscountID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialDiscountID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Viewer = table.Column<int>(type: "int", nullable: false),
                    Buy = table.Column<int>(type: "int", nullable: false),
                    CategoryItemMasterID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuingCompanyID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    size = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    PublishingCompanyID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSale = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadquartersLastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxGroupCodeID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMasters", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LasUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                });

            migrationBuilder.CreateTable(
                name: "Marriages",
                columns: table => new
                {
                    MarriageID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LasUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marriages", x => x.MarriageID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmountItem = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CityID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddressOrdersID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAddressID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceiveApplication = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptStatusID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethodID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusPayment = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: true),
                    EstimatedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "Nvarchar(500)", maxLength: 500, nullable: true),
                    DateTimeCustomerGetItem = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPoint = table.Column<int>(type: "int", nullable: false),
                    FreeShipProgram = table.Column<bool>(type: "bit", nullable: false),
                    BankID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderCode);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(200)", maxLength: 200, nullable: false),
                    Quatity = table.Column<int>(type: "int", nullable: false),
                    PriceSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityDiscountID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PairDiscountID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialDiscountID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuingCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishingCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusPairDiscount = table.Column<bool>(type: "bit", nullable: true),
                    StatusQuatityDiscount = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetails", x => x.OrderDetailID);
                });

            migrationBuilder.CreateTable(
                name: "PairDiscounts",
                columns: table => new
                {
                    PairDiscountID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PercentReduction = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContentLastUpdateDate = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    Expired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PairDiscounts", x => x.PairDiscountID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LasUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodID);
                });

            migrationBuilder.CreateTable(
                name: "Productsviewedbycustomers",
                columns: table => new
                {
                    ViewerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastDateViewer = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ViewerNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productsviewedbycustomers", x => x.ViewerID);
                });

            migrationBuilder.CreateTable(
                name: "PublishingCompanys",
                columns: table => new
                {
                    PublishingCompanyID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: false),
                    DateCraete = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfIncorporation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadquartersLastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContentLastUpdateDate = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingCompanys", x => x.PublishingCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "QuantityDiscounts",
                columns: table => new
                {
                    QuantityDiscountID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityBy = table.Column<int>(type: "int", nullable: false),
                    PercentReduction = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContentLastUpdateDate = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: true),
                    Expired = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityDiscounts", x => x.QuantityDiscountID);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptPaymentOnlines",
                columns: table => new
                {
                    ReceiptPaymentOnlineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDescription = table.Column<string>(type: "Nvarchar(500)", maxLength: 500, nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "Nvarchar(200)", maxLength: 200, nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    token = table.Column<string>(type: "Nvarchar(MAX)", nullable: false),
                    vnPayResponseCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionExecutionTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    BankPayment = table.Column<string>(type: "Nvarchar(200)", maxLength: 200, nullable: true),
                    BankCode = table.Column<string>(type: "Nvarchar(150)", maxLength: 150, nullable: true),
                    TimeCreate = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptPaymentOnlines", x => x.ReceiptPaymentOnlineID);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptStatus",
                columns: table => new
                {
                    ReceiptStatusID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyCode = table.Column<string>(type: "Nvarchar(10)", maxLength: 10, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LasUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    Step1 = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    Step2 = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    Step3 = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    Step4 = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    Step5 = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    Step6 = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    PaymentMethodID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDStep1 = table.Column<int>(type: "int", nullable: false),
                    IDStep2 = table.Column<int>(type: "int", nullable: false),
                    IDStep3 = table.Column<int>(type: "int", nullable: false),
                    IDStep4 = table.Column<int>(type: "int", nullable: false),
                    IDStep5 = table.Column<int>(type: "int", nullable: false),
                    IDStep6 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptStatus", x => x.ReceiptStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<string>(type: "Nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(150)", maxLength: 150, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentLastUpdateDate = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "SatisfactionLevels",
                columns: table => new
                {
                    SatisfactionLevelID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ReviewID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeelLever = table.Column<int>(type: "int", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    StartReivew = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisfactionLevels", x => x.SatisfactionLevelID);
                });

            migrationBuilder.CreateTable(
                name: "SpecialDiscounts",
                columns: table => new
                {
                    SpecialDiscountID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PercentReduction = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContentLastUpdateDate = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: true),
                    Expired = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialDiscounts", x => x.SpecialDiscountID);
                });

            migrationBuilder.CreateTable(
                name: "TypeAddress",
                columns: table => new
                {
                    TypeAddressID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    DateTimeCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAddress", x => x.TypeAddressID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemmenberAccount = table.Column<bool>(type: "bit", nullable: true),
                    IsActiver = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleID = table.Column<string>(type: "Nvarchar(10)", maxLength: 10, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delegator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContentLastUpdateDtae = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FistName = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarriageID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailAddress = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "Nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<string>(type: "Nvarchar(150)", maxLength: 150, nullable: false),
                    AddressCurent = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    CityID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.InsertData(
                table: "AreaMasters",
                columns: new[] { "CompanyCode", "AreaCode", "Description" },
                values: new object[] { "10000005", "10001", "Việt Nam - Tp.Hcm" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderID", "CreateDate", "Description", "IsDeleteFlag", "LasUpdateDate", "UserID" },
                values: new object[,]
                {
                    { "0001", new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), "Nam", false, null, null },
                    { "0002", new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), "Nữ", false, null, null },
                    { "0003", new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), "Chưa rỏ", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Marriages",
                columns: new[] { "MarriageID", "CreateDate", "Description", "IsDeleteFlag", "LasUpdateDate", "UserID" },
                values: new object[,]
                {
                    { "0001", new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), "Độc thân", false, null, null },
                    { "0002", new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), "Đã kết hôn", false, null, null },
                    { "0003", new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), "Đã ly dị", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "TypeAddress",
                columns: new[] { "TypeAddressID", "DateTimeCreate", "Description", "IsDeleteFlag", "LastUpdateDate", "UserID" },
                values: new object[,]
                {
                    { "0001", new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), "Nhà riêng", false, null, null },
                    { "0002", new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), "Văn phòng", false, null, null },
                    { "0003", new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), "Công ty", false, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "AreaMasters");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BankSuports");

            migrationBuilder.DropTable(
                name: "CategoryItemMasters");

            migrationBuilder.DropTable(
                name: "Citys");

            migrationBuilder.DropTable(
                name: "CustomerAddressOrders");

            migrationBuilder.DropTable(
                name: "CustomerCarts");

            migrationBuilder.DropTable(
                name: "CustomerReviews");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerWallets");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "FreeShipPrograms");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "HistoryWallets");

            migrationBuilder.DropTable(
                name: "ImageItemMasters");

            migrationBuilder.DropTable(
                name: "ImageReviews");

            migrationBuilder.DropTable(
                name: "IssuingCompanys");

            migrationBuilder.DropTable(
                name: "ItemMasters");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Marriages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrdersDetails");

            migrationBuilder.DropTable(
                name: "PairDiscounts");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Productsviewedbycustomers");

            migrationBuilder.DropTable(
                name: "PublishingCompanys");

            migrationBuilder.DropTable(
                name: "QuantityDiscounts");

            migrationBuilder.DropTable(
                name: "ReceiptPaymentOnlines");

            migrationBuilder.DropTable(
                name: "ReceiptStatus");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SatisfactionLevels");

            migrationBuilder.DropTable(
                name: "SpecialDiscounts");

            migrationBuilder.DropTable(
                name: "TypeAddress");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
