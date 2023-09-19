--Get ItemMaster By ItemCode
CREATE PROC GetItemMasterById
@itemCode nvarchar(26)
AS
BEGIN
 SELECT * FROM TXTCloud.dbo.ItemMasters WHERE ItemCode = @itemCode AND IsDeleteFlag = 0 --FALSE
END
GO