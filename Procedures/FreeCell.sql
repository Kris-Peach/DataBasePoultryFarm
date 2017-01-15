USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[FreeCell]    Script Date: 15.01.2017 21:00:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Предоставляет список всех свободных клеток>
-- =============================================
CREATE PROCEDURE [dbo].[FreeCell]
	
AS
BEGIN
	SELECT КодКлетки
	FROM dbo.Клетка
	WHERE КодКлетки NOT IN (SELECT КодКлетки FROM Курица)
END

GO

