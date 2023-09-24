--Get All Store
CREATE PROC GetAll_Store
AS
 SELECT * FROM TXTCloud.dbo.Stores WHERE IsDeleteFlag = 0
 GO
