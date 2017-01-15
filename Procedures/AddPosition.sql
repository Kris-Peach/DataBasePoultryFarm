USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[AddPosition]    Script Date: 15.01.2017 20:34:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Г>риднева К
-- Create date: <23.10.2016>
-- Description:	<Добавление новой должности>
-- =============================================
CREATE PROCEDURE [dbo].[AddPosition]
	-- Add the parameters for the stored procedure here
	@NamePosition varchar(50), 
	@Salary smallmoney
AS
IF (SELECT COUNT([Название должности]) FROM dbo.Должность WHERE [Название должности] = @NamePosition ) = 0
BEGIN
	INSERT INTO dbo.Должность ([Название должности], Зарплата)
	VALUES (@NamePosition, @Salary)
END
ELSE PRINT 'На фабрике уже есть указанная должность'

GO

