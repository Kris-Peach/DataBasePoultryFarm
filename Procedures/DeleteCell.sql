USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[DeleteCell]    Script Date: 15.01.2017 20:57:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Удаление клетки с фабрики>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCell]
	-- Add the parameters for the stored procedure here
	@Code int 
AS
IF (SELECT COUNT(КодКлетки) FROM dbo.Обслуживает WHERE КодКлетки = @Code) = 0
BEGIN
	DELETE dbo.Клетка
	WHERE КодКлетки = @Code
END
ELSE PRINT 'Клетка не пуста, удаление невозможно'

GO

