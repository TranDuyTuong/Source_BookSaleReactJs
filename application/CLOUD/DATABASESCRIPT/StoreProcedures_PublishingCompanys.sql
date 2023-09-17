CREATE PROC GetAll_PublishingCompany
AS
 SELECT * FROM TXTCloud.dbo.PublishingCompanys WHERE IsDeleteFlag = 'false'
GO
