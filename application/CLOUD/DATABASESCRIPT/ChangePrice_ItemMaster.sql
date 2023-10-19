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
@size					nvarchar(100),
@IsSale					bit,
@Note					nvarchar(MAX),
@IsDeleteFlag			bit,
@UserID					nvarchar(MAX),
@TaxGroupCodeID			nvarchar(MAX),
@LastUpdateDate			datetime2(7),
@TypeOf					varchar(10)
AS
BEGIN
-- Update Price and Applydate ItemMaster
IF @TypeOf = 'UPDATE'
BEGIN
UPDATE TXTCloud.dbo.ItemMasters
SET
PriceOrigin = @PriceOrigin,
priceSale = @PriceSale,
PercentDiscount = @PercentDiscount,
LastUpdateDate = @LastUpdateDate
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
size,
IsSale,
Note,
IsDeleteFlag,
UserID,
TaxGroupCodeID,
LastUpdateDate
)
VALUES(
	@CompanyCode,
	@StoreCode,
	@ItemCode,
	@Applydate,
	@Descritpion,
	@DescriptionShort,
	@DescriptionLong,
	@PriceOrigin,
	@PercentDiscount,
	@PriceSale,
	@QuantityDiscountID,
	@PairDiscountID,
	@SpecialDiscountID,
	@Quantity,
	@Viewer,
	@Buy,
	@CategoryItemMasterID,
	@AuthorID,
	@DateCreate,
	@size,
	@IsSale,
	@Note,
	@IsDeleteFlag,
	@UserID,
	@TaxGroupCodeID,
	@LastUpdateDate
)
END

-- Insert Log Update
INSERT INTO TXTCloud.dbo.Logs(
	Id,
	UserID,
	Message, 
	DateCreate, 
	Status
)
VALUES(
	NEWID(),
	@UserID,
	N'Success: ' + @TypeOf + ' : ' + @ItemCode + ' ChangePrice ItemMaster -- PRICE ORIGINAL: ' + CONVERT(nvarchar(MAX), @PriceOrigin) + ' -- PRICE SALE: ' + CONVERT(nvarchar(MAX), @PriceSale) + ' -- PERCENTDISCOUNT: ' + CONVERT(nvarchar(MAX), @PercentDiscount) + ' -- APPLYDATE: ' + CONVERT(nvarchar(MAX), @Applydate) + ' , success',
	GETDATE(),
	1
)
END