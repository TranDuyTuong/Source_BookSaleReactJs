CREATE PROC GetAll_PublishingCompany
AS
 SELECT * FROM TXTCloud.dbo.PublishingCompanys WHERE IsDeleteFlag = 0
GO
