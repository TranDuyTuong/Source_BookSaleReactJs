USE [TXTCloud]
GO

/****** Object:  StoredProcedure [dbo].[GetListCitys]    Script Date: 7/10/2023 10:12:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetListCitys]
AS
BEGIN
	SELECT * FROM TXTCloud.dbo.Citys
END;
GO

