USE [TXTCloud]
GO

/****** Object:  StoredProcedure [dbo].[GetCityByID]    Script Date: 7/10/2023 10:11:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCityByID](@CITYID NVARCHAR(50))
AS
BEGIN
	SELECT * FROM TXTCloud.dbo.Citys
	WHERE CityID = @CITYID
END;
GO

