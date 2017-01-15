USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[HumanResourcesOfPosition]    Script Date: 15.01.2017 21:00:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[HumanResourcesOfPosition]    Script Date: 08.10.2016 14:26:46 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
-- =============================================
-- Author:		Гриднева К.
-- Create date: 08.10.2016
-- Description:	Возвращает данные о сотрудниках по должностям
-- =============================================
CREATE PROCEDURE [dbo].[HumanResourcesOfPosition]
	-- Add the parameters for the stored procedure here
	@Position varchar(50)
AS
IF(SELECT COUNT(НазваниеДолжности) FROM Сотрудник WHERE НазваниеДолжности = @Position) > 0
BEGIN
	SELECT [№Паспорта], [№ТрудовойКнижки], ФИО
	FROM Сотрудник
	WHERE НазваниеДолжности = @Position
END
ELSE PRINT 'На фабрике нет сотрудников такой должности'

GO

