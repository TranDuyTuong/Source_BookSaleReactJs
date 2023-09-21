--Get ItemMaster By ItemCode
CREATE PROC GetItemMasterById
@itemCode nvarchar(26),
@storeCode nvarchar(10)
AS
 DECLARE @ItemMasterByID 
	 table(
		 ItemCode nvarchar(26), 
		 Description nvarchar(50), 
		 DescriptionLong nvarchar(100), 
		 DescriptionShort nvarchar(25), 
		 StoreCode nvarchar(10), 
		 CategoryItemMasterID nvarchar(MAX), 
		 AuthorID nvarchar(MAX), 
		 PublishingCompanyID nvarchar(MAX), 
		 Quantity int, 
		 size nvarchar(100), 
		 Note nvarchar(MAX)
	 )
INSERT INTO @ItemMasterByID (
		 ItemCode, 
		 Description, 
		 DescriptionLong, 
		 DescriptionShort, 
		 StoreCode, 
		 CategoryItemMasterID, 
		 AuthorID, 
		 PublishingCompanyID, 
		 Quantity, 
		 size, 
		 Note
	 )
SELECT dbo.ItemMasters.ItemCode, 
		dbo.ItemMasters.Description, 
		dbo.ItemMasters.DescriptionLong, 
		dbo.ItemMasters.DescriptionShort, 
		dbo.ItemMasters.StoreCode,
		dbo.ItemMasters.CategoryItemMasterID, 
		dbo.ItemMasters.AuthorID, 
		dbo.ItemMasters.PublishingCompanyID, 
		dbo.ItemMasters.Quantity, 
		dbo.ItemMasters.size, 
		dbo.ItemMasters.Note
FROM TXTCloud.dbo.ItemMasters 
 WHERE ItemCode = @itemCode AND StoreCode = @storeCode AND IsDeleteFlag = 0 --FALSE
SELECT * FROM @ItemMasterByID