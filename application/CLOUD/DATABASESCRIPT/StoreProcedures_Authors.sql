CREATE PROC GetAll_Author
AS
SELECT * FROM TXTCloud.dbo.Authors WHERE IsDeleteFlag = 'false'
GO
