USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[DeleteWorker]    Script Date: 15.01.2017 20:58:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Удаление сотрудника>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteWorker] 
	-- Add the parameters for the stored procedure here
	@Pasport varchar(50) 
AS
IF(SELECT COUNT([№Паспорта]) FROM dbo.Сотрудник WHERE [№Паспорта] = @Pasport) >0
BEGIN
	IF(SELECT COUNT([№Паспорта]) FROM dbo.Обслуживает WHERE [№Паспорта] = @Pasport) = 0
	BEGIN
	DELETE dbo.Сотрудник
	WHERE [№Паспорта] = @Pasport
	END
	ELSE PRINT 'Удалите сначала записи об этом сотруднике из таблицы Обслуживает'
END
ELSE PRINT 'Такого сотрудника нет на фабрике'

GO

