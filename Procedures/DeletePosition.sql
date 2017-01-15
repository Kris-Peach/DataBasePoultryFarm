USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[DeletePosition]    Script Date: 15.01.2017 20:58:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Удаление должности>
-- =============================================
CREATE PROCEDURE [dbo].[DeletePosition]
	-- Add the parameters for the stored procedure here
	@NamePosition varchar(50)
AS
IF (SELECT COUNT(НазваниеДолжности) FROM dbo.Сотрудник WHERE НазваниеДолжности=@NamePosition) = 0
BEGIN
	DELETE dbo.Должность
	WHERE [Название должности] = @NamePosition
END
ELSE PRINT 'На фабрике есть сотрудник с указанной должностью, удаление невозможно'

GO

