--Get ItemMaster By ItemCode
CREATE PROC GetItemMaster_ByID
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
		 Note nvarchar(MAX),
		 ImageDefault nvarchar(MAX),
		 ApplyDate datetime2(7)
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
		 Note,
		 ApplyDate
	 )
SELECT TXTCloud.dbo.ItemMasters.ItemCode, 
		TXTCloud.dbo.ItemMasters.Description, 
		TXTCloud.dbo.ItemMasters.DescriptionLong, 
		TXTCloud.dbo.ItemMasters.DescriptionShort, 
		TXTCloud.dbo.ItemMasters.StoreCode,
		TXTCloud.dbo.ItemMasters.CategoryItemMasterID, 
		TXTCloud.dbo.ItemMasters.AuthorID, 
		TXTCloud.dbo.ItemMasters.PublishingCompanyID, 
		TXTCloud.dbo.ItemMasters.Quantity, 
		TXTCloud.dbo.ItemMasters.size, 
		TXTCloud.dbo.ItemMasters.Note,
		TXTCloud.dbo.ItemMasters.ApplyDate
FROM TXTCloud.dbo.ItemMasters 
 WHERE ItemCode = @itemCode AND StoreCode = @storeCode AND IsDeleteFlag = 0 --FALSE

-- Get Image By ItemCode
DECLARE @recolURL nvarchar(MAX);
SET @recolURL = (
			SELECT TXTCloud.dbo.ImageItemMasters.Url
			FROM TXTCloud.dbo.ImageItemMasters 
			WHERE TXTCloud.dbo.ImageItemMasters.ItemCode = @itemCode 
				AND TXTCloud.dbo.ImageItemMasters.IsDefault = 1 
				AND TXTCloud.dbo.ImageItemMasters.IsDeleteFlag = 0
				)

-- Update Table @ItemMasterByID 
UPDATE @ItemMasterByID
SET ImageDefault  = @recolURL
SELECT * FROM @ItemMasterByID

