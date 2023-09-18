CREATE PROC GetAll_ItemMaster
AS
BEGIN
	SELECT * FROM TXTCloud.dbo.ItemMasters
	WHERE dbo.ItemMasters.IsDeleteFlag = 'false'
END;


