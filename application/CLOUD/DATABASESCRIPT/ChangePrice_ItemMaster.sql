CREATE PROCEDURE ChangePrice_ItemMaster
@CompanyCode			nvarchar(10),
@StoreCode				nvarchar(10),
@ItemCode				nvarchar(26),
@Applydate				datetime2(7),
@Descritpion			nvarchar(50),
@DescriptionShort		nvarchar(25),
@DescriptionLong		nvarchar(100),
@PriceOrigin			decimal(18, 2),
@PercentDiscount		int,
@PriceSale				decimal(18, 2),
@QuantityDiscountID		nvarchar(MAX),
@PairDiscountID			nvarchar(MAX),
@SpecialDiscountID		nvarchar(MAX),
@Quantity				int,
@Viewer					int,
@Buy					int,
@CategoryItemMasterID	nvarchar(MAX),
@AuthorID				nvarchar(MAX),
@DateCreate				datetime2(7),
@IssuingCompanyID		nvarchar(MAX),
@PublicationDate		datetime2(7),
@size					nvarchar(100),
@PageNumber				int,
@PublishingCompanyID	nvarchar(MAX),
@IsSale					bit,
@Note					nvarchar(MAX),
@IsDeleteFlag			bit,
@UserID					nvarchar(MAX),
@TaxGroupCodeID			nvarchar(MAX),
@TypeOf					int
AS
BEGIN
-- Update Price and Applydate ItemMaster
IF @TypeOf = 'UPDATE'
BEGIN
Update TXTCloud.dbo.ItemMasters
SET
PriceOrigin = @PriceOrigin,
priceSale = @PriceSale,
PercentDiscount = @PercentDiscount
WHERE
	TXTCloud.dbo.ItemMasters.ItemCode = @ItemCode
	AND TXTCloud.dbo.ItemMasters.ApplyDate = @Applydate
	AND TXTCloud.dbo.ItemMasters.CompanyCode = @CompanyCode
	AND TXTCloud.dbo.ItemMasters.StoreCode = @StoreCode
	AND TXTCloud.dbo.ItemMasters.IsDeleteFlag = 'false'
END
-- Create ItemMaster new Price
IF @TypeOf = 'CREATE'
BEGIN
Insert into TXTCloud.dbo.ItemMasters(
CompanyCode,
StoreCode,
ItemCode,
ApplyDate,
Description,
DescriptionShort,
DescriptionLong,
PriceOrigin,
PercentDiscount,
priceSale,
QuantityDiscountID,
PairDiscountID,
SpecialDiscountID,
Quantity,
Viewer,
Buy,
CategoryItemMasterID,
AuthorID,
DateCreate,
IssuingCompanyID,
PublicationDate,
size,
PageNumber,
PublishingCompanyID,
IsSale,
Note,
IsDeleteFlag,
UserID,
TaxGroupCodeID
)
Value(
)
END
GO