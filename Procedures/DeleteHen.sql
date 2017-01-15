USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[DeleteHen]    Script Date: 15.01.2017 20:58:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Удаление курицы,сначала вызвать DeleteService>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteHen] 
	@NumHen int 
	
AS
IF (SELECT COUNT([№Курицы]) FROM dbo.Курица WHERE [№Курицы] = @NumHen) > 0
BEGIN
	DELETE dbo.Курица
    WHERE [№Курицы] = @NumHen
END
ELSE PRINT 'Курицы с таким номером нет на фабрике'

GO

