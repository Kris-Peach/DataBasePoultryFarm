USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AddWorker]    Script Date: 15.01.2017 20:53:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Гриднева К.
-- Create date: 08.10.2016
-- Description:	добавление сотрудника
-- =============================================
CREATE PROCEDURE [dbo].[AddWorker]
	-- Add the parameters for the stored procedure here
	@Pasport varchar(50),
	@RecordOfService varchar(50),
	@FullName varchar(50),
	@Position varchar(50) 
AS
IF (SELECT COUNT([Название должности]) FROM dbo.Должность WHERE [Название должности] = @Position ) > 0
	BEGIN
	INSERT INTO dbo.Сотрудник ([№Паспорта], [№ТрудовойКнижки], ФИО, НазваниеДолжности)
	VALUES (@Pasport, @RecordOfService, @FullName, @Position)
	END
ELSE PRINT 'На фабрике нет указанной должности'

GO

