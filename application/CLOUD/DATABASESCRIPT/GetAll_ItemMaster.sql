USE [TXTCloud]
GO
/****** Object:  StoredProcedure [dbo].[GetAll_ItemMaster]    Script Date: 9/20/2023 8:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetAll_ItemMaster]
@StoreCode nvarchar(10)
AS
IF @StoreCode = NULL
	SELECT ItemMasters.ItemCode, ItemMasters.CompanyCode, ItemMasters.StoreCode, ItemMasters.Description
	FROM TXTCloud.dbo.ItemMasters 
	WHERE dbo.ItemMasters.IsDeleteFlag = 0 AND dbo.ItemMasters.IsSale = 1
	ORDER BY dbo.ItemMasters.ApplyDate DESC 
		-- Get 100 recol
	OFFSET 0 ROWS 
	FETCH NEXT 100 ROWS ONLY;
ELSE
SELECT ItemMasters.ItemCode, ItemMasters.CompanyCode, ItemMasters.StoreCode, ItemMasters.Description
	FROM TXTCloud.dbo.ItemMasters 
	WHERE dbo.ItemMasters.IsDeleteFlag = 0 AND dbo.ItemMasters.IsSale = 1 AND dbo.ItemMasters.StoreCode = @StoreCode
	ORDER BY dbo.ItemMasters.ApplyDate DESC 
	-- Get 100 recol
	OFFSET 0 ROWS 
	FETCH NEXT 100 ROWS ONLY;
