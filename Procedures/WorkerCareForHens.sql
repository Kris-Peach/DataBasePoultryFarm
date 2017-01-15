USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[WorkerCareForHens]    Script Date: 15.01.2017 21:02:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Возвращает список рабочих на должности "по уходу за птицей">
-- =============================================
CREATE PROCEDURE [dbo].[WorkerCareForHens] 
	-- Add the parameters for the stored procedure here
	@Position nvarchar(50)
AS
IF(SELECT COUNT(НазваниеДолжности) FROM Сотрудник WHERE НазваниеДолжности = @Position) > 0
BEGIN
	SELECT ФИО
	FROM Сотрудник
	WHERE НазваниеДолжности = @Position
END
ELSE PRINT 'На фабрике нет сотрудников такой должности'

GO

