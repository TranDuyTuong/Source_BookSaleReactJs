--Get ItemMaster By ItemCode
CREATE PROC GetItemMasterUpdatePrice_ByID
@itemCode nvarchar(26),
@storeCode nvarchar(10)
AS
 DECLARE @ItemMasterByID 
	 table(
		 ItemCode									nvarchar(26), 
		 Description								nvarchar(50), 
		 StoreCode									nvarchar(10), 
		 ApplyDate									datetime2(7),
		 PriceOrigin								decimal(18, 2),
		 PriceSale									decimal(18, 2),
		 PercentDiscount							int,
		 AuthorID									nvarchar(MAX),
		 CategoryItemMasterID						nvarchar(MAX),
		 CompanyCode								nvarchar(10),
		 DescriptionShort							nvarchar(25),
		 DescriptionLong							nvarchar(100),
		 QuantityDiscountID							nvarchar(MAX),
		 PairDiscountID								nvarchar(MAX),
		 SpecialDiscountID							nvarchar(MAX),
		 Quantity									int,
		 Viewer										int,
		 Buy										int,
		 size										nvarchar(100),
		 Note										nvarchar(MAX),
		 HeadquartersLastUpdateDateTime				datetime2(7),
		 UserID										nvarchar(MAX),
		 TaxGroupCodeID								nvarchar(MAX)
	 )
INSERT INTO @ItemMasterByID (
		 ItemCode, 
		 Description, 
		 StoreCode,
		 ApplyDate,
		 PriceOrigin,
		 PriceSale,
		 PercentDiscount,
		 AuthorID,
		 CategoryItemMasterID,
		 CompanyCode,
		 DescriptionShort,
		 DescriptionLong,
		 QuantityDiscountID,
		 PairDiscountID,
		 SpecialDiscountID,
		 Quantity,
		 Viewer,
		 Buy,
		 size,
		 Note,
		 HeadquartersLastUpdateDateTime,
		 UserID,
		 TaxGroupCodeID
	 )
SELECT TXTCloud.dbo.ItemMasters.ItemCode, 
		TXTCloud.dbo.ItemMasters.Description, 
		TXTCloud.dbo.ItemMasters.StoreCode,
		TXTCloud.dbo.ItemMasters.ApplyDate,
		TXTCloud.dbo.ItemMasters.PriceOrigin,
		TXTCloud.dbo.ItemMasters.priceSale,
		TXTCloud.dbo.ItemMasters.PercentDiscount,
		TXTCloud.dbo.ItemMasters.AuthorID,
		TXTCloud.dbo.ItemMasters.CategoryItemMasterID,
		TXTCloud.dbo.ItemMasters.CompanyCode,
		TXTCloud.dbo.ItemMasters.DescriptionShort,
		TXTCloud.dbo.ItemMasters.DescriptionLong,
		TXTCloud.dbo.ItemMasters.QuantityDiscountID,
		TXTCloud.dbo.ItemMasters.PairDiscountID,
		TXTCloud.dbo.ItemMasters.SpecialDiscountID,
		TXTCloud.dbo.ItemMasters.Quantity,
		TXTCloud.dbo.ItemMasters.Viewer,
		TXTCloud.dbo.ItemMasters.Buy,
		TXTCloud.dbo.ItemMasters.size,
		TXTCloud.dbo.ItemMasters.Note,
		TXTCloud.dbo.ItemMasters.HeadquartersLastUpdateDateTime,
		TXTCloud.dbo.ItemMasters.UserID,
		TXTCloud.dbo.ItemMasters.TaxGroupCodeID
FROM TXTCloud.dbo.ItemMasters 
 WHERE 
		ItemCode = @itemCode 
	AND StoreCode = @storeCode 
	AND IsDeleteFlag = 0 --FALSE

SELECT * FROM @ItemMasterByID

