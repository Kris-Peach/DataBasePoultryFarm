USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AddCell]    Script Date: 15.01.2017 20:33:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Добавление клетки на фабрику>
-- =============================================
CREATE PROCEDURE [dbo].[AddCell] 
	-- Add the parameters for the stored procedure here
	@Code int, 
	@Department int,
	@Line int,
	@Number int
AS
IF (SELECT COUNT (КодКлетки) FROM dbo.Клетка WHERE КодКлетки = @Code) = 0
BEGIN
	INSERT INTO dbo.Клетка (КодКлетки, [№Цеха], [№РядаВЦехе], [№КлеткиВРяду])
	VALUES (@Code, @Department, @Line, @Number)
END
ELSE PRINT 'На фабрике уже есть такая клетка'

GO

