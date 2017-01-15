USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[Report]    Script Date: 15.01.2017 21:01:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Гриднева К>
-- Create date: <23.10.2016>
-- Description:	<Отчет>
-- =============================================
CREATE PROCEDURE  [dbo].[Report]
	
AS
BEGIN
	SELECT Порода.НазваниеПороды, COUNT(Курица.[№Курицы]) AS [Кол-во кур],
	AVG(Курица.[Кол-воЯиц]) AS [Средняя производительность], SUM(Курица.[Кол-воЯиц]) AS Производительность 
	FROM Порода INNER JOIN Курица ON (Порода.НазваниеПороды = Курица.НазваниеПороды)
	GROUP BY Порода.НазваниеПороды, Порода.Производительность, Порода.[№Диеты]
END

GO

