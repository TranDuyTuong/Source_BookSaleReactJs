--Get ItemMaster By ItemCode
CREATE PROC GetItemMasterUpdatePrice_ByID
@itemCode nvarchar(26),
@storeCode nvarchar(10)
AS
 DECLARE @ItemMasterByID 
	 table(
		 ItemCode					nvarchar(26), 
		 Description				nvarchar(50), 
		 StoreCode					nvarchar(10), 
		 ApplyDate					datetime2(7),
		 PriceOrigin				decimal(18, 2),
		 PriceSale					decimal(18, 2),
		 PercentDiscount			int,
		 AuthorID					nvarchar(MAX),
		 CategoryItemMasterID		nvarchar(MAX)
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
		 CategoryItemMasterID
	 )
SELECT TXTCloud.dbo.ItemMasters.ItemCode, 
		TXTCloud.dbo.ItemMasters.Description, 
		TXTCloud.dbo.ItemMasters.StoreCode,
		TXTCloud.dbo.ItemMasters.ApplyDate,
		TXTCloud.dbo.ItemMasters.PriceOrigin,
		TXTCloud.dbo.ItemMasters.priceSale,
		TXTCloud.dbo.ItemMasters.PercentDiscount,
		TXTCloud.dbo.ItemMasters.AuthorID,
		TXTCloud.dbo.ItemMasters.CategoryItemMasterID
FROM TXTCloud.dbo.ItemMasters 
 WHERE 
		ItemCode = @itemCode 
	AND StoreCode = @storeCode 
	AND IsDeleteFlag = 0 --FALSE

SELECT * FROM @ItemMasterByID

