USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[DeleteService]    Script Date: 15.01.2017 20:58:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Удаление связи Обслуживает, вызывать перед DeleteHen>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteService]  
	@NumHen int
AS
IF (SELECT COUNT([№Курицы]) FROM dbo.Курица WHERE [№Курицы] = @NumHen) > 0
BEGIN
	DELETE dbo.Обслуживает
	WHERE КодКлетки = (SELECT КодКлетки FROM dbo.Курица WHERE [№Курицы] = @NumHen)
END
ELSE PRINT 'Курицы с таким номером нет на фабрике'

GO

