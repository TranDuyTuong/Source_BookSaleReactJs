CREATE PROC GetAll_Category
AS
 SELECT * FROM TXTCloud.dbo.CategoryItemMasters WHERE IsDeleteFlag = 'false'
GO
