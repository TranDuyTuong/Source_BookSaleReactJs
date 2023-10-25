USE [TXTCloud]
GO
/****** Object:  StoredProcedure [dbo].[GetAll_ItemMaster]    Script Date: 9/20/2023 8:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetAll_ItemMaster]
@StoreCode nvarchar(10),
@CompanyCode nvarchar(10)
AS
-- NOT SELECT STORECODE
IF @StoreCode = '0'
	SELECT ItemMasters.ItemCode, MAX(ItemMasters.Description) AS Description
	FROM TXTCloud.dbo.ItemMasters 
	WHERE dbo.ItemMasters.IsDeleteFlag = 0 AND dbo.ItemMasters.IsSale = 1 AND dbo.ItemMasters.CompanyCode = @CompanyCode
	GROUP BY ItemMasters.ItemCode
ELSE
-- HAVE SELECT STORECODE
SELECT ItemMasters.ItemCode, MAX(ItemMasters.Description) AS Description
	FROM TXTCloud.dbo.ItemMasters 
	WHERE dbo.ItemMasters.IsDeleteFlag = 0 
			AND dbo.ItemMasters.IsSale = 1 
			AND dbo.ItemMasters.StoreCode = @StoreCode 
			AND dbo.ItemMasters.CompanyCode = @CompanyCode
	GROUP BY ItemMasters.ItemCode
