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
		MAX(TXTCloud.dbo.ItemMasters.Description), 
		MAX(TXTCloud.dbo.ItemMasters.StoreCode),
		MAX(TXTCloud.dbo.ItemMasters.ApplyDate),
		MAX(TXTCloud.dbo.ItemMasters.PriceOrigin),
		MAX(TXTCloud.dbo.ItemMasters.priceSale),
		MAX(TXTCloud.dbo.ItemMasters.PercentDiscount),
		MAX(TXTCloud.dbo.ItemMasters.AuthorID),
		MAX(TXTCloud.dbo.ItemMasters.CategoryItemMasterID),
		MAX(TXTCloud.dbo.ItemMasters.CompanyCode),
		MAX(TXTCloud.dbo.ItemMasters.DescriptionShort),
		MAX(TXTCloud.dbo.ItemMasters.DescriptionLong),
		MAX(TXTCloud.dbo.ItemMasters.QuantityDiscountID),
		MAX(TXTCloud.dbo.ItemMasters.PairDiscountID),
		MAX(TXTCloud.dbo.ItemMasters.SpecialDiscountID),
		MAX(TXTCloud.dbo.ItemMasters.Quantity),
		MAX(TXTCloud.dbo.ItemMasters.Viewer),
		MAX(TXTCloud.dbo.ItemMasters.Buy),
		MAX(TXTCloud.dbo.ItemMasters.size),
		MAX(TXTCloud.dbo.ItemMasters.Note),
		MAX(TXTCloud.dbo.ItemMasters.HeadquartersLastUpdateDateTime),
		MAX(TXTCloud.dbo.ItemMasters.UserID),
		MAX(TXTCloud.dbo.ItemMasters.TaxGroupCodeID)
FROM TXTCloud.dbo.ItemMasters 
WHERE 
		ItemCode = @itemCode 
	AND StoreCode = @storeCode 
	AND IsDeleteFlag = 0 --FALSE
GROUP BY ItemCode
SELECT * FROM @ItemMasterByID

