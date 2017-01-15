USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AddService]    Script Date: 15.01.2017 20:53:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Добавление связи Обслуживает, выполнять процедуру сразу после AddHens,
-- выбор кода клетки осуществляет пользователь на результат запроса FreeCell>
-- =============================================
CREATE PROCEDURE [dbo].[AddService]
	-- Add the parameters for the stored procedure here
	@Pasport varchar(50), 
	@Code int
AS
IF (SELECT COUNT([№Паспорта]) FROM dbo.Сотрудник WHERE [№Паспорта] = @Pasport) > 0
BEGIN
	INSERT INTO dbo.Обслуживает([№Паспорта], КодКлетки)
	VALUES (@Pasport, @Code)
END
ELSE PRINT 'На фабрике нет сотрудника с указанным номером паспорта'

GO

