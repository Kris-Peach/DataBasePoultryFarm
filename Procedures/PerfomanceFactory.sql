USE [Poultry Farm]
GO

/****** Object:  StoredProcedure [dbo].[PerfomanceFactory]    Script Date: 15.01.2017 21:01:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Гриднева К.
-- Create date: 08,10.2016
-- Description:	показывает среднее количество яиц, получаемое от кур каждой породы
-- =============================================
CREATE PROCEDURE [dbo].[PerfomanceFactory]
	
AS
BEGIN
	SELECT Курица.НазваниеПороды, COUNT(Курица.[№Курицы])AS [Количество Кур], AVG(Курица.[Кол-воЯиц]) AS [Среднее кол-во яиц], SUM(Курица.[Кол-воЯиц]) AS [Кол-во яиц]
	FROM Курица
	GROUP BY Курица.НазваниеПороды
END

GO

