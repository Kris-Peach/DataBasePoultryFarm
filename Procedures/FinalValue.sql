USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[FinalValue]    Script Date: 15.01.2017 20:59:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Итоговые значения для отчета>
-- =============================================
CREATE PROCEDURE [dbo].[FinalValue]
	
AS
BEGIN
	SELECT SUM(Курица.[№Курицы]) AS [Кол-во кур],
	AVG(Курица.[Кол-воЯиц]) AS [Средняя производительность], SUM(Курица.[Кол-воЯиц]) AS Производительность 
	FROM Курица 
END

GO

